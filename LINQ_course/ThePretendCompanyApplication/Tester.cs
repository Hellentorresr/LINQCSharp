﻿using TCPExtentions;
using TCPData;
using System.Linq;
using System.Collections;

namespace ThePretendCompanyApplication
{
    //public class Tester
    //{
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
    //}


    //Part 3 Operators
    //  public class Tester
    //{
    // public static void Main()
    //   {
    //Learning about Sorting operators
    //1. OrderBy
    //     List<Employee> employees = Data.GetEmployees();
    //     List<Department> departments = Data.GetDepartments();

    //Let's get all the records from the employees List and order
    //by deparment id, and adding the department name within the output

    //First coding the query using method syntax
    //OrderBy sort in ascending order by default 1 2 3 
    //var result = employees.Join(departments,
    //    emp => emp.DepartmentId,
    //    dep => dep.Id,
    //        (empl, dept) => new
    //        {
    //            FullName = empl.FirstName + " " + empl.LastName,
    //            employeeDept = dept.Id,
    //            departLongName = dept.LongName
    //        }
    //    ).OrderBy(id => id.employeeDept);

    //First coding the query using method syntax
    //OrderByDescending 3 2 1
    //var result = employees.Join(departments,
    //    emp => emp.DepartmentId,
    //    dep => dep.Id,
    //        (empl, dept) => new
    //        {
    //            FullName = empl.FirstName + " " + empl.LastName,
    //            employeeDept = dept.Id,
    //            departLongName = dept.LongName
    //        }
    //    ).OrderByDescending(id => id.employeeDept);

    //Now sorting by department id and the by the annual salary property in ascending order
    //var result = employees.Join(departments,
    //   emp => emp.DepartmentId,
    //   dep => dep.Id,
    //       (empl, dept) => new
    //       {
    //           FullName = empl.FirstName + " " + empl.LastName,
    //           employeeDept = dept.Id,
    //           departLongName = dept.LongName,
    //           empl.AnnualSalary
    //       }
    //   ).OrderBy(id => id.employeeDept).ThenBy(sal => sal.AnnualSalary);

    //The same query but using query syntax
    //var result = from emp in employees
    //             join dep in departments
    //             on emp.DepartmentId equals dep.Id
    //             orderby emp.DepartmentId, emp.AnnualSalary
    //             select new
    //             {
    //                 FullName = emp.FirstName + " " + emp.LastName,
    //                 employeeDept = dep.Id,
    //                 departLongName = dep.LongName,
    //                 emp.AnnualSalary
    //             };


    //var result = (from emp in employees
    //              join dep in departments
    //              on emp.DepartmentId equals dep.Id
    //              select new
    //              {
    //                  FullName = emp.FirstName + " " + emp.LastName,
    //                  employeeDept = dep.Id,
    //                  departLongName = dep.LongName,
    //                  emp.AnnualSalary
    //              }).OrderBy(sal => sal.AnnualSalary);

    // foreach (var item in result) Console.WriteLine(item);



    //      The grouping operators
    //Group by
    //query the employees collection and group the result by the departmentId propery
    // var result = from emp in employees
    //     group emp by emp.DepartmentId;

    //Using method sintax
    // var groupResult = employees.GroupBy(emp => emp.DepartmentId);


    //foreach (var empGroup in groupResult)
    //{
    //    Console.WriteLine($"Department Id: {empGroup.Key}");

    //    foreach (Employee emp in empGroup)
    //    {
    //        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
    //    }
    //}

    //we have to end all of our queries using query syntax either with
    //the select operator or a group operator 

    //ToLookup method-- works exactly the same way as GroupBy(its execution is deferred)
    //But the difference is that the execution of this query is immediately
    //var groupResult_ = employees.ToLookup(emp => emp.DepartmentId);

    //foreach (var empGroup in groupResult_)
    //{
    //    Console.WriteLine($"Department Id: {empGroup.Key}");

    //    foreach (Employee emp in empGroup)
    //    {
    //        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
    //    }
    //}



    //Quantifier operators -- All Any Contains

    /*The LINQ All Method is used to check whether all the elements of a data 
     * source satisfy a given condition or not. If all the elements satisfy the given 
     * condition, then it returns true else returns false.*/
    //var annualSalaryCompere = 20000;

