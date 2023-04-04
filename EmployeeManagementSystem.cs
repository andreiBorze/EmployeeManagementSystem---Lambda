using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem____Lambda
{
    public class EmployeeManagementSystem
    {
        private List<Employee> employees;

        public EmployeeManagementSystem()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Guid id)
        {
            employees.RemoveAll(x => x.Id == id);
        }

        public List<Employee> GetNoOfWellPayedEmployees(double minSalary)
        {
            return employees.FindAll(x => x.Salary > minSalary);
        }

        public List<Employee> GetEmployeesByDepartment(Department department)
        {
            return employees.FindAll(x => x.Department == department);
        }

        public List<Employee> GetMaxSalary()
        {
            var maxSalary = employees.Max(x => x.Salary);
            return employees.FindAll(x => x.Salary == maxSalary);
        }

        public List<Employee> GetMaxSalary(Department department)
        {
            var maxSalary = employees.Where(x => x.Department == department).Max(x => x.Salary);
            return employees.FindAll(x => x.Salary == maxSalary && x.Department == department);
        }

        public double GetTotalCost()
        {
            return employees.Sum(x => x.Salary);
        }

        public double GetCostForDepartment(Department department)
        {
            return employees.Where(x=>x.Department ==department).Sum(x => x.Salary);
        }

        public void IncreaseSalary(Guid id, double percent)
        {
            var employee = employees.Find(x => x.Id == id);

            if(employee == null)
            {
                throw new EmployeeNotFound(id);
            }

            employee.Salary += employee.Salary * percent / 100;
        }


        public void IncreaseSalary(Department department, double percent)
        {
            var employeesInTheDepartament = employees.FindAll(x => x.Department == department);

            employees.Where(x => x.Department == department).ToList().ForEach(d => { d.Salary += d.Salary * percent / 100; });
        }

        public List<Employee> GetMaxSalary(List<Department> departments)
        {
            // V1
            //var employeesInDep = employees.Where(e => departments.Contains(e.Department));
            //var maxSalary = employeesInDep.Max(e => e.Salary);
            //return employeesInDep.Where(e => e.Salary == maxSalary).ToList();

            // V2
            var maxSalaries = departments.Select(d => new { Department = d, MaxSalary = employees.Where(e => e.Department == d).Max(e => e.Salary) });
            return maxSalaries.Select(s => employees.FindAll(x=>x.Department == s.Department && x.Salary == s.MaxSalary)).SelectMany(list => list).ToList();
        }

        public Dictionary<Department, List<Employee>> GetMaxSalaryByDepartment(List<Department> departments)
        {
            return departments.ToDictionary(d => d, d => GetMaxSalary(d));
        }

        public void GetMaxSalaryByDepartment(List<Department> departments, double percent)
        {
            departments.Where(d => employees.Exists(e => e.Department == d)).ToList().ForEach(d => employees.Where(e => e.Department == d).ToList().ForEach(e => e.Salary *= (1 + percent/100)));
        }
    }
}
