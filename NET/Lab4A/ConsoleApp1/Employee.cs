using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Class:  Employee.cs
  Author: Mahmood Abdul-Khaliq
  Date:   November 15, 2019

I, Mahmood Abdul-Khaliq, student number #000788833, certify that all code submitted is my own work; 
                           that I have not copied it from any other source.  
                           I also certify that I have not allowed my work to be copied by others.
*/

namespace Lab4A
{
    /// <summary>
    /// This class creates an Employee
    /// An Employee has a Name, Number, Rate, Hours and Gross Pay associated with them
    /// The Gross Pay is calculated from the Hours and Rate given; if over 40 hours are
    /// worked within the week, an extra 50% of their Rate is given as overtime pay.
    /// </summary>
    internal class Employee
    {
        
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public double Hours { get; set; }
        public decimal Gross { get; private set; }

        /// <summary>
        /// Creates an Employee object
        /// </summary>
        /// <param name="name">The name of the employee</param>
        /// <param name="number">The employee number/ID</param>
        /// <param name="rate">The hourly rate of the employee</param>
        /// <param name="hours">The hours the employee has worked this week</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;

            //This calculates gross pay and overtime pay; any hours above 40 are given a 1.5x pay increase.
            if (hours > 40)
            {
                Gross = (rate * 40) + (rate * ((decimal)hours - (decimal)40) * (decimal)1.5);
            }
            Gross = rate * (decimal)hours;
        }

        /// <summary>
        /// Sets the hourly wage of the employee; used instead of
        /// default setter because a rate recalculation is required.
        /// </summary>
        /// <param name="rate">Employee's hourly wage/rate</param>
        public void setRate(decimal rate)
        {
            Rate = rate;
            //Recalculates gross pay due to adjustment in rates
            if (Hours > 40)
            {
                Gross = (rate * 40) + (rate * ((decimal)Hours - (decimal)40) * (decimal)1.5);
            }
            else Gross = rate * (decimal)Hours;
        }

        /// <summary>
        /// Overrides the ToString function to show valid stats of the employee
        /// </summary>
        /// <returns>A modified ToString value with employee name, number, rate, hours and gross pay</returns>
        public override string ToString()
        {
            //return Name + "\t\t" + Number + "\t" + Rate + "\t" + Hours + "\t" + Gross;
            return $"{Name}\t\t{Number}\t{Rate:F2}\t{Hours:F1}\t{Gross:F2}";
        }
        
    }
}