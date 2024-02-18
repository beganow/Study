using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class ListOrders : List<Order>
    {
        public void LoadDataFromDatabase()
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на свою строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM OrderDetails"; // Запрос на выборку данных из представления

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Извлечение данных из SqlDataReader и создание объекта Order
                            Order order = new Order(
                                Login: reader["Login"].ToString(),
                                Name: reader["Name"].ToString(),
                                Full_Name: reader["Full_Name"].ToString(),
                                Category: reader["Category"].ToString(),
                                Size: reader["size"].ToString(),
                                User_Address: reader["user_address"].ToString(),
                                Order_Date: Convert.ToDateTime(reader["order_date"]),
                                Date_Delivery: Convert.ToDateTime(reader["date_delivery"]),
                                Status_Name: reader["Status_name"].ToString(),
                                Payment_Method: reader["payment_method"].ToString(),
                                Price: Convert.ToDecimal(reader["price"])
                            );

                            // Добавление объекта Order в список
                            this.Add(order);
                        }
                    }
                }

                connection.Close();
            }
        }

        public void LoadDataFromDatabaseUser(string username)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на свою строку подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM OrderDetails WHERE Login = @Username"; 


                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Извлечение данных из SqlDataReader и создание объекта Order
                            Order order = new Order(
                                Login: reader["Login"].ToString(),
                                Name: reader["Name"].ToString(),
                                Full_Name: reader["Full_Name"].ToString(),
                                Category: reader["Category"].ToString(),
                                Size: reader["size"].ToString(),
                                User_Address: reader["user_address"].ToString(),
                                Order_Date: Convert.ToDateTime(reader["order_date"]),
                                Date_Delivery: Convert.ToDateTime(reader["date_delivery"]),
                                Status_Name: reader["Status_name"].ToString(),
                                Payment_Method: reader["payment_method"].ToString(),
                                Price: Convert.ToDecimal(reader["price"])
                            );

                            // Добавление объекта Order в список
                            this.Add(order);
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
