using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string SQL = "SELECT * FROM `Comp_Clubs`;";
            MySqlConnection connection = Common.Connection.OpenConnection();
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

            Common.Connection.CloseConnection(connection);
            return AllClubs;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `Comp_Clubs` (`name`, `address`, `workHours`) " +
                         "VALUES ('" + this.Name + "', " +
                         "'" + this.Address + "', " +
                         "'" + this.WorkHours.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }

        public void Update()
        {
            string SQL = "UPDATE `Comp_Clubs` SET " +
                         "`name` = '" + this.Name + "', " +
                         "`address` = '" + this.Address + "', " +
                         "`workHours` = '" + this.WorkHours.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "WHERE `id` = " + this.Id;

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `Comp_Clubs` WHERE `id` = " + this.Id;

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }
    }
}
