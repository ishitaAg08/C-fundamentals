using System;

namespace C_
{
    //define delegate this will point to a function
    public delegate bool IsPromotable(Employee emp);

    public class Delegates
    {
        public static void UseDelegates()
        {
            List<Employee> employeeList = new List<Employee>();

            employeeList.Add(new Employee() { ID = 101, Name = "Mary", Salary = 5000, Experience = 5 });
            employeeList.Add(new Employee() { ID = 102, Name = "Mike", Salary = 4000, Experience = 4 });
            employeeList.Add(new Employee() { ID = 103, Name = "John", Salary = 6000, Experience = 6 });
            employeeList.Add(new Employee() { ID = 104, Name = "Harry", Salary = 2000, Experience = 3 });

            Employee.PromoteEmployee(employeeList);

            // reference to Promote function
            IsPromotable isPromotable = new IsPromotable(Promote);
            Employee.PromoteEmployeeWithDelegate(employeeList, isPromotable);

            // use lambda expressions - based on delegates
            // At runtime, this expression creates a delegate and point to the function
            // x is an employee object at runtime.
            Employee.PromoteEmployeeWithLambdaExpression(employeeList, x => x.Experience >= 5);

        }

        public static bool Promote(Employee emp)
        {
            if(emp.Experience >=5 )
            {
                return true;
            }
            return false;
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public Employee()
        {
            this.Name = string.Empty;
        }

        // This function promotes the employee on the basis of experience only. Others can have different criterias to promote the emploee.
        // Here comes the use case of delegates
        public static void PromoteEmployee(List<Employee> employees)
        {
            Console.WriteLine("Without delegate:");
            foreach (Employee emp in employees)
            {
                if (emp.Experience >= 5)
                {
                    Console.WriteLine(emp.Name + " promoted");
                }
            }
        }

        // Use delegates to make the function generic for everyone to have their own logic to promote employees.
        // IsEligibleToPromote is a function, delegate is pointing to
        public static void PromoteEmployeeWithDelegate(List<Employee> employees, IsPromotable IsEligibleToPromote)
        {
            Console.WriteLine("With delegate:");
            foreach (Employee emp in employees)
            {
                if (IsEligibleToPromote(emp))
                {
                    Console.WriteLine(emp.Name + " promoted");
                }
            }
        }

        public static void PromoteEmployeeWithLambdaExpression(List<Employee> employees, IsPromotable IsEligibleToPromote)
        {
            Console.WriteLine("With Lambda expression:");
            foreach (Employee emp in employees)
            {
                if (IsEligibleToPromote(emp))
                {
                    Console.WriteLine(emp.Name + " promoted");
                }
            }
        }
    }
}
