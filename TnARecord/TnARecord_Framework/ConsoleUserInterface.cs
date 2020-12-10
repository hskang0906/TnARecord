using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnARecord
{
    class ConsoleUserInterface
    {
        public static void MainMenu()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("근태 입력        [w] ");
            Console.WriteLine("근태 조회        [r] ");
            Console.WriteLine("프로그램 종료    [q] ");
            Console.WriteLine("-------------------");
            Console.ReadLine();
        }

    }
}
