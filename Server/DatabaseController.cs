using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABSoftware;
using Microsoft.Data.Sqlite;

namespace Server
{
    public static class DatabaseController
    {
        public const string CONNECTION_STRING = "Data Source=database.db";

        public static void InitializeDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT NOT NULL, password_hash TEXT, login_hash TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS groups (id INTEGER PRIMARY KEY, name TEXT NOT NULL, user_id INTEGER, FOREIGN KEY (user_id) REFERENCES users(id))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY, name TEXT NOT NULL, state INTEGER, group_id INTEGER, FOREIGN KEY (group_id) REFERENCES groups(id))";
                command.ExecuteNonQuery();
            }
        }

        public static void AddUser(string username, string passwordHash, string loginHash)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO users (name, password_hash, login_hash) VALUES (@username, @passwordHash, @loginHash)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwordHash", passwordHash);
                command.Parameters.AddWithValue("@loginHash", loginHash);
                command.ExecuteNonQuery();
            }
        }

        public static (int, string, string) GetUser(string username)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM users WHERE name = @username";
                command.Parameters.AddWithValue("@username", username);
                
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        return (reader.GetInt32(reader.GetOrdinal("id")), reader.GetString(reader.GetOrdinal("name")), reader.GetString(reader.GetOrdinal("password_hash")));
                    }
                }
            }

            return (-1, null, null);
        }

        public static int GetLoggedInUserID(string loginHash)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM users WHERE login_hash = @loginHash";
                command.Parameters.AddWithValue("@loginHash", loginHash);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(reader.GetOrdinal("id"));
                    }
                }
            }

            return -1;
        }

        public static void UpdateUserLoginHash(int userId, string loginHash)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE users SET login_hash = @loginHash WHERE id = @userId";
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@loginHash", loginHash);
                command.ExecuteNonQuery();
            }
        }

        public static void AddGroup(string groupName, int userId)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO groups (name, user_id) VALUES (@groupName, @userId)";
                command.Parameters.AddWithValue("@groupName", groupName);
                command.Parameters.AddWithValue("@userId", userId);
                command.ExecuteNonQuery();
            }
        }

        public static (int, string, int) GetGroup(string groupName, int userId)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM groups WHERE name = @groupName AND user_id = @userId";
                command.Parameters.AddWithValue("@groupName", groupName);
                command.Parameters.AddWithValue("@userId", userId);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (reader.GetInt32(reader.GetOrdinal("id")), reader.GetString(reader.GetOrdinal("name")), reader.GetInt32(reader.GetOrdinal("user_id")));
                    }
                }
            }

            return (-1, null, -1);
        }

        public static void DeleteGroupAndTasks(int groupId)
        {
            using (var connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    SqliteCommand deleteTasksCommand = connection.CreateCommand();
                    deleteTasksCommand.Transaction = transaction;
                    deleteTasksCommand.CommandText = "DELETE FROM tasks WHERE group_id = @groupId";
                    deleteTasksCommand.Parameters.AddWithValue("@groupId", groupId);
                    deleteTasksCommand.ExecuteNonQuery();

                    SqliteCommand deleteGroupCommand = connection.CreateCommand();
                    deleteGroupCommand.Transaction = transaction;
                    deleteGroupCommand.CommandText = "DELETE FROM groups WHERE id = @groupId";
                    deleteGroupCommand.Parameters.AddWithValue("@groupId", groupId);
                    deleteGroupCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public static void AddTask(string taskName, int groupId, bool taskState)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO tasks (name, group_id, state) VALUES (@taskName, @groupId, @taskState)";
                command.Parameters.AddWithValue("@taskName", taskName);
                command.Parameters.AddWithValue("@groupId", groupId);
                command.Parameters.AddWithValue("@taskState", taskState ? 1 : 0);
                command.ExecuteNonQuery();
            }
        }

        public static (int, string, int, bool) GetTask(int groupId, string taskName)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM tasks WHERE name = @taskName AND group_id = @groupId";
                command.Parameters.AddWithValue("@taskName", taskName);
                command.Parameters.AddWithValue("@groupId", groupId);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (reader.GetInt32(reader.GetOrdinal("id")), reader.GetString(reader.GetOrdinal("name")), reader.GetInt32(reader.GetOrdinal("group_id")), reader.GetInt32(reader.GetOrdinal("state")) != 0);
                    }
                }
            }

            return (-1, null, -1, false);
        }

        public static void DeleteTask(int groupId, string taskName)
        {
            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM tasks WHERE name = @taskName AND group_id = @groupId";
                command.Parameters.AddWithValue("@taskName", taskName);
                command.Parameters.AddWithValue("@groupId", groupId);

                command.ExecuteNonQuery();
            }
        }

        public static ArrayList<(string, string, bool)> FetchUserGroupsAndTasks(int userId)
        {
            ArrayList<(string, string, bool)> fetchedData = new ArrayList<(string, string, bool)>();

            using (SqliteConnection connection = new SqliteConnection(CONNECTION_STRING))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT groups.name AS group_name, tasks.name as task_name, tasks.state as task_state FROM groups INNER JOIN tasks ON groups.id = tasks.group_id WHERE groups.user_id = @userId;";
                command.Parameters.AddWithValue("@userId", userId);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fetchedData.Add((reader.GetString(reader.GetOrdinal("group_name")), reader.GetString(reader.GetOrdinal("task_name")), reader.GetInt32(reader.GetOrdinal("task_state")) != 0));
                    }
                }
            }

            return fetchedData;
        }
    }
}