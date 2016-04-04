using System;
using System.Collections.Generic;
using System.Linq;


namespace designPatterns.behaviour
{
    public class Command
    {

        public void Demonstrate()
        {
            ICommand cmd = CommandParses.GetCommand("Qty");
            Console.WriteLine($"show Quantity {cmd.execute()}");

            cmd = CommandParses.GetCommand("Price");
            Console.WriteLine($"show Prices {cmd.execute()}");


            cmd = CommandParses.GetCommand("items");
            Console.WriteLine($"show items {cmd.execute()}");
        }
     
         
       
    }



    #region pattern






   

    public static class CommandParses
    {
        public static List<ICommand> GetAvaliableCommands()
        {
            return new List<ICommand>
            {
                new Quantity {CommandName="Qty" },
                new Price { CommandName="Price" },
                new Item { CommandName="items" } 
            };
        }


        public static ICommand GetCommand(string commandName)
        {
            return GetAvaliableCommands().SingleOrDefault(x => x.CommandName == commandName);
        }

    }

    public class Quantity :ICommand 
    {
        Commands cmd = new Commands();

        public string CommandName
        {
            get;

            set;
        }

        public string execute()
        {
            return cmd.GetQuantity();
        }
       
    }

    public class Item : ICommand
    {
        Commands cmd = new Commands();

        public string CommandName
        {
            get;

            set;
        }

        public string execute()
        {
            return cmd.AddItem("");
        }
    }

    public class Price : ICommand
    {
        Commands cmd = new Commands();

        public string CommandName
        {
            get;

            set;
        }

        public string execute()
        {
            return cmd.GetPrice("").ToString();
        }
    }

    public interface ICommand
    {
        string CommandName { get; set; }
        string execute();
    }

    #endregion


    #region anti pattern


    /// <summary>
    /// Command anti pattern
    /// </summary>
    public class commandAP
    {

        /// <summary>
        /// Method tha texecutes commands in wrong way 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public string ExecuteCommand(string arg)
        {
            var cmd = new Commands();
            switch(arg)
            {
                case "Qty":
                    {
                        return cmd.GetQuantity();
                    }
                case "Item":
                    {
                        return cmd.AddItem("new Item");
                    }
                case "price":
                    {
                        return cmd.GetPrice("new item").ToString();
                    }
                case "default":
                    {
                        return "please provide argument";
                    }
                
            }
            return "please provide argument";
        }
    }


    /// <summary>
    /// this are the commands that need to be executed 
    /// </summary>
    public class Commands
    {
       
        public string GetQuantity()
        {
            return "22";
        }


        public string AddItem(string name)
        {
            return "item added";    
        }


        public int GetPrice(string product)
        {
            return 2;
        }
    }
    #endregion
}
