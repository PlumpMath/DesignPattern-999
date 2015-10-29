using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
    public class Adapter : Adaptee, Adaptee.InewFunction
    {
        public string GetNewMEthod()
        {
            return "new-" + OldMethod();
        }
    }


  public class Adaptee
    {

        public string OldMethod()
        {
            return " old funciton's return";
        }


       public interface InewFunction
        {
            string GetNewMEthod();
        }
    }
}
