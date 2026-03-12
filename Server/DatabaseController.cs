using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Server
{
    public static class DatabaseController
    {
        public const string CONNECTION_STRING = "Data Source=database.db";

        public static void InitializeDatabase()
        {
            SQLitePCL.Batteries.Init();

            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO users (name) VALUES ('Alice')";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * FROM users";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
                    }
                }
            }
        }
    }
}
