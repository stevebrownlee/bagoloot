using System;
using System.Collections.Generic;
using System.Linq;
using BagOLoot.Actions;
using BagOLoot.Data;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface("BAGOLOOT_DB");
            db.CheckChildTable();
            db.CheckToyTable();

            MainMenu menu = new MainMenu();




            ChildRegister book = new ChildRegister(db);
            ToyRegister bag = new ToyRegister();


            // Choice will hold the number entered by the user
            // after main menu ws displayed
            int choice;

            do
            {
                // Show the main menu
                choice = menu.Show();

                switch (choice)
                {
                    // Menu option 1: Adding child
                    case 1:
                        CreateChild.DoAction(book);
                        break;

                    // Menu option 2: Adding toy
                    case 2:
                        AddToy.DoAction(bag, book);
                        break;
                }
            } while (choice != 3);
        }
    }
}
