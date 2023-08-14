using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new();

            Employee employee = new()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new();

            Department department = new()
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }

        // By nature, ArrayList holds a heterogeneous collection of objects. This means that
        // in a single instance of ArrayList, we can store objects of any data type.
        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrayList = new()
            {
                100,
                "Bob Jones",
                2000,
                3000,
                "Bill Henderson",
                new Employee { Id =6,FirstName="Jennifer", LastName="Dale",AnnualSalary =90000, IsManager = true, DepartmentId = 1 },
                new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 },
                new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" },
                new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" },
                new Department { Id = 6, ShortName = "PRD", LongName = "Production" }
            };

            return arrayList;
        }
    }
}
