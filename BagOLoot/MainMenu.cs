using System;

namespace BagOLoot
{
  public class MainMenu
  {
    public int Show()
    {
      Console.Clear();
      Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
      Console.WriteLine ("*********************************");
      Console.WriteLine ("1. Add a child");
      Console.WriteLine ("2. Assign toy to a child");
      Console.WriteLine ("3. Revoke toy from child");
      Console.WriteLine ("4. Review child's toy list");
      Console.WriteLine ("5. Child toy delivery complete");
      Console.WriteLine ("6. Yuletime Delivery Report");
			Console.Write ("> ");
      ConsoleKeyInfo enteredKey = Console.ReadKey();
      Console.WriteLine("");
      return int.Parse(enteredKey.KeyChar.ToString());
    }
  }
}