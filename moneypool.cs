using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySim
{


    public class MoneyPool
    {

        public double treasury              = 0.0;

        public double welfare           = 0.0;
        public double education         = 0.0;
        public double defence           = 0.0;
        public double health            = 0.0;
        public double roads              = 0.0;
        public double innovation        = 0.0;
        public double superMarketRevenue    = 0.0;
        public double developerRevenue      = 0.0;
        public double billionsPrinted   = 0.0;


        public double total()
        {
            return defence + health + education + roads + welfare + innovation;
        }


        public double tax(double taxRate)
        {
            double retrieved = 0.0;

            double tax          = welfare * taxRate;
            superMarketRevenue -= tax;
            retrieved           += tax;

            tax                 = developerRevenue * taxRate;
            developerRevenue    -= tax;
            retrieved           += tax;

            tax                 = defence * taxRate;
            defence         -= tax;
            retrieved           += tax;

            tax                 = education * taxRate;
            education       -= tax;
            retrieved           += tax;

            tax                 = health * taxRate;
            health          -= tax;
            retrieved           += tax;

            tax                 = roads * taxRate;
            roads            -= tax;
            retrieved           += tax;

            tax                 = innovation * taxRate;
            innovation          -= tax;
            retrieved           += tax;

            return retrieved;
        }

      


    }
}
