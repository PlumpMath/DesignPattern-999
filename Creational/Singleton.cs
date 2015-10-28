using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Creational
{
     public class SingleTon
     {
         public string Name { get; set; }

         private static SingleTon _instance;

         public SingleTon()
         {
             this.Name = "this is singleton";
         }

         public void Demonstrate()
         {
             var instance = SingleTon.GetInstance();

             Console.WriteLine($"Creating Instance with Name {instance.Name}");

             Console.WriteLine("changing the name to Test 1 and creating new instance..");

             instance.Name = "Test 1";

             var inst2 = SingleTon.GetInstance();

             Console.WriteLine($"New object Name is {inst2.Name}");
         }
         public static SingleTon GetInstance()
         {
             return _instance ?? (_instance = new SingleTon());
         }
     }
}
