using System.Collections.Generic;

namespace BagOLoot
{
  public class ToyRegister
  {
    private DatabaseInterface _db;
    private List<Toy> _toys = new List<Toy>();
    
    public ToyRegister(DatabaseInterface db)
    {
      _db = db;
    }

    public Toy Add(string toy, Child child)
    {
      // Insert into DB
      int newToyId = _db.Insert($"INSERT INTO toy VALUES (null, '{toy}', {child.id})");

      // Create new toy instance
      Toy newToy = new Toy(){
        id = newToyId,
        name = toy,
        child = child
      };

      // Add to private collection
      _toys.Add(newToy);

      return newToy;
    }
  }
}