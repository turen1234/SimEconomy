using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocietySim
{
    public partial class Form1 : Form
    {



        public bool atWar = false;
        public Stats data;
        private bool isMultiplayer = false;
        public double oneDay = 1.0/365.0;
        public double taxRate = 0.1;
        public double moneyCycled           = 0;
        public double moneyIssuedPerYear;
        public double moneyInCirculation    = 0.0;
        public long arsenal                 = 100;



        public double annualInflation       = 0.03;
        public double population            = 0.0;
        public double armyPersonal          = 0.0;
        public double year                  = 2016.0;

        public double populationGrowth      = 0.018 / 365.0; //percent per year

        public double gdp               = 0.0;
        public double workerHappiness   = 0.0;
        public double moneyPoolChange   = 0.0;
        public double costOfLiving      = 0.0;

        private Economy econ = new Economy();
        private StatChart chartView;
        private Random rand             = new Random();
        private Treasury twindow;
        private WarRoom warRoom;
        public ServerConnection sc;

        

        private double lastCirculation =0.0; 

        public Form1()
        {
            InitializeComponent();

            warRoom     = new WarRoom();
            twindow     = new Treasury(ref econ.money);
            warRoom.attack = new WarRoom.AttackPlayerDelegate(attackPlayer);
            warRoom.Show();
            twindow.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            sc = new ServerConnection();
            if (sc.ShowDialog() == DialogResult.OK)
            {
                isMultiplayer       = true;
                NetTimer.Enabled    = true;
            }
            else isMultiplayer  = false;
            econ                = new Economy();
            twindow.moneypool   = econ.money;

            data = new Stats();

            chartView           = new StatChart( ref data);
            chartView.selList   = data.stat_treasury;
            chartView.Show();

            sc.drd          = new ServerConnection.DataReceivedDelegate(receivedStats);
            population      = (double)Pop.Value;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            year += oneDay;

            if(econ.costPerMeal <= 0 )
            {
                gameOver("Game Over: Your economy collapsed.");
                return;
            }
            if(Double.IsNaN(econ.costPerMeal) || Double.IsNaN(econ.monthlyRentPerPerson))
            {
                gameOver("Game Over: Your economy hyper-inflated");
                return;
            }

  
            populationCalculations();
          
            double dailyMealCost        = ((3.0*econ.costPerMeal) *population)/1000000000;
            double dailyRentCost        = ((econ.monthlyRentPerPerson/30.0) * population)/1000000000;


            //keep the price of meals low and the number of resources high, this is your baseline


            //baseunit better if higher


            double startPoint = econ.resources / population;

            econ.baseUnit = startPoint / econ.costPerMeal; //econ.costPerMeal/(Math.Log(population)*Math.Log(econ.resources));

            //percent unit defines government spending
            double percentUnit          = (dailyMealCost + dailyRentCost) / (double)BudgetWelfare.Value;

            double defenceBudge         = (double)DefenceBudget.Value * percentUnit;
            double healthBudget         = (double)BudgetHealth.Value * percentUnit;
            double educationBudget      = (double)BudgetEducation.Value * percentUnit;
            double roadBudget           = (double)BudgetRoads.Value * percentUnit;
            double innovationBudget     = (double)BudgetInnovation.Value *percentUnit;

            //all currency creation is to be done between these comments START HERE

            econ.issueFoodCurrency(dailyMealCost);
            econ.issueRentCurrency(dailyRentCost);

            econ.issueDefenceCurrency(defenceBudge);
            econ.issueEducationCurrency(educationBudget);
            econ.issueHealthCurrency(healthBudget);
            econ.issueRoadCurrency(roadBudget);
            econ.issueInnovationCurrency(innovationBudget);

            econ.money.welfare          = econ.money.superMarketRevenue + econ.money.developerRevenue;

            double dailytax             = ((double)Tax.Value/100.0)/365.0;
            double t                    = econ.money.tax(dailytax);
            double totalCreated         = innovationBudget + roadBudget + defenceBudge + healthBudget + educationBudget+ dailyMealCost + dailyRentCost - t;


            if (totalCreated > 0.0 && econ.money.treasury >= totalCreated)
            {
                //take residual from treasury
                econ.money.treasury -= totalCreated;
                totalCreated = 0.0;
            }

            else if (totalCreated < 0.0)
            {
                // made a profit from taxation, store it in treasury
                econ.money.treasury += Math.Abs(totalCreated);
                totalCreated = 0.0;
            }

            //END HERE

            econ.money.billionsPrinted             += totalCreated;
            lastCirculation             = moneyInCirculation;
            moneyInCirculation          = econ.money.total();
            gdp                         = (moneyInCirculation * 1000000000) / population; // convert from billions to dollars
            costOfLiving                = econ.money.welfare / moneyInCirculation;

            moneyPoolChange             = moneyInCirculation - lastCirculation;
            infateCurrency(totalCreated);
            econ.averageMonthlyInflation += econ.inflation;


            workerHappiness = ((econ.money.education / moneyInCirculation) 
                + (econ.money.roads / moneyInCirculation) 
                + (econ.money.health / moneyInCirculation)) 
                * (econ.money.welfare / moneyInCirculation) 
                * (1 - taxRate) ;

            if (atWar) workerHappiness /= 2.0;

            //daily productibity;

            increaseResources();
            increaseArsenal();
            //if (atWar) casualitiesOfWar();

            if (totalCreated <= 0.0)        Label_CurrencyPM.ForeColor = Color.Green;
            else                            Label_CurrencyPM.ForeColor = Color.Red;

            label_tax.Text          = String.Format("${0:n} B", t);
            Label_CurrencyPM.Text   = String.Format("${0:n} B", totalCreated );
            updateLabels();
            data.days++;

            // new month
            if (data.days % 30 == 0)  recordStats();
            if ((year % 1.0)  >= 0.9999) performTrade();
        }
        public void recordStats()
        {
            double dstat  = (econ.money.defence / moneyInCirculation) / econ.costPerMeal;
            data.stat_defence.Add(dstat);
            data.stat_gdp.Add(gdp);
            data.stat_population.Add(population);
            data.stat_treasury.Add(econ.money.treasury);
            data.stat_army.Add(armyPersonal);
            data.stat_inflation.Add(econ.averageMonthlyInflation / 30.0f);
            data.stat_baseline.Add(econ.baseUnit);
            data.stat_moneyCirc.Add(moneyInCirculation);
            data.stat_workerHap.Add(workerHappiness);

            econ.averageMonthlyInflation = 0.0;
        }
        
        public void performTrade()
        {
            foreach(ListViewItem li in warRoom.countryList.Items)
            {
                try
                {
                    bool trading    = li.Checked;
                    double e        = (double)li.SubItems[4].Tag;

                    double imports  = econ.maxTradePerDay * (1.0 - (double)(taxImports.Value / 100));
                    double exports  = econ.maxTradePerDay * (1.0 - (double)(taxExports.Value / 100));

                    double pricePerResource =  econ.baseUnit * 1000.0;
                    // buy 1000 imports

                }
                catch(Exception ex)
                {

                }
   
            }


        }
        public void infateCurrency(double newMoney)
        {
            double monthyInflation = (annualInflation / 365.0);
            if (moneyInCirculation == 0)
            {
                econ.inflation   = monthyInflation;
            }
            else
            {
                econ.inflation   = moneyPoolChange * monthyInflation;
            }
            econ.costPerMeal             = econ.costPerMeal           + (econ.costPerMeal * econ.inflation);
            econ.monthlyRentPerPerson    = econ.monthlyRentPerPerson  + (econ.monthlyRentPerPerson * econ.inflation);
        }

        private void populationCalculations()
        {
            if(moneyInCirculation > 0.0)
            {
                double healthBonus = (econ.money.health/moneyInCirculation) * populationGrowth;
                population = population + (population * populationGrowth) + (population * healthBonus);
            }
            else
            {
                population = population + (population * populationGrowth);
            }
            double maxArmy = (population * 0.5);
            armyPersonal    = maxArmy  * (econ.money.defence / moneyInCirculation);
        }

        private void updateLabels()
        {
            double inf_percent = econ.inflation *100;

            label_costofliving.Text     = String.Format("{0:n3}%", workerHappiness*100);
            label_circulation.Text      = String.Format("${0:n0} B", moneyInCirculation );
            label_treasury.Text         = String.Format("${0:n0} B", econ.money.treasury );

            Label_defpool.Text          = String.Format("{0:n2} B", econ.money.defence );
            label_educationpool.Text    = String.Format("{0:n2} B", econ.money.education );
            label_healthpool.Text       = String.Format("{0:n2} B", econ.money.health );
            label_welfarepool.Text      = String.Format("{0:n2} B", econ.money.welfare );
            label_roadpool.Text         = String.Format("{0:n2} B", econ.money.roads );
            label_innovationpool.Text   = String.Format("{0:n2} B", econ.money.innovation );
            label_resources.Text        = String.Format("{0:n0}",   econ.resources);

            label_army.Text             = String.Format("{0:n2} M", armyPersonal / 1000000.0);
            label_arsenal.Text          = String.Format("{0:n0}", arsenal);

            Label_pop.Text              = String.Format("{0:n2} M", population / 1000000.0);
            Label_cycled.Text           = String.Format("${0:n} B", econ.money.billionsPrinted);
            Label_MealCost.Text         = String.Format("${0:n}",   econ.costPerMeal);
            Label_rent.Text             = String.Format("${0:n}",   econ.monthlyRentPerPerson);
            Label_Year.Text             = String.Format("{0}", Math.Round(year, 2));
            label_inflation.Text        = String.Format("{0:n4}%", inf_percent);
            label_gdp.Text              = String.Format("${0:n2}", gdp);

            if (inf_percent < -0.25 || inf_percent > 0.25)          label_inflation.ForeColor = Color.Red;
            else                                                    label_inflation.ForeColor = Color.Green;

            if (inf_percent > 0.5)    warning.Visible = true;
            else                    warning.Visible = false;

        }
      
        private void increaseResources()
        {
            //resources are generated based off of relative cumulative relative units of total expendatures. 
            // the amount invested into a particular sector as a ratio of the total amount of money in the sector at that time.
            //roads and education along with worker happiness define the daily resources generated.

            double a = Math.Log10(Math.Sqrt(population)*workerHappiness);
            double b = (econ.totalSpendRoads + econ.totalSpendInnovation + econ.totalSpendEducation) / 3.0;

            econ.resources += a+b;


        }

        private void increaseArsenal()
        {
            double a = econ.money.defence/moneyInCirculation;
            double b = (econ.money.roads/moneyInCirculation) + (econ.money.education/moneyInCirculation) / 2.0;

            double newMachings = Math.Log(population) * ((a + b + workerHappiness)/3.0) ;
            arsenal += (long)Math.Floor(newMachings);
        }

       
        private void attackPlayer(string[] playerno)
        {
            if (!isMultiplayer) return;
            try
            {
                sc.Send(String.Format("Attack:{0},<EOF>Defense:{1}<EOF>",String.Join(",",playerno),econ.totalSpendDefense));
                sc.sendDone.WaitOne();
                sc.Receive(sc.conn);
                sc.receiveDone.WaitOne(5000);
            }

            catch (Exception ex)
            {

            }

        }

        private void declareWar()
        {
            atWar = true;
        }

        private void gameOver(String message)
        {
            timer1.Stop();
            MessageBox.Show(message);
        }



        private void budgetChanged(object sender, EventArgs e)
        {
            NumericUpDown seln = ((NumericUpDown)sender);

            List<NumericUpDown> budgetpanel = new List<NumericUpDown>() {BudgetEducation,BudgetHealth,BudgetInnovation,BudgetRoads,BudgetWelfare,DefenceBudget };

            decimal total = BudgetEducation.Value + BudgetHealth.Value + BudgetInnovation.Value + BudgetRoads.Value + BudgetWelfare.Value +DefenceBudget.Value;

            while(total > 100)
            {

                foreach(NumericUpDown n in budgetpanel)
                {
                    if (n.Tag.Equals(seln.Tag)){
                        continue;
                    }
                    if (n.Value >= 1.2m)   n.Value -= 0.2m;
                    else                n.Value = 1;
                }

                total = BudgetEducation.Value + BudgetHealth.Value + BudgetInnovation.Value + BudgetRoads.Value + BudgetWelfare.Value + DefenceBudget.Value;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label_war.Visible = true;
            declareWar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
    
        }

        private void PrintMoney(object sender, EventArgs e)
        {
            Quantity q = new Quantity();
            q.ShowDialog();

            if(q.DialogResult == DialogResult.OK)
            {
                econ.money.treasury += q.amount;
                //infateCurrency(q.amount);
                econ.money.billionsPrinted += q.amount;
            }
        }
  


        private void receivedStats(string data)
        {

            if (data.StartsWith("War Report:"))
            {


            }
            else if (data.StartsWith("War Declared:"))
            {
                atWar = true;
            }
            else
            {
                string[] rows = data.Split('\n');


                this.Invoke(new Action(() =>
                {
                    List<ListViewItem> lvil = new List<ListViewItem>();
                    warRoom.countryList.BeginUpdate();
                    warRoom.countryList.Items.Clear();
                    int i = 0;

                    foreach (String r in rows)
                    {
                        string[] cols = r.Split(',');
                        ListViewItem li = new ListViewItem(cols);
                        li.Tag = i.ToString();
                        warRoom.countryList.Items.Add(li);
                        i++;
                    }

                    warRoom.countryList.EndUpdate();

                }));

            }

        }
        
        private void NetTimer_Tick(object sender, EventArgs e)
        {
            //send population
            //send military
            //send arsenal

            try
            {
                byte[] f0   = new byte[] {(byte)(char)Command.Info};
                byte[] f1   = BitConverter.GetBytes(population);
                byte[] f2   = BitConverter.GetBytes(armyPersonal);
                byte[] f3   = BitConverter.GetBytes(arsenal);
                byte[] f4   = BitConverter.GetBytes(econ.baseUnit);
                byte[] end  = Encoding.UTF8.GetBytes("<EOF>");

                byte[] final = f0.Concat(f1).Concat(f2).Concat(f3).Concat(f4).Concat(end).ToArray();


                //sc.Send(String.Format("{0},{1},{2},{3},<EOF>", population, armyPersonal, arsenal, econ.baseUnit));
                sc.Send(final);
                sc.sendDone.WaitOne();
                sc.Receive(sc.conn);
                sc.receiveDone.WaitOne();
            }

            catch (Exception ex)
            {


            }
        }
        private void alignWindows()
        {
            if(chartView != null) chartView.Location = new Point(this.Location.X + this.Size.Width + 5, this.Location.Y + this.Size.Height + 5);
            warRoom.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height + 5);
            twindow.Location = new Point(this.Location.X + this.Size.Width + 5, this.Location.Y);
            twindow.Height = this.Height;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            alignWindows();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alignWindows();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            alignWindows();

        }
    }
}
