using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PR28_Degtinnikov.Classes
{
    public class Comp_Clubs : Modell.Comp_Clubs
    {
        public Comp_Clubs(int Id, string name, string address, DateTime workHours) : base(Id, name, address, workHours)
        {
        }

        public static List<Comp_Clubs> Select()
        {
            List<Comp_Clubs> AllClubs = new List<Comp_Clubs>();
            MySqlConnection connection = null;

            try
            {
                string SQL = "SELECT * FROM `Comp_Clubs`;";
                connection = Common.Connection.OpenConnection();
                MySqlDataReader Data = Common.Connection.Query(SQL, connection);

                while (Data.Read())
                {
                    AllClubs.Add(new Comp_Clubs(
                        Data.GetInt32(0),
                        Data.GetString(1),
                        Data.GetString(2),
                        Data.GetDateTime(3)
                    ));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                throw;
            }
            finally
            {
                if (connection != null)
                    Common.Connection.CloseConnection(connection);
            }

            return AllClubs;
        }

        public void Add()
        {
            MySqlConnection connection = null;

            try
            {
                string escapedName = this.Name.Replace("'", "''");
                string escapedAddress = this.Address.Replace("'", "''");

                string SQL = "INSERT INTO `Comp_Clubs` (`name`, `address`, `workHours`) " +
                             "VALUES ('" + escapedName + "', " +
                             "'" + escapedAddress + "', " +
                             "'" + this.WorkHours.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                connection = Common.Connection.OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при добавлении: {ex.Message}");
                throw;
            }
            finally
            {
                if (connection != null)
                    Common.Connection.CloseConnection(connection);
            }
        }

        public void Update()
        {
            MySqlConnection connection = null;

            try
            {
                string escapedName = this.Name.Replace("'", "''");
                string escapedAddress = this.Address.Replace("'", "''");

                string SQL = "UPDATE `Comp_Clubs` SET " +
                             "`name` = '" + escapedName + "', " +
                             "`address` = '" + escapedAddress + "', " +
                             "`workHours` = '" + this.WorkHours.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                             "WHERE `id` = " + this.Id;

                connection = Common.Connection.OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.ExecuteNonQuery();
                MessageBox.Show($"Данные обновлены:\nИмя: {this.Name}\nАдрес: {this.Address}\nВремя: {this.WorkHours.ToString("HH:mm")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении: {ex.Message}");
                throw;
            }
            finally
            {
                if (connection != null)
                    Common.Connection.CloseConnection(connection);
            }
        }

        public void Delete()
        {
            MySqlConnection connection = null;

            try
            {
                string SQL = "DELETE FROM `Comp_Clubs` WHERE `id` = " + this.Id;

                connection = Common.Connection.OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при удалении: {ex.Message}");
                throw;
            }
            finally
            {
                if (connection != null)
                    Common.Connection.CloseConnection(connection);
            }
        }
    }
}