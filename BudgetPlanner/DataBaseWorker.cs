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
            connectionString = @"Data Source=Operations.db;Version=3;Journal Mode=Off;";
        }

        /// <summary>
        /// запрос на несколько строк таблицы
        /// </summary>
        public List<string[]> ExecuteQuery(string query, int col)
        {

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (var reader = command.ExecuteReader())
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
                        connection.Close();
                        return response;
                    }
                    else
                    {
                        
                        reader.Close();
                        connection.Close();
                        return null;
                    }
                }
                
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SQLiteConnection(connectionString, true))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

    }
}
