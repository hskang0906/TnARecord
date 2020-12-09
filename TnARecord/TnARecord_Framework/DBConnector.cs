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
        tableTypeCount,
    }
    public enum FieldType
    {
        userID = 1,
        userPwn,
        userName,
        fieldTypeCount,
    }
    public struct FieldStruct
    {
        public string userNumb;
        public string userID;
        public string userPwd;
        public string userName;
    }
    public class DBConnector
    {
        private MySqlConnection connector { get; set; }
        private MySqlCommand command { get; set; }
        private MySqlDataReader reader { get; set; }

        public void Connect(string serverIP = "localhost")
        {
            string ConnectString = "Server=localhost;Database=tnarecord;Uid=root;Pwd=root;Charset=utf8;";
            connector = new MySqlConnection(ConnectString);

            try
            {
                connector.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (connector.State == ConnectionState.Open)
                command = connector.CreateCommand();
        }

        public void Disconnect()
        {
            if (connector.State == ConnectionState.Open)
                connector.Close();
            else
                Console.WriteLine("연결 상태가 아닙니다.");
        }
        public FieldStruct Query(string query)
        {
            FieldStruct SelectQueryResult;
            SelectQueryResult.userNumb = null;
            SelectQueryResult.userID = null;
            SelectQueryResult.userPwd = null;
            SelectQueryResult.userName = null;

            if (connector.State == ConnectionState.Open)
            {
                command.CommandText = query;
                var querytype = new string[4] {"select", "insert", "update", "delete" };
                var inputquerytype = query.Split(' ');

                if (inputquerytype[0].Equals(querytype[0]))
                {
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        SelectQueryResult.userNumb = reader["usernumber"].ToString();
                        SelectQueryResult.userID = reader["userid"].ToString();
                        SelectQueryResult.userPwd = reader["userpwd"].ToString();
                        SelectQueryResult.userName = reader["userName"].ToString();
                    }

                    reader.Close();
                }
                else
                {
                    command.ExecuteNonQuery();
                }
            }

            return SelectQueryResult;
        }

        public string SelectQuery(TableType tableType)
        {
            string fieldString = null;

            return fieldString;
        }
    }
}
