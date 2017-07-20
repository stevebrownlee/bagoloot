using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BagOLoot
{
    public class DatabaseInterface
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public DatabaseInterface()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader()) 
                {
                    handler (dataReader);
                }

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        public void Change(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                
                dbcmd.ExecuteNonQuery ();

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        public void CheckChildTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the child table to see if table is created
                dbcmd.CommandText = $"select id from child";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table child (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) not null, 
                            `delivered` integer not null default 0
                        )";
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        public void CheckToyTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the child table to see if table is created
                dbcmd.CommandText = $"select id from toy";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table toy (
                            `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) not null, 
                            `childId` integer not null,
                            FOREIGN KEY(`childId`) REFERENCES `child`(`id`),
                        )";
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }
    }
}