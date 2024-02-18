using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
            string email = UserControl1.email;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertIntoUsers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@login", username1);
                    command.Parameters.AddWithValue("@password", password1);
                    command.Parameters.AddWithValue("@email", email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser()
        {
            string username23 = ListViewItems.login;
            string username24 =ListViewItemsForUser.userlog;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            int userId;

            // Здесь мы устанавливаем соединение с базой данных и получаем идентификатор пользователя
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Запрос для получения идентификатора пользователя
                using (SqlCommand selectCommand = new SqlCommand("SELECT user_id FROM users WHERE login = @Username", connection))
                {

                    if (!string.IsNullOrEmpty(username23))
                    {
                        selectCommand.Parameters.AddWithValue("@Username", username23);
                    }
                    else
                    {
                        selectCommand.Parameters.AddWithValue("@Username", username24);
                    }
                    MessageBox.Show(username23);
                    MessageBox.Show(username24);
                    userId = (int)selectCommand.ExecuteScalar();
                }

                // Удаление пользователя с использованием хранимой процедуры
                using (SqlCommand command = new SqlCommand("DeleteUserByLogin", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    if (!string.IsNullOrEmpty(username23))
                    {
                        command.Parameters.AddWithValue("@Login", username23);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Login", username24);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser()
        {
            string username23 = Login.username;
            string username24 = MainWindow.username;
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
                        if (!string.IsNullOrEmpty(username23)) {
                            selectCommand.Parameters.AddWithValue("@Username", username23);
                        }
                        else { selectCommand.Parameters.AddWithValue("@Username", username24);
                        }
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
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSneacker(int id)
        {

            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a command object for the stored procedure
                using (SqlCommand command = new SqlCommand("DeleteSneaker", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    id = id + 1;
                    // Add the parameter for the sneaker ID
                    command.Parameters.AddWithValue("@index", id);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }


        public void EditSneacker(int id)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update_sneakers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    id = id + 1;
                    // Add the parameter for the sneaker ID
                    command.Parameters.AddWithValue("@index", id);
                    command.Parameters.AddWithValue("@Name", Edit.newfield1);
                    command.Parameters.AddWithValue("@FullName", Edit.newfield2);
                    command.Parameters.AddWithValue("@Image", Edit.newfield3);
                    command.Parameters.AddWithValue("@Category", Edit.selectedValue);
                    command.Parameters.AddWithValue("@Rate", Double.Parse(Edit.newfield5));
                    command.Parameters.AddWithValue("@Size", Int32.Parse(Edit.newfield6));
                    command.Parameters.AddWithValue("@Count", Int32.Parse(Edit.newfield7));
                    command.Parameters.AddWithValue("@Price", Double.Parse(Edit.newfield8));

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }


        public bool CheckLog(string login)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Проверка существования пользователя по логину
                string queryLogin = "SELECT COUNT(*) FROM Users WHERE login = @login";
                using (SqlCommand commandLogin = new SqlCommand(queryLogin, connection))
                {
                    commandLogin.Parameters.AddWithValue("@login", login);
                    int userCountLogin = (int)commandLogin.ExecuteScalar();
                    if (userCountLogin > 0)
                    {
                        MessageBox.Show("RU: Пользователь с данным логином существует.\n ENG: A user with this login exists.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }


        public bool CheckEmail(string email)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Проверка существования пользователя по логину
                string queryLogin = "SELECT COUNT(*) FROM Users WHERE email = @email";
                using (SqlCommand commandLogin = new SqlCommand(queryLogin, connection))
                {
                    commandLogin.Parameters.AddWithValue("@email", email);
                    int userCountEmail = (int)commandLogin.ExecuteScalar();
                    if (userCountEmail > 0)
                    {
                        MessageBox.Show("RU: Пользователь с данной электронной почтой существует. \n ENG: A user with this email exists.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

        public bool CheckLoginLog(string login)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Проверка существования пользователя по логину
                string queryLogin = "SELECT COUNT(*) FROM Users WHERE login = @login";
                using (SqlCommand commandLogin = new SqlCommand(queryLogin, connection))
                {
                    commandLogin.Parameters.AddWithValue("@login", login);
                    int userCountLogin = (int)commandLogin.ExecuteScalar();
                    if (userCountLogin == 0)
                    {
                        MessageBox.Show("RU: Пользователь с данным логином не существует. Перейдите на окно Регистрация. \n ENG: A user with this login does not exist. Go to the Registration window. ");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
        public bool CheckPassAndLoginLog(string login, string password)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryLogin = "SELECT COUNT(*) FROM Users WHERE login = @login and password = @password";
                using (SqlCommand commandLogin = new SqlCommand(queryLogin, connection))
                {
                    commandLogin.Parameters.AddWithValue("@login", login);
                    commandLogin.Parameters.AddWithValue("@password", password);
                    int userCountLogin = (int)commandLogin.ExecuteScalar();
                    if (userCountLogin == 0)
                    {
                        MessageBox.Show("RU:Пароль неверный. Попробуйте ещё раз. \n ENG: The password is incorrect. Try again.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

        public bool CheckRole(string login, string password)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True"; // Замените на вашу строку подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryRole = "SELECT role FROM Users WHERE login = @login and password = @password";
                using (SqlCommand commandLogin = new SqlCommand(queryRole, connection))
                {
                    commandLogin.Parameters.AddWithValue("@login", login);
                    commandLogin.Parameters.AddWithValue("@password", password);
                    int userRole = (int)commandLogin.ExecuteScalar();
                    if (userRole == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

        public void EditUserInfo(string login, string newlogin, string newpassword)
        {

            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    int userId;
                    using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Username", login);
                        selectCommand.Transaction = transaction;
                        userId = (int)selectCommand.ExecuteScalar();

                    }
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE users SET login = @NewLogin, password = @NewPassword WHERE user_id = @UserId", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewLogin", newlogin);
                        updateCommand.Parameters.AddWithValue("@NewPassword", newpassword);
                        updateCommand.Parameters.AddWithValue("@UserId", userId);
                        updateCommand.Transaction = transaction;
                        updateCommand.ExecuteNonQuery();
                    }
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

        public void DelUserInfo(string login)
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand delCommand = new SqlCommand("DELETE FROM users where login=@Login ", connection))
                    {
                        delCommand.Parameters.AddWithValue("@Login", login);
                        delCommand.Transaction = transaction;
                        delCommand.ExecuteNonQuery();
                    }
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

       public void AddOrder(int ids, int payid, string address, DateTime date_delivery)
        {
            string username24 = ListViewItemsForUser.userlog;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    int userId;
                    using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                    {
                       
                        selectCommand.Parameters.AddWithValue("@Username", username24);
                        
                        userId = (int)selectCommand.ExecuteScalar();
                    }
                    using (SqlCommand command = new SqlCommand("AddOrder", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        ids = ids + 1;
                   
                        command.Parameters.AddWithValue("@user_id", userId);
                        command.Parameters.AddWithValue("@id_sneacker", ids);
                        command.Parameters.AddWithValue("@payment_method_id", payid);
                        command.Parameters.AddWithValue("@user_address", address);
                        command.Parameters.AddWithValue("@date_delivery", date_delivery);
                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок и откат транзакции при необходимости
                    Console.WriteLine("Ошибка при выполнении " + ex.Message);
                }
            }
        }



        public void AddOwnOrder(int stat, int ids)
        {
            string username24 = ListViewItemsForUser.userlog;
            DateTime order_date = Buying.order_date;
            DateTime date = Buying.order_delivery;
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    int userId, order_id;
                    decimal price;
                    ids = ids + 1;
                    using (SqlCommand selectCommand = new SqlCommand("SELECT USER_ID FROM users WHERE login = @Username", connection))
                    {
                      
                            selectCommand.Parameters.AddWithValue("@Username", username24);
                        
                        userId = (int)selectCommand.ExecuteScalar();
                        
                    }
                    using (SqlCommand selectCommand1 = new SqlCommand("SELECT order_id FROM Orders WHERE user_id = @Username AND date_delivery = @date", connection))
                    {
                        selectCommand1.Parameters.AddWithValue("@date", date);
                        selectCommand1.Parameters.AddWithValue("@Username", userId);
                        order_id = (int)selectCommand1.ExecuteScalar();
                     ;
                    }
                    using (SqlCommand selectCommand2 = new SqlCommand("SELECT price FROM Sneackers WHERE sneaker_id = @id_s", connection))
                    {
                        selectCommand2.Parameters.AddWithValue("@id_s", ids);
                        price = (decimal)selectCommand2.ExecuteScalar();
                    }
                    using (SqlCommand command = new SqlCommand("AddOwnOrder", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@order_id", order_id);
                   
                        command.Parameters.AddWithValue("@id_user", userId);
                   
                        command.Parameters.AddWithValue("@order_date", order_date);
                    
                        command.Parameters.AddWithValue("@status", stat);
                      
                        command.Parameters.AddWithValue("@full_price", price);
                     
                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок и откат транзакции при необходимости
                    Console.WriteLine("Ошибка при выполнении " + ex.Message);
                }
            }
        }
        public void UpdateDate()
        {
            string connectionString = "Data Source=Pavel;Initial Catalog=Sneackers;Integrated Security=True";
            int newstatus;
            DateTime now = DateTime.Now;
            if (now > Buying.order_delivery)
            {
                newstatus = 1;
            }
            else
            {
                newstatus = 2;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Создание транзакции
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                   
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE OrdersHistory SET status = @NewStatus", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewStatus", newstatus);
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


    }
}
