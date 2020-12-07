using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnARecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maria DB Test :: Query");

            var dbconnnector = new DBConnector();
            dbconnnector.Connector();
            dbconnnector.Query(DBQueryType.select, "select * from user_info");
        }
    }
}
