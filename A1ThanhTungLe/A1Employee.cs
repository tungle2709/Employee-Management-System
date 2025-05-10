using System;
using System.Collections.Generic;
using System.Linq;
using A1ThanhTungLe.Employees;
using A1ThanhTungLe.Display;

/*
 * Full name: Thanh Tung Le
 * Student ID : 991751027
 * Class: 1251_93642
 */

namespace A1ThanhTungLe.A1AllFunctions
{
    //Static class so I dont need to create an object to call it
    public static class A1Employee
    {
        private static int nextEmployeeId = 1;

        //Add Employee Method
        public static void AddEmployee(List<Employee> employees)
        {
            //Set value for the nextEmployeeId that equal to the max ID value in the list plus 1
            if (employees.Count > 0)
            {
                nextEmployeeId = employees.Max(e => e.EmployeeId) + 1;
            }

            Console.Clear();
            Console.WriteLine("Add New Employee:\n");
            Console.WriteLine("\t1 - Add Hourly Employee");
            Console.WriteLine("\t2 - Add Commission Employee");
            Console.WriteLine("\t3 - Add Salaried Employee");
            Console.WriteLine("\t4 - Add Salary Plus Commission Employee");
            Console.WriteLine("\t5 - Back to Main Menu");

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    CreateHourlyEmployee(employees);
                    EmployeeDisplay.DisplayHourlyEmployees(employees);
                    break;
                }
                else if (choice == "2")
                {
                    CreateCommissionEmployee(employees);
                    EmployeeDisplay.DisplayCommissionEmployees(employees);
                    break;
                }
                else if (choice == "3")
                {
                    CreateSalariedEmployee(employees);
                    EmployeeDisplay.DisplaySalariedEmployees(employees);
                    break;
                }
                else if (choice == "4")
                {
                    CreateSalaryPlusCommissionEmployee(employees);
                    EmployeeDisplay.DisplaySalaryPlusCommissionEmployees(employees);
                    break;
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            Console.WriteLine("New Employee Added.\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Use for Create types of employee and set the value for each type of employees
        private static void CreateHourlyEmployee(List<Employee> employees)
        {
            var employee = new HourlyEmployee();
            Console.Write("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter Hourly Wage: ");
            employee.HourlyWage = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Hours Worked: ");
            employee.HoursWorked = int.Parse(Console.ReadLine());

            employee.EmployeeId = nextEmployeeId++;
            employees.Add(employee);
        }

        private static void CreateCommissionEmployee(List<Employee> employees)
        {
            var employee = new CommissionEmployee();
            Console.Write("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter Gross Sales: ");
            employee.GrossSales = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Commission Rate (%): ");
            employee.CommissionRate = decimal.Parse(Console.ReadLine()) / 100;

            employee.EmployeeId = nextEmployeeId++;
            employees.Add(employee);
        }

        private static void CreateSalariedEmployee(List<Employee> employees)
        {
            var employee = new SalariedEmployee();
            Console.Write("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter Weekly Salary: ");
            employee.WeeklySalary = decimal.Parse(Console.ReadLine());

            employee.EmployeeId = nextEmployeeId++;
            employees.Add(employee);
        }

        private static void CreateSalaryPlusCommissionEmployee(List<Employee> employees)
        {
            var employee = new SalaryPlusCommissionEmployee();
            Console.Write("Enter Name: ");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter Weekly Salary: ");
            employee.WeeklySalary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Gross Sales: ");
            employee.GrossSales = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Commission Rate (%): ");
            employee.CommissionRate = decimal.Parse(Console.ReadLine()) / 100;

            employee.EmployeeId = nextEmployeeId++;
            employees.Add(employee);
        }

        //Edit Employee Method
        public static void EditEmployee(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("\t2 - Edit Employee\n");

            if (employees.Count == 0) // If the length of employees list = 0, then No employee that we can edit
            {
                Console.WriteLine("No employees to edit.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("Select Employee Type to Edit:");
            Console.WriteLine("\t1 - Edit Hourly Employee");
            Console.WriteLine("\t2 - Edit Commission Employee");
            Console.WriteLine("\t3 - Edit Salaried Employee");
            Console.WriteLine("\t4 - Edit Salary Plus Commission Employee");
            Console.WriteLine("\t5 - Back to Main Menu");

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    EditEmployeeByType<HourlyEmployee>(employees, "Hourly Employee");
                    break;
                }
                else if (choice == "2")
                {
                    EditEmployeeByType<CommissionEmployee>(employees, "Commission Employee");
                    break;
                }
                else if (choice == "3")
                {
                    EditEmployeeByType<SalariedEmployee>(employees, "Salaried Employee");
                    break;
                }
                else if (choice == "4")
                {
                    EditEmployeeByType<SalaryPlusCommissionEmployee>(employees, "Salary Plus Commission Employee");
                    break;
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        //Edit Employee Method and use generic to define what type of that employee
        private static void EditEmployeeByType<T>(List<Employee> employees, string employeeType) where T : Employee
        {
            var filteredEmployees = employees.OfType<T>().ToList();

            if (filteredEmployees.Count == 0)
            {
                Console.WriteLine($"\nNo {employeeType}s found.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Clear();
            Console.WriteLine($"View All {employeeType}s:\n");
            DisplayEmployee(filteredEmployees[0], employees);

            Console.Write("\nEnter Employee ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            Employee employeeToEdit = null;

            foreach (var emp in filteredEmployees)
            {
                if (emp.EmployeeId == id)
                {
                    employeeToEdit = emp;
                    break;
                }
            }

            if (employeeToEdit == null)
            {
                Console.WriteLine($"Employee with ID = {id} not found.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            EditEmployeeDetails(employeeToEdit);
            Console.WriteLine("\nEmployee updated successfully.\n");
            DisplayEmployee(employeeToEdit, employees);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //New input for editing employee
        private static void EditEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"\nEditing Employee: {employee.EmployeeName}\n");

            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName)) employee.EmployeeName = newName;

            if (employee is HourlyEmployee hourlyEmployee)
            {
                Console.Write("Enter new hourly wage: ");
                hourlyEmployee.HourlyWage = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new hours worked: ");
                hourlyEmployee.HoursWorked = int.Parse(Console.ReadLine());
            }
            else if (employee is CommissionEmployee commissionEmployee)
            {
                Console.Write("Enter new gross sales: ");
                commissionEmployee.GrossSales = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new commission rate (%): ");
                commissionEmployee.CommissionRate = decimal.Parse(Console.ReadLine()) / 100;
            }
            else if (employee is SalariedEmployee salariedEmployee)
            {
                Console.Write("Enter new weekly salary: ");
                salariedEmployee.WeeklySalary = decimal.Parse(Console.ReadLine());
            }
        }

        //Delete Employee Method
        public static void DeleteEmployee(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("\t3 - Delete Employee\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to delete.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("Select Employee Type to Delete:");
            Console.WriteLine("\t1 - Delete Hourly Employee");
            Console.WriteLine("\t2 - Delete Commission Employee");
            Console.WriteLine("\t3 - Delete Salaried Employee");
            Console.WriteLine("\t4 - Delete Salary Plus Commission Employee");
            Console.WriteLine("\t5 - Back to Main Menu");

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    DeleteEmployeeByType<HourlyEmployee>(employees, "Hourly Employee");
                    break;
                }
                else if (choice == "2")
                {
                    DeleteEmployeeByType<CommissionEmployee>(employees, "Commission Employee");
                    break;
                }
                else if (choice == "3")
                {
                    DeleteEmployeeByType<SalariedEmployee>(employees, "Salaried Employee");
                    break;
                }
                else if (choice == "4")
                {
                    DeleteEmployeeByType<SalaryPlusCommissionEmployee>(employees, "Salary Plus Commission Employee");
                    break;
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        //Delete Employee Method and use generic to define what type of that employee
        private static void DeleteEmployeeByType<T>(List<Employee> employees, string employeeType) where T : Employee
        {
            var filteredEmployees = employees.OfType<T>().ToList();

            if (filteredEmployees.Count == 0)
            {
                Console.WriteLine($"\nNo {employeeType}s found.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Clear();
            Console.WriteLine($"View All {employeeType}s:\n");
            DisplayEmployee(filteredEmployees[0], employees);

            Console.Write("\nEnter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Employee employeeToDelete = null;

            foreach (var emp in filteredEmployees)
            {
                if (emp.EmployeeId == id)
                {
                    employeeToDelete = emp;
                    break;
                }
            }

            if (employeeToDelete == null)
            {
                Console.WriteLine($"Employee with ID = {id} not found.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            employees.Remove(employeeToDelete);
            Console.WriteLine($"Employee with ID = {id} deleted.\n");
            DisplayEmployee(employeeToDelete, employees);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //View employee Method
        public static void ViewEmployees(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("\n\t4 - View Employee\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("View All Employees:\n");
            EmployeeDisplay.DisplayHourlyEmployees(employees);
            EmployeeDisplay.DisplayCommissionEmployees(employees);
            EmployeeDisplay.DisplaySalariedEmployees(employees);
            EmployeeDisplay.DisplaySalaryPlusCommissionEmployees(employees);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Search employee Method
        public static void SearchEmployee(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("\t5 - Search Employee\n");

            Console.Write("\nEnter name to search: ");
            string keyword = Console.ReadLine().ToLower();

            var results = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.EmployeeName.ToLower().Contains(keyword))
                {
                    results.Add(emp);
                }
            }

            if (results.Count == 0)
            {
                Console.WriteLine("No employees found.\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("\nSearch Results:\n");
            EmployeeDisplay.DisplayHourlyEmployees(results);
            EmployeeDisplay.DisplayCommissionEmployees(results);
            EmployeeDisplay.DisplaySalariedEmployees(results);
            EmployeeDisplay.DisplaySalaryPlusCommissionEmployees(results);
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Display Employee base on the type
        private static void DisplayEmployee(Employee employee, List<Employee> employees)
        {
            if (employee is HourlyEmployee)
            {
                EmployeeDisplay.DisplayHourlyEmployees(employees);
            }
            else if (employee is CommissionEmployee)
            {
                EmployeeDisplay.DisplayCommissionEmployees(employees);
            }
            else if (employee is SalariedEmployee)
            {
                EmployeeDisplay.DisplaySalariedEmployees(employees);
            }
            else if (employee is SalaryPlusCommissionEmployee)
            {
                EmployeeDisplay.DisplaySalaryPlusCommissionEmployees(employees);
            }
        }
    }
}
