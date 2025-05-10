/*
 * Full name: Thanh Tung Le
 * Student ID : 991751027
 * Class: 1251_93642
 */

namespace A1ThanhTungLe.Employees
{
    //Enumerate to represent different types of employees
    public enum EmployeeType
    {
        Hourly,
        Commission,
        Salaried,
        SalaryPlusCommission
    }

    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        //Enum Property for Employee Type
        public EmployeeType Type { get; set; }

        public abstract decimal GrossEarnings { get; }

        public decimal Tax
        {
            get { return GrossEarnings * 0.20m; }
        }

        public decimal NetEarnings
        {
            get { return GrossEarnings - Tax; }
        }

        public override string ToString()
        {
            return EmployeeId + "\t" + EmployeeName + "\t" + Type + "\t$" + GrossEarnings.ToString("F2") + "\t$" + NetEarnings.ToString("F2");
        }
    }

    //HourlyEmployee
    public class HourlyEmployee : Employee
    {
        public decimal HourlyWage { get; set; }
        public decimal HoursWorked { get; set; }

        public HourlyEmployee()
        {
            Type = EmployeeType.Hourly;
        }

        public override decimal GrossEarnings
        {
            get
            {
                if (HoursWorked <= 40)
                    return HourlyWage * HoursWorked;
                else
                    return (40 * HourlyWage) + ((HoursWorked - 40) * HourlyWage * 1.5m);
            }
        }
    }

    //Commission Employee
    public class CommissionEmployee : Employee
    {
        public decimal GrossSales { get; set; }
        public decimal CommissionRate { get; set; }

        public CommissionEmployee()
        {
            Type = EmployeeType.Commission;
        }

        public override decimal GrossEarnings
        {
            get { return GrossSales * CommissionRate; }
        }
    }

    //SalariedEmployee
    public class SalariedEmployee : Employee
    {
        public decimal WeeklySalary { get; set; }

        public SalariedEmployee()
        {
            Type = EmployeeType.Salaried;
        }

        public override decimal GrossEarnings
        {
            get { return WeeklySalary; }
        }
    }

    //Salary Plus Commission Employee
    public class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        public decimal WeeklySalary { get; set; }

        public SalaryPlusCommissionEmployee()
        {
            Type = EmployeeType.SalaryPlusCommission;
        }

        public override decimal GrossEarnings
        {
            get { return WeeklySalary + base.GrossEarnings; }
        }
    }
}
