using System;
using System.Data;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace TnARecord
{
    public enum TableType
    {
        user_info = 0,
        TnA_info,
    }
    public enum FieldType
    {
        userID = 1,
        userPwn,
        userName,
        all,
    }

    public class DBConnector
    {
        private MySqlConnection DBConnection { get; set; }
        private MySqlCommand Command { get; set; }
        private MySqlDataReader reader { get; set; }

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
            }

            if (DBConnection.State == ConnectionState.Open)
                Command = DBConnection.CreateCommand();
        }

        public void Disconnector()
        {
            if (DBConnection.State == ConnectionState.Open)
                DBConnection.Close();
            else
                Console.WriteLine("연결 상태가 아닙니다.");
        }
    }
}
