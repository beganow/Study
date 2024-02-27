using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class BD
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            { sqlConnection.Open(); }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            { sqlConnection.Close(); }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public void InsertUser()
        {
       
            string username1 = MainWindow.username;
            string password1 = MainWindow.password;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username1);
                    command.Parameters.AddWithValue("@password", password1);

                   command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser()
        {
            string username1 = MainWindow.username;
    
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeleteUserByName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username1);
  

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser()
        {
            string username1 = MainWindow.username;
            string newLogin = EditUser.login;
            string newPassword = EditUser.password;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Создание транзакции
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Получение идентификатора пользователя
                    int userId;
                    using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Username", username1);
                        selectCommand.Transaction = transaction;
                        userId = (int)selectCommand.ExecuteScalar();
                    }

                    // Обновление строки с найденным идентификатором
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE users SET login = @NewLogin, password = @NewPassword WHERE user_id = @UserId", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewLogin", newLogin);
                        updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCommand.Parameters.AddWithValue("@UserId", userId);
                        updateCommand.Transaction = transaction;
                        updateCommand.ExecuteNonQuery();
                    }

                    // Подтверждение транзакции
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Обработка ошибок и откат транзакции при необходимости
                    transaction.Rollback();
                    Console.WriteLine("Ошибка при выполнении транзакции: " + ex.Message);
                }
            }
        }

        public void AddSneacker()
        {

            string username1 = MainWindow.username;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userId;
                using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                {
                    selectCommand.Parameters.AddWithValue("@Username", username1);
                    userId = (int)selectCommand.ExecuteScalar();
                } 

                using (SqlCommand command = new SqlCommand("AddSneaker", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", Added.newfield1);
                    command.Parameters.AddWithValue("@FullName", Added.newfield2);
                    command.Parameters.AddWithValue("@ImageFileName", Added.newfield3);
                    command.Parameters.AddWithValue("@Category", Added.selectedValue);
                    command.Parameters.AddWithValue("@Rate", Double.Parse(Added.newfield5));
                    command.Parameters.AddWithValue("@Size", Int32.Parse(Added.newfield6));
                    command.Parameters.AddWithValue("@Count", Int32.Parse(Added.newfield7));
                    command.Parameters.AddWithValue("@Price", Double.Parse(Added.newfield8));
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSneacker()
        {


            string username1 = MainWindow.username;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных


           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                int userId;
                using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                {
                    selectCommand.Parameters.AddWithValue("@Username", username1);
                    userId = (int)selectCommand.ExecuteScalar();
                }

                // Create a command object for the stored procedure
                using (SqlCommand command = new SqlCommand("DeleteSneaker", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter for the sneaker ID
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }


        public void EditSneacker()
        {
            string username1 = MainWindow.username;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userId;
                using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                {
                    selectCommand.Parameters.AddWithValue("@Username", username1);
                    userId = (int)selectCommand.ExecuteScalar();
                }
                using (SqlCommand command = new SqlCommand("update_sneakers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add the parameter for the sneaker ID
                   
                    command.Parameters.AddWithValue("@Name", Edit.newfield1);
                    command.Parameters.AddWithValue("@FullName", Edit.newfield2);
                    command.Parameters.AddWithValue("@Image", Edit.newfield3);
                    command.Parameters.AddWithValue("@Category", Edit.selectedValue);
                    command.Parameters.AddWithValue("@Rate", Double.Parse(Edit.newfield5));
                    command.Parameters.AddWithValue("@Size", Int32.Parse(Edit.newfield6));
                    command.Parameters.AddWithValue("@Count", Int32.Parse(Edit.newfield7));
                    command.Parameters.AddWithValue("@Price", Double.Parse(Edit.newfield8)); 
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
