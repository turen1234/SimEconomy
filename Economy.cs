using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySim
{
    class Economy
    {
        public MoneyPool money = new MoneyPool();

        public double totalSpendWelfare     = 0.0;
        public double totalSpendDefense     = 0.0;
        public double totalSpendHealth      = 0.0;
        public double totalSpendEducation   = 0.0;
        public double totalSpendRoads       = 0.0;
        public double totalSpendInnovation  = 0.0;

        public double baseUnit = 1.0;

        public double maxTradePerDay        = 0.5;
        public double resources             = 1000000;
        public double inflation             = 0.0;
        public double averageMonthlyInflation             = 0.0;

        public double monthlyRentPerPerson  = 1600.00;
        public double costPerMeal           = 10.00;

        public void issueRoadCurrency(double amount)
        {
            money.roads     += amount;
            totalSpendRoads += amount * baseUnit;
        }

        public void issueFoodCurrency(double amount)
        {
            money.superMarketRevenue += amount;
            totalSpendWelfare += (amount) * baseUnit;
        }

        public void issueRentCurrency(double amount)
        {
            money.developerRevenue += amount;
            totalSpendWelfare += (amount ) * baseUnit;

        }

        public void issueDefenceCurrency(double amount)
        {
            money.defence += amount;
            totalSpendDefense += (amount ) * baseUnit;
        }

        public void issueHealthCurrency(double amount)
        {
            money.health += amount;
            totalSpendHealth += (amount ) * baseUnit;
        }

        public void issueEducationCurrency(double amount)
        {
            money.education += amount;
            totalSpendEducation += (amount ) * baseUnit;
        }

        public void issueInnovationCurrency(double amount)
        {
            money.innovation     += amount;
            totalSpendInnovation += (amount) * baseUnit;
        }

    }

}
