using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace TnARecord
{
    public enum DBQueryType
    {
        select = 0,
        insert,
        update,
        delete
    }
    public class DBConnector
    {
        private MySqlConnection DBConnection { get; set; }
        private MySqlCommand Command { get; set; }
        private MySqlDataReader reader { get; set; }

        private bool ConnectStatus { get; set; }

        public void Connector(string serverIP = "localhost")
        {
            string ConnectString = "Server=localhost;Database=tnarecord;Uid=root;Pwd=root;Charset=utf8;";
            DBConnection = new MySqlConnection(ConnectString);
            try
            {
                DBConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ConnectStatus = false;
            }

            Command = DBConnection.CreateCommand();

        }

        public void Query(DBQueryType querytype, string querystring)
        {
            if (DBConnection.Ping() == true)
            {
                Command.CommandText = querystring;

                switch (querytype)
                {
                    case DBQueryType.select:
                        reader = Command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["userid"]}, {reader["userpwd"]}, {reader["userName"]}");
                        }
                        break;
                    default:
                        Command.ExecuteNonQuery();
                        break;
                }
            }

            else
                Console.WriteLine("DisConnected SQL Server!");
        }
    }
}
