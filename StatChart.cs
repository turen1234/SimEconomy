using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SocietySim
{
    public partial class StatChart : Form
    {
        public Stats info;

        public List<double> selList;

        public StatChart(ref Stats data)
        {
            info = data;

            InitializeComponent();
        }

        private void updateChart()
        {
            chart1.Series[0].Points.Clear();
            try
            {


                if (checkBox1yr.Checked)
                {
                    for (int i = selList.Count - 12; i < selList.Count; i++)
                    {
                        chart1.Series[0].Points.AddY(selList[i]);
                    }

                }
                else if (checkBox10yr.Checked)
                {
                    for (int i = selList.Count - 120; i < selList.Count; i++)
                    {
                        chart1.Series[0].Points.AddY(selList[i]);
                    }
                }
                else
                {
                    foreach (double d in selList)
                    {
                        chart1.Series[0].Points.AddY(d);
                    }
                }
            }
            catch (Exception e)
            {


            }
     

        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            updateChart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    selList = info.stat_population;

                    break;


                case 1:
                    selList = info.stat_treasury;

                    break;
                case 2:
                    selList = info.stat_baseline;

                    break;
                case 3:
                    selList = info.stat_inflation;

                    break;
                case 4:
                    selList = info.stat_gdp;

                    break;

                case 5:
                    selList = info.stat_moneyCirc;

                    break;
                case 6:
                    selList = info.stat_workerHap;

                    break;
            }

            updateChart();
        }
    }
}