    //bool isTrueAll = employees.All(e => e.AnnualSalary > annualSalaryCompere);

    //Console.WriteLine(isTrueAll ? $"All employee annual salaries are above {annualSalaryCompere}"
    //    : $"Not all employee annual salaries are above {annualSalaryCompere}");



    //the Any LINQ method
    /*is used to check whether at least one of the elements of a data source satisfies 
     * a given condition or not. If any of the elements satisfy the given condition,
     * then it returns true else returns false. It is also used to check whether 
     * a collection contains some*/
    //bool isTrueAny = employees.Any(e => e.AnnualSalary >= annualSalaryCompere);
    //Console.WriteLine(isTrueAny ? $"At least a salary is equals or greater to {annualSalaryCompere}" 
    //    : $"None of the salaries are below than {annualSalaryCompere}");


    //The contains method
    //we want to be able to assest whether an employee record exists within
    //our collection of employees

    //var employee = employees.FirstOrDefault(em => em.Id == 50);

    //bool constainsEmployee = employee != null && employees.Contains(employee);

    //Console.WriteLine(constainsEmployee ? $"The employee exists its name is: {employee.FirstName}" : "The employee does not exist");


    //  >> Filter Operators OfType and Where <<
    //    ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

    //OfType
    //var stringResult = from s in mixedCollection.OfType<string>()
    //                   select s;

    //foreach ( var mixed in stringResult) Console.WriteLine(mixed);

    //Now let's query all interger values in our ArrayList
    //var listOfIntegers = from integerVals in mixedCollection.OfType<int>()
    //                     select integerVals;

    //foreach (var ints in listOfIntegers) Console.WriteLine(ints);

    //var listOfEmp = from objs in mixedCollection.OfType<Employee>()
    //                    select objs;

    //foreach(var obj in listOfEmp) Console.WriteLine($"Name: {obj.FirstName}");

    //var listOfDepart = from obj in mixedCollection.OfType<Department>()
    //                   select obj;

    //foreach (var dep in listOfDepart) Console.WriteLine($"Department name: {dep.LongName}");


    /*              >>> Element Operators <<<           */
    //1. ElementAt: Returns an element present within a specific index in a collection
    // Or Error: 'Index was out of range. 
    //var employee = employees.ElementAt(8);
    //Console.WriteLine($"Name: {employee.FirstName}");

    //2. ElementAtOrDefault: Same as ElementAt except of the fact that it also returns
    //a default value in case the specific index is out of range
    //var department = departments.ElementAtOrDefault(1);
    ////  Console.WriteLine($"Department name: {department.LongName}");
    //Console.WriteLine(department is null ? "The index does not exist in the list"
    //    : $"Department name: {department.LongName}");


    //Default value from a specific data type: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/default-values

    //LINQ FirstorDefault, Last, LastOrDefault Operators (Method)
    //   List<int> integerList = new() {3, 15, 23, 17, 29, 89};

    //Returns the first element in a sequence that satisfies a specified condition
    // int result = integerList.First(); without any condi, returns the first elem
    //or an error

    // int result = integerList.First(e => e % 2 == 0); //14

    //If we don't want to get the error "InvalidOperationException" when First() does not find matches
    //we can use: Use the FirstorDefault() method to return the first element of a sequence or a default
    //value if element isn't there.

    //when no items in the collection satisfy the given condition this method wont throw an exception
    //but will rather return the default value of the relevant data type in this case 0 cause its integer type
    //int number = integerList.FirstOrDefault(e => e % 2 == 0);
    //if (number != 0) Console.WriteLine(number);
    //else Console.WriteLine("There are no even numbers in the collection");

    //           >> Last Operator <<
    /*The LINQ Last Method in C# is used to return the last element from a data source or from a 
     * collection. If the data source or collection is empty, or if we specified a condition and with 
     * that condition, no matching element is found in the data source, then the LINQ Last method will 
     * throw an InvalidOperationException.*/
    // List<int> integerList = new() { 3, 15, 23, 22, 22, 89 };
    //int lastElement = integerList.Last();
    // int lastElement = integerList.Last(e => e % 2 == 0);//26 trying to find the last elem that satisfy the cond
    // Console.WriteLine(lastElement);

