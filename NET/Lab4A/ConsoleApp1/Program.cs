using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Class:  Program.cs
  Author: Mahmood Abdul-Khaliq
  Date:   November 15, 2019

I, Mahmood Abdul-Khaliq, student number #000788833, certify that all code submitted is my own work; 
                           that I have not copied it from any other source.  
                           I also certify that I have not allowed my work to be copied by others.
*/


namespace Lab4A
{
    class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program(); //Used to call to other methods within the main class.

            List<Employee> employeeList = new List<Employee>();

            p.read(employeeList); //Reads the employees.txt file; see the read() method for more information

            p.displayEmployeeList(employeeList); //displays the current employee list. First run means it will show as it is saved.
            p.displayMenu(); //Displays the menu options

            string input = Console.ReadLine(); //User input, taken as a string
            int choice; // Empty int, used in the while statement below for error checking

            //While statement - in place to make sure that initial input is valid
            while (!Int32.TryParse(input, out choice) || Int32.Parse(input) < 1 || Int32.Parse(input) > 6)
            {
                Console.Clear(); //clears the console for user experience                
                p.displayEmployeeList(employeeList);
                Console.WriteLine("\nInvalid input; try again!");
                p.displayMenu();
                input = Console.ReadLine();
            }

            choice = Int32.Parse(input); //Parses the user's integer AFTER error-checking

            //If the user choice is 6, displays an exit message.
            if (choice == 6)
            {
                Console.Clear();
                Console.WriteLine("Thanks for using this application!\nPress any key to continue: ");
                Console.ReadKey();
                Environment.Exit(1);
            }

            //Sorts using Lambda expressions
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1: //Name sort
                        employeeList.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
                        break;
                    case 2: //Employee Number sort
                        employeeList.Sort((emp1, emp2) => emp1.Number.CompareTo(emp2.Number));
                        break;
                    case 3: //Employee Rate sort
                        employeeList.Sort((emp1, emp2) => emp2.Rate.CompareTo(emp1.Rate));
                        break;
                    case 4: //Employee Hours sort
                        employeeList.Sort((emp1, emp2) => emp2.Hours.CompareTo(emp1.Hours));
                        break;
                    case 5: //Employee Gross Pay sort
                        employeeList.Sort((emp1, emp2) => emp2.Gross.CompareTo(emp1.Gross));
                        break;
                    default:
                        break;
                }
                

                //Clears the console and re-prints everything
                Console.Clear();
                p.displayEmployeeList(employeeList);
                p.displayMenu();

                input = Console.ReadLine(); //Re-asks the user for input

                //While statement - in place to make sure that follow-up inputs are valid
                while ((!Int32.TryParse(input, out choice) || Int32.Parse(input) < 1 || Int32.Parse(input) > 6))
                {
                    Console.Clear();
                    p.displayEmployeeList(employeeList);
                    Console.WriteLine("\nInvalid input detected; try again!");
                    p.displayMenu();
                    input = Console.ReadLine();
                }
                choice = Int32.Parse(input); //Parses the user's integer AFTER error-checking
            }


        }

        /// <summary>
        /// This class is used to read data from the employees.txt file
        /// </summary>
        /// <param name="employeeList">A list of Employee objects</param>
        public void read(List<Employee> employeeList)
        {
            //Checks to see if there is an employees.txt file; if not, informs the user and closes the application.
            try
            {
                StreamReader file = new StreamReader("employees.txt"); //Takes the employees.txt file puts it into a StreamReader object called 'file'
                string line; //Empty string - used for each line in employees.txt
                int counter = 0; //Counter used for the following while statement; ensures that only 100 employees are considered
                int errorcounter = 0; //Counter used for error handling


                //Goes through the 'file' object and makes a mini-array per-line. Counter is to be kept at 99 to ensure 100 inputs are the cap.
                while ((line = file.ReadLine()) != null && counter < 99)
                {
                    string[] splitLines = line.Split(','); //Creates an array that has all the contents of each line in employees.txt
                    try
                    {
                        foreach (string splitLine in splitLines)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                splitLines[i] = splitLines[i].Trim(); //Trims loose spaces per piece of content of each line in employees.txt
                            }


                            //All of these 'temp' values assign data to the employee, ordered as it's read in the file
                            string tempName = splitLines[0];
                            int tempNumber = Int32.Parse(splitLines[1]);
                            decimal tempRate = decimal.Parse(splitLines[2]);
                            double tempHours = double.Parse(splitLines[3]);

                            //Appends all of the above data into a new Employee class in the employeeList array
                            Employee tempEmployee = new Employee(tempName, tempNumber, tempRate, tempHours);
                            employeeList.Add(tempEmployee);
                            break;
                        }

                        counter++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid employee data on line " + (errorcounter + 1) + " of employees.txt file; skipping entry.");
                    }
                    errorcounter++;
                }
                file.Close();
            }catch (Exception)
            {
                Console.WriteLine("No employees.txt file found.");
                Console.WriteLine("Exiting application; press any key to continue.");
                Console.ReadKey();
                Environment.Exit(2);
            }
            

        }

        /// <summary>
        /// Displays all of the menu options
        /// </summary>
        public void displayMenu()
        {
            Console.WriteLine("\n1. Sort by Employee Name");
            Console.WriteLine("2. Sort by Employee Number");
            Console.WriteLine("3. Sort by Employee Pay Rate");
            Console.WriteLine("4. Sort by Employee Hours");
            Console.WriteLine("5. Sort by Employee Gross Pay");
            Console.WriteLine("\n6. Exit ");

            Console.Write("\nEnter choice: ");
        }

        //This class is used to display current employeeList arrangement
        public void displayEmployeeList(List<Employee> employeeList)
        {
            Console.WriteLine("Employee Name\t\tNumber\tRate\tHours\tGross Pay");
            Console.WriteLine("-------------\t\t------\t------\t------\t---------");
            foreach (Employee employee in employeeList)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee);
                }
            }
        }

    }
}
