using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocietySim
{
    public partial class Treasury : Form
    {
        public MoneyPool moneypool;



        public Treasury(ref MoneyPool mp)
        {
            moneypool = mp;
            InitializeComponent();
        }

        private void SpendMoney(object sender, EventArgs e)
        {
            double amount = 0.0;


            if (sender.Equals(button_spendDefence))
            {
                amount = (double)AmountDefence.Value;
                if (amount > moneypool.treasury) return;
                moneypool.defence += amount;
            }

            else if (sender.Equals(button_spendEdu))
            {
                amount = (double)AmountEducation.Value;
                if (amount > moneypool.treasury) return;
                moneypool.education += amount;
            }

            else if (sender.Equals(button_spendHealth))
            {
                amount = (double)AmountHealth.Value;
                if (amount > moneypool.treasury) return;
                moneypool.health += amount;
            }

            else if (sender.Equals(button_spendInnovation))
            {
                amount = (double)AmountInnovation.Value;
                if (amount > moneypool.treasury) return;
                moneypool.innovation += amount;
            }
            else if (sender.Equals(button_spendRoads))
            {
                amount = (double)AmountRoads.Value;
                if (amount > moneypool.treasury) return;
                moneypool.roads += amount;
            }
            else if (sender.Equals(button_spendWelfare))
            {
                amount = (double)AmountWelfare.Value;
                if (amount > moneypool.treasury) return;
                moneypool.developerRevenue += amount / 2.0;
                moneypool.superMarketRevenue += amount / 2.0;

            }
            else return;


            moneypool.treasury -= amount;


        }
    }
}
