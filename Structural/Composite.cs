using System;
using System.Collections.Generic;
namespace designPatterns.Structural
{
    /*
    Composite DP

        Description: this DP is three like Structure with two elements Leaf - which is the end element which is doing some operations, and Composite which is managing the leaf elements;


    */
   public class Composite
    {
       public void Demonstrate()
       {
           var manager = new Manager();
            
            manager.AddEmployee(new Employee());
            manager.AddEmployee(new Employee());
            manager.AddEmployee(new Employee());

            manager.AddManager(new Manager());


           foreach (var item     in manager.Employees)
           {
               item.ShowHappiness();
           }

           foreach (var mans in manager.Managers)
           {
                mans.ShowHappiness();
           }
        }

    }



    public interface IEmployee
    {
        void ShowHappiness();
    }


    public class  Manager:IEmployee
    {
        public List<IEmployee> Employees = new List<IEmployee>();
        
        public  List<Manager> Managers= new List<Manager>();

        public void AddEmployee(IEmployee employee)
        {
            Employees.Add(employee);
        }

        public void AddManager(Manager manager)
        {
            Managers.Add(manager);
        }

        public void ShowHappiness()
        {
            Console.WriteLine("Manager is Happy");
        }
    }

    public class Employee : IEmployee
    {
        public void ShowHappiness()
        {
            Console.WriteLine("Happy worker");
        }
    }
}
