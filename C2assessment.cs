using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelearningConsole
{
    class C2assessment
    {
        public static void Main()
        {
            /*
            1.	Current Date information:
                a.	Show the current date (1/14/2019)
                b.	Show the date 1 week from today (1/21/2019)
                c.	Indicate the day of week the current date is (Monday, Tuesday, Wednesday… etc.)
            2.	Date properties:
                a.	Indicate if the current date is a weekday or weekend (Weekend or Weekday)
                b.	Indicate if tomorrow is a weekday (True or False)
                c.	Indicate if yesterday was a weekday (True or False)
            3.	Parsing through date ranges
                a.	Assume we get paid on the 1st and 15th of each month 
                b.	Using an employee rate of $48,000 annually
                c.	For the next year show the dates the employee would get paid and what their paycheck would be for each pay period. (Assuming nothing is taken from the employee’s check) 
                    (Pay day: 1/15/2019 - Pay Amount: $2,000; 
                    Pay day: 2/1/2019 - Pay Amount: $2,000; 
                    Pay day: 2/15/2019 - Pay Amount: $2,000; 
                    Pay day: 3/1/2019 - Pay Amount: $2,000;…)
            4.	Manipulating numbers
                a.	On each pay day, we need to take out taxes for the employee
                b.	The tax rate for this employee is 15%
                c.	For the next year show the dates the employee would get paid and what their paycheck would be for each pay period. (Assuming taxes is taken from the employee’s check) 
                    (Pay day: 1/15/2019 - Pay Amount: $2,000 – Take Home Amount: $1,700; 
                    Pay day: 2/1/2019 - Pay Amount: $2,000 - Take Home amount: $1,700; …)
                5.	Manipulating dates
                    a.	Since banks are closed on the weekends we will change the pay date to a weekday if it happens to fall onto a weekend. If so we pay the closest Friday before.
                    b.	For the next year show the dates the employee would get paid and what their paycheck would be for each pay period indicating if it was adjusted because of a weekend. 
                        (Assuming taxes is only taken from the employee’s check) 
                        (Pay day: 5/15/2019 - Pay Amount: $2,000.00 - Take Home Amount: $1,700.00;
                         Pay day Adjusted Because of Weekend: 5/31/2019 - Pay Amount: $2,000.00 - Take Home Amount: $1,700.00;…)
            6.	Extra
                a.	This employee has been working hard and will get a raise in 6 months
                b.	For the next year show the dates the employee would get paid and what their paycheck would be for each pay period indicating if it was adjusted because of a weekend. 
                    After 6 months give the Employee a 10% raise based on their current salary 
                    (Pay day: 7/1/2019 - Pay Amount: $2,000.00 -Take Home Amount: $1,700.00;
                    Pay Increase: $220.00 - Pay day: 7/15/2019 - Pay Amount: $2,200.00 - Take Home Amount: $1,870.00;…)
            */
            Console.WriteLine("1a. " + DateTime.Today.ToShortDateString());
            Console.WriteLine("1b. " + DateTime.Today.AddDays(7).ToShortDateString());
            Console.WriteLine("1c. " + DateTime.Today.DayOfWeek);
            Console.WriteLine();
            Console.WriteLine("2a. Today: " + DayType(DateTime.Today));
            Console.WriteLine("2b. Tomorrow (weekday): " + Weekday(DateTime.Today.AddDays(1)));
            Console.WriteLine("2c. Yesterday (weekday): " + Weekday(DateTime.Today.AddDays(-1)));
            Console.WriteLine();
            Console.WriteLine("3.");
            PayDates(48000, DateTime.Today.AddDays(365));
            Console.WriteLine();
            Console.WriteLine("4.");
            PayDates(48000, DateTime.Today.AddDays(365), 15);
            Console.WriteLine();
            Console.WriteLine("5.");
            PayDates(48000, DateTime.Today.AddDays(365), 15, true);
            Console.WriteLine();
            Console.WriteLine("6.");
            PayDates(48000, DateTime.Today.AddDays(365), 15, true, DateTime.Today.AddMonths(6));
        }

        protected static bool Weekday(DateTime day)
        {
            return (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday) ? false : true;
        }

        protected static string DayType(DateTime day)
        {
            return DayType(Weekday(day));
        }

        protected static string DayType(bool weekday)
        {
            return weekday ? "Weekday" : "Weekend";
        }

        protected static void PayDates(int rate, DateTime stopdate)
        {
            PayDates(rate, stopdate, 0);
        }

        protected static void PayDates(decimal rate, DateTime stopdate, decimal taxRate)
        {
            PayDates(rate, stopdate, taxRate, false);
        }

        protected static void PayDates(decimal rate, DateTime stopdate, decimal taxRate, bool weekdaysOnly)
        {
            PayDates(rate, stopdate, taxRate, weekdaysOnly, DateTime.Today.AddDays(-1));
        }

        protected static void PayDates(decimal rate, DateTime stopdate, decimal taxRate, bool weekdaysOnly, DateTime raiseDate)
        {
            Console.WriteLine("Tax rate: " + taxRate + "%");
            DateTime startdate = DateTime.Today;
            decimal netRate = rate;
            bool applyTax = taxRate > 0;
            while (startdate <= stopdate)
            {
                if (applyTax)
                {
                    netRate = rate - (rate * taxRate / 100);
                }
                if (startdate.Day == 1 || startdate.Day == 15)
                {
                    DateTime payday = startdate;
                    if (weekdaysOnly && !Weekday(payday))
                    {
                        while (!Weekday(payday))
                        {
                            payday = payday.AddDays(-1);
                        }
                        Console.Write("Pay day Adjusted Because of Weekend: " + payday.ToShortDateString());
                    }
                    else
                    {
                        Console.Write("Pay day: " + payday.ToShortDateString());
                    }
                    Console.Write(" - Pay Amount: " + (rate / 24).ToString("C0"));
                    if (applyTax)
                    {
                        Console.Write(" - Take Home Amount: " + (netRate / 24).ToString("C0"));
                    }
                    Console.WriteLine(";");
                }
                startdate = startdate.AddDays(1);
                if (startdate == raiseDate)
                {
                    decimal payIncrease = (rate / 24) * (decimal)0.1;
                    rate += rate * (decimal)0.1;
                    Console.Write("Pay increase: " + payIncrease.ToString("C0") + " - ");
                }
            }
        }
    }
}
