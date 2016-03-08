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

            var antipatern = new Composite_AntiPattern();
            var pattern = new Composite_Pattern();

            antipatern.Demonstrate();

            Console.WriteLine("now the pattern");
            pattern.Demonstrate();

        }

    }


    #region the PAttern

    public class Composite_Pattern
    {

        public void Demonstrate()
        {
            int goldForKil = 1023;


            var joe = new ProperPerson { Name = "Joe" };
            var tom = new ProperPerson { Name = "Tom" };
            var brian = new ProperPerson { Name = "Brian" };
            var sam = new ProperPerson { Name = "Sam" };
            var bob = new ProperPerson { Name = "Bob" };
            var tommy = new ProperPerson { Name = "tommy" };


            var bandT = new ProperGroup { Memners = new List<Party> { bob, tommy } };

            var developers = new ProperGroup { Name = "Developers", Memners = new List<Party> { joe, tom, brian,bandT } };



            var parties = new ProperGroup { Memners = new List<Party> { developers, sam }  };


            parties.Gold = goldForKil;

          //  parties.Stats();





            Console.ReadKey();
        }
    }




    public class ProperPerson : Party
    {
        public string Name { get; set; }
        public int Gold { get; set; }

        public void Stats()
        {
            Console.WriteLine($"the Person {Name} have Gold:{Gold}");
        }
    }

    public class ProperGroup : Party
    {
        public string Name { get; set; }

        public List<Party> Memners { get; set; }

        public int Gold
        {
            get
            {
                int totalGold = 0;

                foreach (var member in Memners)
                {
                    totalGold += member.Gold;
                }

                return totalGold;
            }

            set
            {
                int eachsplit = value / Memners.Count;
                int leftOver = value % Memners.Count;

                foreach (var member in Memners)
                {
                    member.Gold += eachsplit + leftOver;
                    leftOver = 0;
                    member.Stats();
                }
            }
        }

        public void Stats()
        {
            foreach (var member in Memners)
            {
                member.Stats();
            }
        }
    }

    public interface Party
    {
        int Gold { get; set; }
        void Stats();

    }

    #endregion


    #region anti pattern


    public class Composite_AntiPattern
    {

        public void Demonstrate()
        {
            int goldForKil = 1023;


            var joe = new Person { Name = "Joe" };
            var tom = new Person { Name = "Tom" };
            var brian = new Person { Name = "Brian" };
            var sam = new Person { Name = "Sam" };

            var developers = new Group {Name="Developers" , Memners = new List<Person> {joe,tom,brian } };

            var individuals = new List<Person> { sam };
            var groups = new List<Group> { developers };


            var totalToSPlitBy = individuals.Count + groups.Count;

            var amountForEach = goldForKil / totalToSPlitBy;

            var leftOver =goldForKil % totalToSPlitBy;

            foreach (var individual in individuals)
            {
                individual.Gold = amountForEach + leftOver;
                leftOver = 0;
                individual.Stats();
            }

            foreach (var group in groups)
            {
                var amaountForEachGrouMember = amountForEach / group.Memners.Count;
                var leftOverForGroup = amaountForEachGrouMember % group.Memners.Count;

                foreach (var member in group.Memners)
                {
                    member.Gold = amaountForEachGrouMember + leftOverForGroup;
                    leftOverForGroup = 0;
                    member.Stats();
                }
            }

            Console.ReadKey();
        }
    }



    public class Person 
    {
        public string Name { get; set; }
        public int Gold { get; set; }

        public void Stats()
        {
            Console.WriteLine($"the Person {Name} have Gold:{Gold}");
        }
    }

    public class Group 
    {
        public string Name { get; set; }

        public List<Person> Memners { get; set; }
 
    }
    #endregion 

}