    //   int last = integerList.LastOrDefault(e => e == 50);
    //  Console.WriteLine(last);//without any exception, but returns 0

    //The single operator is used to return the single element of the collection or sequence. Or it returns
    //the single element which specifies the given condition. IF we dont pass any condtion to this method
    //and there is more than one element or zero element in the collection an invalid operation exception
    //will be throw
    // int single = integerList.Single();// ERROR
    //   int single = integerList.Single(e => e == 89);
    // Console.WriteLine(single);

    //Single or default
    //   int singleOrDe = integerList.SingleOrDefault();//System.InvalidOperationException:Sequence contains more than one element
    #region solvingProblem
    //NOT NEEDED ANYMORE
    // fizzBuzz(15);

    //var s = new NotesStore();
    //s.AddNote("active","name");
    //s.AddNote("active", "second");
    //s.AddNote("completed", "third");
    //s.AddNote("active", "Second grade");

    //var list = s.GetNotes("active");

    ////Console.WriteLine(list.Find(e => e == "name"));

    //foreach (var item in list) Console.WriteLine(item);

    #endregion solvingProblem
    //  }

    //static void FizzBuzz(int n)
    // {
    //        for (int i = 1; i <= n; i++)
    //        {
    //            if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
    //            if (i % 3 == 0 && i % 5 != 0) Console.WriteLine("Fizz");
    //            if (i % 5 == 0 && i % 3 != 0) Console.WriteLine("Buzz");
    //            if (i % 3 != 0 && i % 5 != 0) Console.WriteLine(i);
    //        }
    // }
    // }

    //public class NotesStore
    //{
    //    private readonly Dictionary<string, List<string>> notesByState;
    //    private readonly string[] validStates = { "completed", "active", "others" };

    //    public NotesStore()
    //    {
    //        notesByState = new Dictionary<string, List<string>>();
    //    }

    //    public void AddNote(string state, string name)
    //    {
    //        if (string.IsNullOrEmpty(name))
    //        {
    //            throw new ArgumentException("Name cannot be empty");
    //        }

    //        if (string.IsNullOrEmpty(state) || Array.IndexOf(validStates, state.ToLower()) == -1)
    //        {
    //            throw new ArgumentException($"Invalid state: {state}");
    //        }

    //        state = state.ToLower();

    //        if (!notesByState.ContainsKey(state))
    //        {
    //            notesByState[state] = new List<string>();
    //        }

    //        notesByState[state].Add(name);
    //    }

    //    public List<string> GetNotes(string state)
    //    {
    //        state = state.ToLower();

    //        if (!notesByState.ContainsKey(state))
    //        {
    //            throw new ArgumentException($"Invalid state: {state}");
    //        }
    //        else
    //        {
    //            return notesByState[state].ToList();
    //        }
    //    }
    //}

