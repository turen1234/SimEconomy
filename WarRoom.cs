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
    public partial class WarRoom : Form
    {

        public delegate void AttackPlayerDelegate(string[] playerNo);
        public AttackPlayerDelegate attack;


        public WarRoom()
        {
            InitializeComponent();
        }

        private void attackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> targets = new List<string>();

            foreach(ListViewItem li in countryList.SelectedItems)
            {
                targets.Add(li.Tag.ToString());
;
            }
            attack.Invoke(targets.ToArray());
        }
    }
}
