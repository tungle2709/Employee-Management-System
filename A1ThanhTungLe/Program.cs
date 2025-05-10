using System;
using System.Collections.Generic;
using A1ThanhTungLe.Employees;
using A1ThanhTungLe.A1AllFunctions;

/*
 * Full name: Thanh Tung Le
 * Student ID : 991751027
 * Class: 1251_93642
 */

namespace A1ThanhTungLe
{
    internal class Program
    {
        //Create a list of Employees that stores all type of employee
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            //Call method Sample() to add employees that i created below
            Sample();

            bool running = true;

            //Menu
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\t\tWelcome to my Assignment1");
                Console.WriteLine("\tDeveloped by Thanh Tung Le - 991751027\n");
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+\n\n");
                Console.WriteLine("\t1 - Add Employee");
                Console.WriteLine("\t2 - Edit Employee");
                Console.WriteLine("\t3 - Delete Employee");
                Console.WriteLine("\t4 - View Employee");
                Console.WriteLine("\t5 - Search Employee");
                Console.WriteLine("\t6 - Exit");

                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("\nEnter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            A1Employee.AddEmployee(employees);
                            validInput = true;
                            Console.Clear();
                            break;

                        case "2":
                            A1Employee.EditEmployee(employees);
                            validInput = true;
                            Console.Clear();
                            break;

                        case "3":
                            A1Employee.DeleteEmployee(employees);
                            validInput = true;
                            Console.Clear();
                            break;

                        case "4":
                            A1Employee.ViewEmployees(employees);
                            validInput = true;
                            Console.Clear();
                            break;

                        case "5":
                            A1Employee.SearchEmployee(employees);
                            validInput = true;
                            Console.Clear();
                            break;

                        case "6":
                            running = false;
                            validInput = true;
                            break;

                        default:
                            Console.WriteLine("\nInvalid input. Please try again.");
                            break;
                    }
                }
            }
        }

        //Sample method that I used for create sample employees
        private static void Sample()
        {
            employees = new List<Employee>
            {
                new HourlyEmployee { EmployeeId = 1, EmployeeName = "Thanh", HoursWorked = 40, HourlyWage = 20m },
                new HourlyEmployee { EmployeeId = 2, EmployeeName = "Tung", HoursWorked = 50, HourlyWage = 15m },
                new HourlyEmployee { EmployeeId = 3, EmployeeName = "Le", HoursWorked = 50, HourlyWage = 20m },

                new CommissionEmployee { EmployeeId = 4, EmployeeName = "Cristiano", GrossSales = 10000m, CommissionRate = 0.20m },
                new CommissionEmployee { EmployeeId = 5, EmployeeName = "Ronaldo", GrossSales = 8000m, CommissionRate = 0.15m },

                new SalariedEmployee { EmployeeId = 6, EmployeeName = "Lionel", WeeklySalary = 800m },
                new SalariedEmployee { EmployeeId = 7, EmployeeName = "Messi", WeeklySalary = 1100m },

                new SalaryPlusCommissionEmployee
                {
                    EmployeeId = 8,
                    EmployeeName = "Killian",
                    WeeklySalary = 500m,
                    GrossSales = 5000m,
                    CommissionRate = 0.10m
                },
                new SalaryPlusCommissionEmployee
                {
                    EmployeeId = 9,
                    EmployeeName = "Mbape",
                    WeeklySalary = 300m,
                    GrossSales = 8000m,
                    CommissionRate = 0.12m
                }
            };
        }
    }
}
