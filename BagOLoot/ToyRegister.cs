using System.Collections.Generic;
using BagOLoot.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Linq;

namespace BagOLoot
{
    public class ToyRegister
    {
        private SqliteConnection _connection = DatabaseInterface.Connection;
        private List<Toy> _toys = new List<Toy>();

        public void Add(string toy, Child child)
        {
            // Insert into DB
            _connection.Execute($"INSERT toy VALUES ('{toy}', {child.id})");
        }

        public void RevokeToy(Child kid, Toy toy)
        {

        }

        public List<Toy> GetToysForChild(Child kid)
        {
            List<Toy> toys = _connection.Query<Toy>
                ($"SELECT t.name FROM Toy t WHERE t.childId = {kid.id}").ToList();

            return toys;
        }
    }
}