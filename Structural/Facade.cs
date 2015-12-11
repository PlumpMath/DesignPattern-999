using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
  public class  Facade
    {
      public void StartJogging()
      {
          Console.WriteLine("Start Jogging");
        
            var wifi = new Wifi("running wifi");

          Console.WriteLine("started wifi for jogging");

          RunningTIme.StartRunning();
          Console.WriteLine("start runnning...");
      }
    }


    public class Wifi
    {
        public string Name { get; set; }

        public Wifi(string Name)
        {
            this.Name= Name;
        }
    }

    public static class RunningTIme
    {
        public static string StartRunning()
        {
            return "Running";
        }

    }
}
