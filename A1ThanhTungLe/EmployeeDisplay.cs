using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using A1ThanhTungLe.Employees;

/*
 * Full name: Thanh Tung Le
 * Student ID : 991751027
 * Class: 1251_93642
 */

namespace A1ThanhTungLe.Display
{
    //I used ConsoleTables to set the column and row to display the tables 
    public static class EmployeeDisplay
    {
        public static void DisplayHourlyEmployees(List<Employee> employees)
        {
            var hourlyEmployees = employees.Where(e => e.GetType() == typeof(HourlyEmployee)).ToList();

            //Set color for the table
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!hourlyEmployees.Any())
            {
                Console.WriteLine("No hourly employees to display.\n");
                return;
            }

            
            Console.WriteLine("\nHourly Employees:");
            var table = new ConsoleTable("Id", "Name", "Hours Worked", "Hourly Wage", "Gross Earnings", "Tax (20%)", "Net Earnings");

            foreach (var emp in hourlyEmployees.OfType<HourlyEmployee>())
            {
                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp.HoursWorked, emp.HourlyWage, emp.GrossEarnings, emp.Tax, emp.NetEarnings);
            }

            table.Write();
            Console.WriteLine();
            //Change the color back
            Console.ResetColor();
        }

        public static void DisplayCommissionEmployees(List<Employee> employees)
        {
            var commissionEmployees = employees.Where(e => e.GetType() == typeof(CommissionEmployee)).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!commissionEmployees.Any())
            {
                Console.WriteLine("No commission employees to display.\n");
                return;
            }

            
            Console.WriteLine("\nCommission Employees:");
            var table = new ConsoleTable("Id", "Name", "Gross Sales", "Commission Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");

            foreach (var emp in commissionEmployees.OfType<CommissionEmployee>())
            {
                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp.GrossSales, (emp.CommissionRate * 100).ToString() + "%", emp.GrossEarnings, emp.Tax, emp.NetEarnings);
            }

            table.Write();
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void DisplaySalariedEmployees(List<Employee> employees)
        {
            var salariedEmployees = employees.Where(e => e.GetType() == typeof(SalariedEmployee)).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            if (!salariedEmployees.Any())
            {
                Console.WriteLine("No salaried employees to display.\n");
                return;
            }

            
            Console.WriteLine("\nSalaried Employees:");
            var table = new ConsoleTable("Id", "Name", "Salary", "Gross Earnings", "Tax (20%)", "Net Earnings");

            foreach (var emp in salariedEmployees.OfType<SalariedEmployee>())
            {
                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp.WeeklySalary, emp.GrossEarnings, emp.Tax, emp.NetEarnings);
            }

            table.Write();
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void DisplaySalaryPlusCommissionEmployees(List<Employee> employees)
        {
            var salaryPlusCommissionEmployees = employees.Where(e => e.GetType() == typeof(SalaryPlusCommissionEmployee)).ToList();

            Console.ForegroundColor = ConsoleColor.Red;
            if (!salaryPlusCommissionEmployees.Any())
            {
                Console.WriteLine("No salary + commission employees to display.\n");
                return;
            }

            
            Console.WriteLine("\nSalary + Commission Employees:");
            var table = new ConsoleTable("Id", "Name", "Salary", "Gross Sales", "Commission Rate", "Gross Earnings", "Tax (20%)", "Net Earnings");

            foreach (var emp in salaryPlusCommissionEmployees.OfType<SalaryPlusCommissionEmployee>())
            {
                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp.WeeklySalary, emp.GrossSales, (emp.CommissionRate * 100).ToString() + "%", emp.GrossEarnings, emp.Tax, emp.NetEarnings);
            }

            table.Write();
            Console.ResetColor();
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
