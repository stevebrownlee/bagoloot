using System;
using System.Collections.Generic;


namespace BagOLoot.Actions
{
  public class AddToy
  {
    public static void DoAction(ToyRegister bag, ChildRegister book)
    {
      Console.Clear();
      Console.WriteLine ("Choose child");

      List<Child> children = book.GetChildren();
      foreach (Child child in children)
      {
          Console.WriteLine($"{child.id}. {child.name}");
      }

      Console.Write ("> ");
      string childName = Console.ReadLine();
      Child kid = book.GetChild(int.Parse(childName));
      
      Console.WriteLine ("Enter toy");
      Console.Write ("> ");
      string toyName = Console.ReadLine();
      bag.Add(toyName, kid);
    }
  }
}