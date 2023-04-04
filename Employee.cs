using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem____Lambda
{
    public enum Department
    {
        Development,
        Testing,
        HumanResources,
        Maintenance,
        Logistics,
        IT,
        Sales,
        HR
    }
    public class Employee
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }

        public Employee(string name, double salary, Department department)
        {
            Name = name;
            Id = Guid.NewGuid();
            Salary = salary;
            Department = department;
        }

        public override string ToString()
        {
            return $"{Name}, {Department}, salary: {Salary}";
        }
    }
}
