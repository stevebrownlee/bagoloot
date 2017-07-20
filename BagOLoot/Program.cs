using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.CheckChildTable();
            db.CheckToyTable();

            // Choice will hold the number entered by the user
            // after main menu ws displayed
            int choice;

            do
            {
                // Show the main menu
                choice = menu.ShowMainMenu();

                switch (choice)
                {
                    // Menu option 1: Adding fish
                    case 1:
                        AddFish.DoAction(store, myAquarium);
                        break;

                    // Menu option 2: Removing fish
                    case 2:
                        RemoveFish.DoAction(myAquarium);
                        break;
                }
            } while (choice != 3);



            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
        }
    }
}
