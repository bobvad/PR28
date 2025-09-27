using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR28_Degtinnikov.Classes
{
    public class Arenda_CompGames : Modell.Arenda_GameComp
    {
        public Arenda_CompGames(int Id, DateTime dateTime, string FIOClients) : base(Id, dateTime, FIOClients)
        {
        }

        public static List<Arenda_CompGames> Select()
        {
            List<Arenda_CompGames> AllArenda = new List<Arenda_CompGames>();
            MySqlConnection connection = null;

            try
            {
                string SQL = "SELECT * FROM `Arenda_CompGames`;";
                connection = Common.Connection.OpenConnection();
                MySqlDataReader Data = Common.Connection.Query(SQL, connection);

                while (Data.Read())
                {
                    AllArenda.Add(new Arenda_CompGames(
                        Data.GetInt32("id"),
                        Data.GetDateTime("dateTime"),
                        Data.GetString("FIOClients")
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                throw;
            }
            finally
            {
                if (connection != null)
                    Common.Connection.CloseConnection(connection);
            }

            return AllArenda;
        }

        public void Add()
        {
            MySqlConnection connection = null;

            try
            {
                string escapedFIOClients = this.FIOClients.Replace("'", "''");

                string SQL = "INSERT INTO `Arenda_CompGames` (`dateTime`, `FIOClients`) " +
                             "VALUES ('" + this.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                             "'" + escapedFIOClients + "')";

                connection = Common.Connection.OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.ExecuteNonQuery();

                MessageBox.Show($"Данные сохранены: {this.dateTime} - {this.FIOClients}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
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
                string escapedFIOClients = this.FIOClients.Replace("'", "''");

                string SQL = "UPDATE `Arenda_CompGames` SET " +
                             "`dateTime` = '" + this.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                             "`FIOClients` = '" + escapedFIOClients + "' " +
                             "WHERE `id` = " + this.Id;

                connection = Common.Connection.OpenConnection();
                MySqlCommand command = new MySqlCommand(SQL, connection);
                command.ExecuteNonQuery();

                MessageBox.Show($"Данные обновлены: {this.dateTime} - {this.FIOClients}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
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
            string SQL = "DELETE FROM `Arenda_CompGames` WHERE `id` = " + this.Id;
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }
    }
}
