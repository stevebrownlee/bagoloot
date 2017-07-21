using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<Child> _children = new List<Child>();
        private DatabaseInterface _db;

        public ChildRegister(DatabaseInterface db)
        {
            _db = db;
        }

        public int AddChild (string child) 
        {
            int id = _db.Insert( $"insert into child values (null, '{child}', 0)");


            _children.Add(
                new Child()
                {
                    id = id,
                    name = child,
                    delivered = false
                }
            );

            return id;
        }

        public List<Child> GetChildren ()
        {
            _db.Query("select id, name, delivered from child",
                (SqliteDataReader reader) => {
                    _children.Clear();
                    while (reader.Read ())
                    {
                        _children.Add(new Child(){
                            id = reader.GetInt32(0),
                            name = reader[1].ToString(),
                            delivered = reader.GetInt32(2) == 1
                        });
                    }
                }
            );

            return _children;
        }

        public Child GetChild (int id) =>  _children.SingleOrDefault(kid => kid.id == id);

    }
}