using TCPExtentions;
using TCPData;
using System.Linq;

namespace ThePretendCompanyApplication
{
    public class Tester
    {
        //static void Main()
        //{
            // List<Employee> employees = Data.GetEmployees();//Passing the data from Data.cs

            //Through the magic of extension methods we should be able to see the fiter method
            // appear in the intellisense drp-down list when we add the Dot after the
            //employees variable, of course we have to add the TCPExtention namespace first
            //this filterEmployees var is going to stored the list that Filter is going to return
            // only one parm is required which is the Func param, why because this is how
            //Extension methods work, the consumer of the code IE the calling client code does not
            //need to pass the first pararm which is the T list, cause is automatically handle behind the scenes
            //by default the first parm is the object on which the relevent extention method in invoked
            //now we have to create the method that will tell the filter method how we want the list filtered
            //Lambda expression
            //  var filterEmployees = employees.Filter(emp => !emp.IsManager);//a condition
            //var filterEmployees = employees.Filter(emp => emp.AnnualSalary < 50000); // a different condition

            //foreach (var employee in filterEmployees)
            //{
            //    Console.WriteLine($"Firs name: {employee.FirstName}");
            //    Console.WriteLine($"Is manager: {employee.IsManager}");
            //}
            //Console.ReadKey();


            //Doing the same thing but with another datatype for the T List
            //List<Department> departmentList = Data.GetDepartments();//the data

            ////The point of trying different condition for the filter delegate method is to show
            ////the flexibility that the conbination of extension methods and Lambda expressions create
            ////  var departments = departmentList.Filter(dep => dep.ShortName == "HR" || dep.ShortName == "FN"); 
            //var departments = departmentList.Filter(dep => dep.Id > 1); //

            //foreach (Department department in departments)
            //{
            //    Console.WriteLine(department.ShortName);
            //}
            //Console.ReadKey();


            //Now lets learn how to use  LINQ "Language-Integrated Query", to replace our custom filter method
            //List<Employee> employeeList = Data.GetEmployees();
            //List<Department> departmentList = Data.GetDepartments();

            // var filteredDepartments = departmentList.Where(dept => dept.ShortName == "TE" || dept.ShortName == "HR");

            //Linq also privedes us with a SQL like query syntax, for example if we want to produce
            //a query result by joining selected fields, we can use Link query syntax to perform our inner join operation
            //on this 2 collections of data 
            //var result = from emp in employeeList
            //             join dept in departmentList
            //             on emp.DepartmentId equals dept.Id
            //             select new
            //             {
            //                 emp.FirstName,
            //                 emp.LastName,
            //                 AnnualSalary = emp.AnnualSalary,
            //                 Manager = emp.IsManager,
            //                 Department = dept.LongName
            //             };


            //foreach( var emp in result )
            //{
            //    Console.WriteLine($"Full name: {emp.FirstName} {emp.LastName}, is Manager: {emp.Manager}. Department: {emp.Department}" );
            //}

            ////Using the avarage extention method syntax, cause some func in Linq does not have a 
            ////query syntax counterpart
            //var averageAnnualSalary = result.Average(av => av.AnnualSalary);
            //var highestAnnualSalary = result.Max(sal => sal.AnnualSalary);
        //}

        //second part of the course- Linq examples 1
        //static void Main()
        //{
            //List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();

            //   Select and Where method syntax, both return a object which allows to chain them
            // var result = employees.Select(e => new
            // {
            //  FullName = e.FirstName + " " + e.LastName,
            //  e.AnnualSalary
            // }).Where(list => list.FullName.Contains("Douglas"));

            //// Console.WriteLine(result.First().FullName+" "+result.First().AnnualSalary);
            //foreach (var empl in result) Console.WriteLine($"{empl.FullName, -20} {empl.AnnualSalary,10}");


            //Query syntax 
            //var result = from emp in employees
            //             where emp.AnnualSalary >= 50000
            //             select new                      {
            //                 FullName = emp.FirstName + " " + emp.LastName,
            //                 emp.AnnualSalary
            //             };

            //Console.WriteLine("---");

            //foreach (var empl in result) Console.WriteLine($"{empl.FullName,-20} {empl.AnnualSalary,10}");

            //Implementing the custom extensio method GetHighSalaryEmp
            //List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();

            //var result = from emp in employees.GetHighSalaryEmp()
            //    select new
            //    {
            //        FullName = emp.FirstName + " " + emp.LastName,
            //        emp.AnnualSalary
            //    };

