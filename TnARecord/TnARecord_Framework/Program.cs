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
            bool endApp = false;

            var dbconnnector = new DBConnector();
            dbconnnector.Connector();

            Console.WriteLine("People-i TnA Record Program\r");
            Console.WriteLine("---------------------------\n");

            int argsCount = args.Length;

            while (!endApp)
            {
                Console.Write("User ID : ");
                string userID = Console.ReadLine();

                if (userID == "hskang")
                {
                    Console.WriteLine("아이디가 일치합니다.");
                }
                else if (userID == "-q")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    endApp = true;
                }
                else
                {
                    Console.WriteLine("아이디가 다릅니다.");
                }
                    
            }

            dbconnnector.Disconnector();

            return;
        }
    }
}
