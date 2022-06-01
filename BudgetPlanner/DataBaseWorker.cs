using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BudgetPlanner
{
    internal class DataBaseWorker
    {
        private readonly string connectionString;
        private SqlConnection connection;
        private static string db_name = "OperationBd";
        

        public DataBaseWorker()
        {
            connectionString = $"Server=DESKTOP-FP7JDD8;Database={db_name};User Id=sasha;Password=sasha;";
        }

        public void OpentConection()
        {
            // Создание подключения
            connection = new SqlConnection(connectionString);

            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("неполучилось открыть бд");
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// запрос на несколько строк таблицы
        /// </summary>
        public List<string[]> ExecuteQuery(string query, int col)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string[]> response = new List<string[]>();

            while (sqlDataReader.Read())
            {
                response.Add(new string[col]);

                for(int i = 0; i < col; i++)
                {
                    response[response.Count - 1][i] = sqlDataReader[i].ToString();
                } 
            }
            sqlDataReader.Close();
            if (response.Count > 0)
                return response;
            else
                return null;
        }

        /// <summary>
        /// запрос на одну строку таблицы
        /// </summary>
        public List<string> ExecuteQueryRow(string query, int col)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string> response = new List<string>();

            while (sqlDataReader.Read())
            {
                for (int i = 0; i < col; i++)
                {
                    response.Add(sqlDataReader[i].ToString());
                }
            }

            sqlDataReader.Close();

            return response;
        }

        /// <summary>
        /// запрос на одно значение
        /// </summary>
        public string ExecuteQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            string response = null;

            while (sqlDataReader.Read())
            {
                response = sqlDataReader[0].ToString();
            }

            sqlDataReader.Close();

            return response;
        }



        public void CloseConection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