            //employees.Add(new Employee { 
            //    Id=5, FirstName = "Sam",
            //    LastName="Davis",
            //    AnnualSalary = 100000.20m, 
            //    IsManager = true,
            //    DepartmentId = 2});

            //    Console.WriteLine("---");

            //foreach(var item in result)Console.WriteLine(item);

            //Console.WriteLine("---");



            //Imediate execution  example
            //For us to use the ToList() convertion method,
            //we first need to wrap the relevant query in ()
            //with this we're executing the query immediately at the line of code where
            //the query is located
            //List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();

            //var result = (from emp in employees.GetHighSalaryEmp()
            //             select new
            //             {
            //                 FullName = emp.FirstName + " " + emp.LastName,
            //                 emp.AnnualSalary
            //             }).ToList();

            //as we can see in the console this new employee was not added to the list
            //this proves that the query has executed inmediately
            //employees.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000.20m,
            //    IsManager = true,
            //    DepartmentId = 2
            //});

            //Console.WriteLine("---");

            //foreach (var item in result) Console.WriteLine(item);

            //Console.WriteLine("---");

            //////////////////////////////////////////////////////////////////////////////////////
            //// Join Operation Example - Method Syntax     --INNER JOIN
            //performing an inner join on two inumerable collections using a link query
            //and in this specific use case we need to include a descriptive department name in 
            //our results desplayed to the user
            //One department many employees relationship

            //List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();

            // Join Operation Example - Query Syntax
            //the fist parm is the collection we want to join (employees)
            //var result = departments.Join(employees,
            //    deparmentId => deparmentId.Id, // Outer Key Selector: Extracts department Id
            //    employee => employee.DepartmentId, // Inner Key Selector: Extracts employee DepartmentId
            //        (department, employee) => new   // Result Selector: Creates a new anonymous object
            //        {
            //            FullName = employee.FirstName + " " + employee.LastName,
            //            employee.AnnualSalary,
            //            DepartmentName = department.LongName
            //        }
            //    );

            // Join Operation Example - Query Syntax
            //INNER JOIN: Returns only the rows where there is a match in both tables.
            //In this case if a deparment does not have employees it wont be incluted in the result
            //var result = from dept in departments
            //             join emp in employees
            //             on dept.Id equals emp.DepartmentId
            //             select new
            //             {
            //                 FullName = emp.FirstName + " " + emp.LastName,
            //                 emp.AnnualSalary,
            //                 DepartmentName = dept.LongName
            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
            //}

            //Console.WriteLine("\t\t");

            //LEFT OUTER JOIN
            //Method syntax
            //LINQ GroupJoin
            //If an employee has a department id that does not exist in the Department
            //list that employee will get excluded from the result
            //List<Employee> employees = Data.GetEmployees();
            //List<Department> departments = Data.GetDepartments();

            //var results = departments.GroupJoin(employees,
            //        dep => dep.Id,
            //        emp => emp.DepartmentId,
            //        (dep, employeeGroup) => new
            //        {
            //            employees = employeeGroup,
            //            dep.LongName
            //        }
            //    );


            //LEFT OUTER JOIN
            //Query syntax
            //LINQ GroupJoin
            //If an employee has a department id that does not exist in the Department
            //list that employee will get excluded from the result
            //var results = from dep in departments
            //              join emp in employees
            //              on dep.Id equals emp.DepartmentId
            //              into employeeGroup
            //              select new
            //              {
            //                  employees = employeeGroup,
            //                  dep.LongName
            //              };

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Department name: {item.LongName,-20}");
            //    foreach (var emp in item.employees)
            //    {
            //        Console.WriteLine($"\tEmployee name: {emp.FirstName} {emp.LastName}," +
            //        $" department: {emp.DepartmentId}");
            //    }
            //}
        //}

       
    }

    //Implementing my own deferred functionality
    //public static class EnumerableCollectionExtentionMethods
    //{
    //    public static IEnumerable<Employee> GetHighSalaryEmp(this IEnumerable<Employee> employees)
    //    {
    //        foreach (Employee emp in employees)
    //        {
    //            Console.WriteLine($"Accessing employee: {emp.FirstName} {emp.LastName}");
    //            if (emp.AnnualSalary >= 50000)
    //                yield return emp;
    //        }
    //    }
    //}
}
 