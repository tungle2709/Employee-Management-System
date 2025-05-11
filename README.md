# Employee-Management-System


This is a simple **Employee Management System** built using C# and .NET 8. It allows users to manage employees, including adding, editing, deleting, viewing, and searching for employees.

## Features

- Add different types of employees:
  - Hourly Employee
  - Commission Employee
  - Salaried Employee
  - Salary Plus Commission Employee
- Edit employee details.
- Delete employees.
- View all employees in a tabular format.
- Search employees by name.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your system.
- Visual Studio 2022 or any compatible IDE.

## How to Run

1. Clone the repository: git clone https://github.com/tungle2709/Employee-Management-System.git cd Employee-Management-System

2. Open the project in Visual Studio 2022.

3. Build the solution:
   - Press `Ctrl + Shift + B` or go to **Build > Build Solution**.

4. Run the application:
   - Press `F5` or go to **Debug > Start Debugging**.

5. Follow the on-screen menu to manage employees.

## Usage Instructions

1. **Add Employee**: Select option `1` from the menu to add a new employee. Choose the type of employee and provide the required details.
2. **Edit Employee**: Select option `2` to edit an existing employee's details.
3. **Delete Employee**: Select option `3` to delete an employee by their ID.
4. **View Employees**: Select option `4` to view all employees in a tabular format.
5. **Search Employee**: Select option `5` to search for employees by name.
6. **Exit**: Select option `6` to exit the application.

## Project Structure

- **Program.cs**: Entry point of the application.
- **A1Employee.cs**: Contains methods for adding, editing, deleting, viewing, and searching employees.
- **Employee.cs**: Defines the `Employee` class and its derived classes (`HourlyEmployee`, `CommissionEmployee`, etc.).
- **EmployeeDisplay.cs**: Handles displaying employees in a tabular format using `ConsoleTables`.

## Sample Data

The application includes sample employees for testing purposes. These are added automatically when the application starts.
