using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using Windows.Storage;

namespace BudgetPlanner
{
    internal class DataBaseWorker
    {
        private readonly string connectionString;
        public DataBaseWorker()
        {
            connectionString = @"Data Source=Operations.db;Version=3;Mode=ReadWriteCreate;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;

                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = 'Operations';";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    reader.Close();
                    if (!reader.HasRows)
                    {
                        command.CommandText = "CREATE TABLE Operations(operationId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                        " operationType TEXT NOT NULL, operationSum MONEY NOT NULL, category TEXT NOT NULL, comment TEXT NOT NULL)";
                        command.ExecuteNonQuery();
                    }
                } 
            }
        }

        /// <summary>
        /// запрос на несколько строк таблицы
        /// </summary>
        public List<string[]> ExecuteQuery(string query, int col)
        {

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<string[]> response = new List<string[]>();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            response.Add(new string[col]);

                            for (int i = 0; i < col; i++)
                            {
                                response[response.Count - 1][i] = reader[i].ToString();
                            }
                        }
                        reader.Close();
                        return response;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// запрос на одну строку таблицы
        /// </summary>
        public List<string> ExecuteQueryRow(string query, int col)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<string> response = new List<string>();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < col; i++)
                            {
                                response.Add(reader[i].ToString());
                            }
                        }
                        reader.Close();
                        return response;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

    }
}
