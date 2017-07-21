using System;
using System.Collections.Generic;


namespace BagOLoot.Actions
{
  public class CreateChild
  {
    public static void DoAction(ChildRegister registry)
    {
      Console.Clear();

      Console.WriteLine ("Enter child name");
      Console.Write ("> ");
      string childName = Console.ReadLine();
      int childId = registry.AddChild(childName);
      Console.WriteLine(childId);
    }
  }
}