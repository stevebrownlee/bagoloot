using System;
using System.Collections.Generic;
using System.Linq;
using BagOLoot.Actions;

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
            ToyRegister bag = new ToyRegister(db);

            // Choice will hold the number entered by the user
            // after main menu ws displayed
            int choice;

            do
            {
                // Show the main menu
                choice = menu.Show();

                switch (choice)
                {
                    // Menu option 1: Adding fish
                    case 1:
                        CreateChild.DoAction(book);
                        break;

                    // Menu option 2: Removing fish
                    case 2:
                        AddToy.DoAction(bag, book, db);
                        break;
                }
            } while (choice != 3);
        }
    }
}
