using TCPExtentions;
using TCPData;

namespace ThePretendCompanyApplication
{
    public class Tester
    {
        static void Main()
        {
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
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            // var filteredDepartments = departmentList.Where(dept => dept.ShortName == "TE" || dept.ShortName == "HR");

            //Linq also privedes us with a SQL like query syntax, for example if we want to produce
            //a query result by joining selected fields, we can use Link query syntax to perform our inner join operation
            //on this 2 collections of data 
            var result = from emp in employeeList
                         join dept in departmentList
                         on emp.DepartmentId equals dept.Id
                         select new
                         {
                             emp.FirstName,
                             emp.LastName,
                             AnnualSalary = emp.AnnualSalary,
                             Manager = emp.IsManager,
                             Department = dept.LongName
                         };


            foreach( var emp in result )
            {
                Console.WriteLine($"Full name: {emp.FirstName} {emp.LastName}, is Manager: {emp.Manager}. Department: {emp.Department}" );
            }
        }

    }
}
