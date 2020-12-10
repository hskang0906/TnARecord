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
            dbconnnector.Connect();

            Console.WriteLine("People-i TnA Record Program\r");
            Console.WriteLine("---------------------------\n");

            int argsCount = args.Length;

            while (!endApp)
            {
                Console.Write("User ID : ");
                string userID = Console.ReadLine();
                
                var queryEnsure = dbconnnector.Query($"select * from user_info where userid=\'{userID}\'");
                if (queryEnsure.userNumb != null)
                {
                    Console.Write("User Password : ");
                    bool pwdInputend = false;
                    string userPwd = "";
                    while (!pwdInputend)
                    {
                        var input = Console.ReadKey(true);
                        switch (input.Key)
                        {
                            case ConsoleKey.Backspace:
                                userPwd = userPwd.Substring(0, userPwd.Length - 1);
                                break;
                            case ConsoleKey.Enter:
                                Console.Write('\n');
                                pwdInputend = true;
                                break;
                            case ConsoleKey.Delete:
                                break;
                            default:
                                Console.Write('*');
                                userPwd += input.KeyChar;
                                break;
                        }
                    }

                    if (queryEnsure.userPwd == userPwd)
                    {
                        Console.WriteLine("로그인에 성공하였습니다.");
                        ConsoleUserInterface.MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("비밀번호가 틀립니다.");
                    }
                        
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

            dbconnnector.Disconnect();

            return;
        }
    }
}
