using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<Child> _children = new List<Child>();
        private DatabaseInterface _db = new DatabaseInterface();

        public ChildRegister()
        {
        }

        public int AddChild (string child) 
        {
            _db.Change( $"insert into child values (null, '{child}', 0)");

            int lastChild = 0;

            _db.Query("select last_insert_rowid()",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        lastChild = reader.GetInt32(0);
                    }
                }
            );
            return lastChild;
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