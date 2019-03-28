using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static int x = 20;
        static int y = 20;
        static bool up = false;
        static bool down = false;
        static bool right = false;
        static bool left = true;

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(move);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Console.SetWindowSize(40, 40);
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow && down == false)
                {
                    up = true;
                    down = false;
                    left = false;
                    right = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && up == false)
                {

                    up = false;
                    down = true;
                    left = false;
                    right = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    up = false;
                    down = false;
                    left = true;
                    right = false;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    up = false;
                    down = false;
                    left = false;
                    right = true;
                }
            }
        }
        public static void move()
        {
            while(true) {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("*");
                if (up)
                {
                    y--;
                }
                if (down)
                {
                    y++;
                }
                if (right)
                {
                    x++;
                }
                if (left)
                {
                    x--;
                }

                Thread.Sleep(100);
            }
            
            
        }
    }
}