    /* Part 4  More LINQ Operators*/
    public class Test
    {
        public static void Main() 
        {
            //  Transforming data using LINQ's queries
           List<Employee> employeeList = Data.GetEmployees();
           List<Department> departmentList = Data.GetDepartments();

            //equality operator 
            //SequenceEquals
            //Use case: we want to compare to lists of data and we want to know if these tho lists contains elements
            // of equal value and each ele of the relevant list are stored in the same order
            //var integerList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var integerListTwo = new List<int>() { 1, 2, 3, 4, 5, 6 };

            //var boolSequenceEqual = integerList.SequenceEqual(integerListTwo);
            //  Console.WriteLine(boolSequenceEqual);// returns True

            //now using our own datatype
            //var employeeListCompare = Data.GetEmployees();
            //bool boolEmp = employeeList.SequenceEqual(employeeListCompare, new Utilities());
            // Console.WriteLine(boolEmp);//false, because we need to tell the compiler how to stablish equality between objects

            //now using our method to compare
            //var employeeListCompare = Data.GetEmployees();
            //bool boolEmp = employeeList.SequenceEqual(employeeListCompare, new Utilities());
            //Console.WriteLine(boolEmp); //true


            //          >> The concatenation operator <<
            //Concat
            //var integerList = new List<int>() { 1, 2, 3, 4, 5 };
            //var integerList2 = new List<int>() { 6, 7, 8, 9, 10};

            //IEnumerable<int> integerListConcat = integerList.Concat(integerList2);  
            //foreach (var integer in integerListConcat)Console.WriteLine(integer);

            //another example
            // List<Employee> employeesList2 = new() { new Employee { Id = 6, FirstName = "Hellen", LastName = "Torres", AnnualSalary = 10000, IsManager = true, DepartmentId = 3 } };

            //var UpdatingEmpList = employeeList.Concat(employeesList2);

            // foreach (var ele in UpdatingEmpList) Console.WriteLine(ele.FirstName);

            //    >> Aggregate operators: Aggregate, Avarage, Count, Sum, Max <<

            // 1. Aggregate Operator, we can perform a custom operation on values within a collection
            //var integerList = new List<int>() { 1, 2, 3, 4, 5 };
            //var integerList2 = new List<int>() { 6, 7, 8, 9, 10 };

            //requirement: total annual salaries and also include the addition of an appropirate annual
            //salary bunes in the final results
            // the Aggregate function takes an initial value for the accumulator (0 in this case),
            //and a lambda function that defines how the accumulation should occur
            //decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (accumulator, employeeObj) =>
            //{
            //    var bonus = (employeeObj.IsManager) ? 0.04m : 0.02m;

            //    // Calculate the annual salary with the bonus and add it to the running total
            //    return accumulator + (employeeObj.AnnualSalary + (employeeObj.AnnualSalary * bonus));
            //});

            //Console.WriteLine($"Total Annual Salary of all employees (including bonus): {totalAnnualSalary}");


            //Avarage operator: is used to calculate the average of numeric values from the collection on which it is applied.
            //This Average method can return nullable or non-nullable decimal, float, or double values.
            //decimal avarageSalary = employeeList.Average(s => s.AnnualSalary);
            //Console.WriteLine(avarageSalary);

            //returning a string
            //string data = employeeList.Aggregate("Employee annual salaries: (Including bunus): ", (str, empl) =>
            //{
            //    decimal bonus = (empl.IsManager) ? 0.04m : 0.02m;
            //    return str += $"{empl.FirstName}{empl.LastName} - {empl.AnnualSalary + (empl.AnnualSalary * bonus)}, ";

            //}, s => s[..^2]     //once the string is return this slice notation is excluding the last two characters
            //);

            //Console.WriteLine(data);

            //           >> Avarage aggregate operator <<
            //Calculates the average of the numeric items in the collection
            //decimal avgSalary = employeeList.Average(emp => emp.AnnualSalary);
            //Console.WriteLine($"Average annual salary: {avgSalary}");

            //Calculate the average salary for all employees in the technology department
            //method chaining
            //decimal avgSalaryTechDep = employeeList.Where(e => e.DepartmentId == 1).Average(emp => emp.AnnualSalary);
            //Console.WriteLine($"Average Annual Salary (Technology Department): {avgSalaryTechDep}");

            //Count operator, counting how many employees we have in the collection of employees
            // int totalEmployees = employeeList.Count();
            // Console.WriteLine(totalEmployees);

            //Count with a condition
            //int totalEmployees = employeeList.Count(e => e.DepartmentId == 3);
            //Console.WriteLine($"Number of Employees (Technology Department): {totalEmployees}");


            //          >>  Sum aggregate operator:  Calculate total(sum) value of the collection
            //decimal totalAnnualSalaries = employeeList.Sum(sal => sal.AnnualSalary);
            //Console.WriteLine($"Total Annual Salaries: {totalAnnualSalaries}");

            //          >>  Max aggregate operator:  Finds the largest value in the collection.
            //decimal highesAnnualSal = employeeList.Max(sal => sal.AnnualSalary);
            //Console.WriteLine($"Highest Annual Salary: {highesAnnualSal}");

            //          >> Generation Operators - DefaultIfEmpty, Empty, Range, Repeat <<
            //1. DefaultIfEmpty: When applied to an empty sequence, generate a default element within a sequence
            //we can use this operator to return a new IEnumerable collection 
            //List<int> intList = new();
            //var newList = intList.DefaultIfEmpty();
            //Console.WriteLine(newList.ElementAt(0)); //elementAt to check if the collection is  empty, returns the default vaue of 0

            //now testing this method with a list
            //List<Employee> employees = new ();
            //var newList = employees.DefaultIfEmpty(new Employee { Id = 0});
            //var result = newList.ElementAt(0);

            //if(result.Id == 0) Console.WriteLine("The list is empty"); 

            // The Empty operator: 	Returns an empty sequence of values and is the most simplest generational operator
            //we can use this method to generate a new empty collection
            //The empty method is not an extension method of IEnumerable or IQueryble like other linq methods
            //it is a static method included in the Enumerable class
            //  IEnumerable<Employee> emptyEmployeeList = Enumerable.Empty<Employee>(); but i have to cast it to a list because this IEnumerable does not come with CRUD methods
            //List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();

            //emptyEmployeeList.Add(new Employee { Id = 7, FirstName = "Dan", LastName = "Brown" });

            //foreach (var item in emptyEmployeeList) Console.WriteLine($"{item.FirstName} {item.LastName}");

            // >> Range operator: Generates a collection having a sequence of integers or numbers
            // we can use this method to to return a collection of values that are within a specific range
            //var intCollection = Enumerable.Range(25,20); // from 25 to 44
            //foreach ( var integer in intCollection) Console.WriteLine( integer);

            // Repeat operator: Generates a sequence containing repeated values of a specific length
            //let's say we want to generate a collection of a specified amount of elements where a value
            //for each element in the collection is repeated
            //var strCollection = Enumerable.Repeat("Placeholder", 10);
            //foreach ( var val in strCollection ) Console.WriteLine( val ); //"Placeholder" gets print 10 times

            //Set Operators - Distinct, Except, Intersect, Union
            //Distinct
            //IEnumerable<string> listOfStr = new List<string>() { "Meghan", "Hellen", "Miguel", "Meghan" };

            //var noRepeatValFilter = listOfStr.Distinct().ToList();//we will get only distict values returned
            //foreach (var str in noRepeatValFilter) Console.WriteLine(str);

            //List<int> list = new() { 1, 2 , 3, 4 , 4 ,5, 6, 6, 7, 8, 9 , 7 };
            //var intFilterList = list.Distinct().ToList();
            //foreach(var item in intFilterList) Console.WriteLine(item);

            //let's say we have two collections of a specific type and we want to return elements with with values
            // in our first collection that are not equal to any of the values of elements inour second collection
            //Except operator
            //The Except() method requires two collections. It returns a new collection with elements from the first
            //collection which do not exist in the second collection (parameter collection). Except extension method doesn't
            //return the correct result for the collection of complex types.

            // var integerList = new List<int>() { 1, 2, 3, 4, 5 };
            // var integerList2 = new List<int>() { 4, 6, 7, 8, 9, 10, 5, 1, };

            //var result = integerList.Except(integerList2);
            //foreach ( var val in result)Console.WriteLine(val); // = 2,1 //returns all the elems that don't exist in list 2

            //In order to make the right comperizon between 2 objects
            //we have to tell the compiler how to compare employee objects when determining if one employee obj
            //is equal to another employee obj, we can use our class Utilities which implements the IEqualityComparer<Employee>
            //List<Employee> employeeList2 = new()
            //{
            //    new Employee
            //    {
            //        Id = 1,
            //        FirstName = "Bob",
            //        LastName = "Jones",
            //        AnnualSalary = 60000.3m,
            //        IsManager = true,
            //        DepartmentId = 2
            //    },
            //    new Employee
            //    {
            //        Id = 3,
            //        FirstName = "Douglas",
            //        LastName = "Roberts",
            //        AnnualSalary = 40000.2m,
            //        IsManager = false,
            //        DepartmentId = 1
            //    },
            //    new Employee
            //    {
            //        Id = 5,
            //        FirstName = "Craig",
            //        LastName = "Laurence",
            //        AnnualSalary = 20000.2m,
            //        IsManager = false,
            //        DepartmentId = 1
            //    },
            //    new Employee
            //    {
            //        Id = 6,
            //        FirstName = "Elizabeth",
            //        LastName = "Tate",
            //        AnnualSalary = 85000,
            //        IsManager = true,
            //        DepartmentId = 1
            //    }
            //};

            //var results = employeeList.Except(employeeList2, new Utilities()); //passing the Utilities class
            //foreach (var val in results) Console.WriteLine(val.FirstName); // =  Sarah and Jane

            // >> Intersect operator
            //LINQ Intersect operator is used to find common elements between two sequences (collections).
            //Intersect opertor comes under Set operators category in LINQ Query operators. For example,
            //we have two collections A = { 1, 2, 3 } and B = { 3, 4, 5 }. Intersect operator will find common
            //elements in both sequences.
            //var resultIntersct = employeeList.Intersect(employeeList2, new Utilities());
            //foreach (Employee emp in resultIntersct)Console.WriteLine(emp.FirstName + " " + emp.LastName);//Bob and Douglas


            //      >>Union operator:
            /*LINQ Union operator is used for finding unique elements between two sequences (Collections). For example, suppose 
             we have two collections A = { 1, 2, 3 }, and B = { 3, 4, 5 }. Union operator will find unique elements in both sequences.*/
            //var resultUnion = employeeList.Union(employeeList2, new Utilities());//we need to tell the compiler how to perform the comperison
            //foreach (var result in resultUnion)Console.WriteLine(result.FirstName);

            //Partitioning Operators - Skip, SkipWhile, Take, TakeWhile

            //The LINQ Skip Method in C# is used to skip or bypass the first n number of elements from a data source or sequence
            //and then returns the remaining elements from the data source as output.

            //var results = employeeList.Skip(2);
            //foreach (var item in results) Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10}");

            //SkipWhile
            //The SkipWhile() method in LINQ is another extension method that is used to skip elements from the beginning
            //of a sequence while a specified condition is true and returns the remaining elements. The condition is defined
            //using a predicate function that takes an element as input and returns a Boolean value.
            // employeeList.Add(new Employee { Id = 5, FirstName = "Sam", LastName = "Davis", AnnualSalary = 100000.0m });

            //var results = employeeList.SkipWhile(e => e.AnnualSalary > 50000);
            //foreach (var item in results)
            //    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,10}");

            /*The LINQ >> Take() operator <<  is used to return the values from the given data structure. It takes an integer 
            value as a parameter that represents the total number of elements to be retrieved from the given data structure.
             */
            //var results = employeeList.Take(2);
            //foreach (var item in results)
            //    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10}");

            // TakeWhile
            /*The LINQ TakeWhile Method in C# is used to fetch all the elements from a data source or a sequence or 
             * a collection until a specified condition is true.*/
            //employeeList.Add(new Employee { Id = 5, FirstName = "Sam", LastName = "Davis", AnnualSalary = 100000 });

            //var results = employeeList.TakeWhile(e => e.AnnualSalary > 50000);
            //foreach (var item in results)
            //    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,10}");



            //      >> Conversion Operators - ToList, ToDictionary, ToArray <<
            //ToList
            //This query returs a generic IEnumerable collection, and we're attempting to assign an inumerable to a
            //var type generic list, so we have to wrap the query in brackest and then call the toList method
            //List<Employee> results = from emp in employeeList
            //                       where emp.AnnualSalary > 50000
            //                       select emp;
            //List<Employee> results = (from emp in employeeList
            //                        where emp.AnnualSalary > 50000
            //                        select emp).ToList(); //Like this, but the query is executed immediately

            //foreach (var item in results)
            //    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,10}");



            //            >> To Dictionary <<
            //If we want to convert an IEnumerable collection returned from a query to a Dictionary
            //We can apply the toDictionary operator
            Dictionary<int, Employee> dictionary = (from emp in employeeList
                                                    where emp.AnnualSalary > 50000
                                                    select emp).ToDictionary(e => e.Id);

            foreach (var key in dictionary.Keys)
                Console.WriteLine($"Key: {key}, Value: {dictionary[key].FirstName} {dictionary[key].LastName}");


        }
    }
}
