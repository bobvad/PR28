using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string SQL = "SELECT * FROM `Arenda_CompGames`;";
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader Data = Common.Connection.Query(SQL, connection);

            while (Data.Read())
            {
                AllArenda.Add(new Arenda_CompGames(
                    Data.GetInt32(0),
                    Data.GetDateTime(1),
                    Data.GetString(2)
                ));
            }

            Common.Connection.CloseConnection(connection);
            return AllArenda;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `Arenda_CompGames` (`dateTime`, `FIOClients`) " +
                         "VALUES ('" + this.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "'" + this.FIOClients + "')";

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }

        public void Update()
        {
            string SQL = "UPDATE `Arenda_CompGames` SET " +
                         "`dateTime` = '" + this.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "`FIOClients` = '" + this.FIOClients + "' " +
                         "WHERE `id` = " + this.Id;

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
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
