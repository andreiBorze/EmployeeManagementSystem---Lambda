using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem____Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagementSystem ems = new EmployeeManagementSystem();

            Employee e1 = new Employee("John Doe", 50000, Department.IT);
            Employee e2 = new Employee("Jane Doe", 60000, Department.Sales);
            Employee e3 = new Employee("Bob Smith", 55000, Department.HR);
            Employee e4 = new Employee("John Popescu", 80000, Department.IT);
            Employee e5 = new Employee("Jane Ionescu", 40000, Department.Sales);
            Employee e6 = new Employee("Bob Ionel", 33000, Department.HR);
            ems.AddEmployee(e1);
            ems.AddEmployee(e2);
            ems.AddEmployee(e3);
            ems.AddEmployee(e4);
            ems.AddEmployee(e5);
            ems.AddEmployee(e6);

            Console.WriteLine("Employees with salary greater than 55000:");
            List<Employee> wellPaidEmployees = ems.GetNoOfWellPayedEmployees(55000);
            wellPaidEmployees.ForEach(e => Console.WriteLine(e.ToString()));

            Console.WriteLine("Employees in the IT department:");
            List<Employee> itEmployees = ems.GetEmployeesByDepartment(Department.IT);
            itEmployees.ForEach(e => Console.WriteLine(e.ToString()));

            Console.WriteLine("Employees with the maximum salary:");
            List<Employee> maxSalaryEmployees = ems.GetMaxSalary();
            maxSalaryEmployees.ForEach(e => Console.WriteLine(e.ToString()));

            Console.WriteLine("Employees with the maximum salary in the HR department:");
            List<Employee> maxSalaryHREmployees = ems.GetMaxSalary(Department.HR);
            maxSalaryHREmployees.ForEach(e => Console.WriteLine(e.ToString()));

            Console.WriteLine("Total cost of salaries:");
            Console.WriteLine(ems.GetTotalCost());


            Console.WriteLine("Total cost of salaries in the Sales department:");
            Console.WriteLine(ems.GetCostForDepartment(Department.Sales));

            Console.WriteLine("Increasing salary for Bob Smith by 10%:");
            ems.IncreaseSalary(e3.Id, 10);
            Console.WriteLine(e3.ToString());


            Console.WriteLine("Increasing salary for all employees in the HR department by 5%:");
            ems.IncreaseSalary(Department.HR, 5);
            foreach (Employee e in ems.GetEmployeesByDepartment(Department.HR))
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Employees with the maximum salary in the IT and Sales departments:");
            List<Department> departments = new List<Department>() { Department.IT, Department.Sales };
            List<Employee> maxSalaryITSalesEmployees = ems.GetMaxSalary(departments);
            foreach (Employee e in maxSalaryITSalesEmployees)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();
        }
    }
}
