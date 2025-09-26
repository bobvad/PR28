using MySql.Data.MySqlClient;
namespace PR28_Degtinnikov.Classes.Common
{
    public class Connection
    {
        public static readonly string config = "server=127.0.0.1;uid=root;pwd=;database=Comp_Clubs";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
