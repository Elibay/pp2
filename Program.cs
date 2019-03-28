using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace svetofor
{
    class Program
    {
        static Wall wall;
        static int cur = 0;
        static void Main(string[] args)
        {
            wall = new Wall();
            for (int x = 21; x <= 31; ++x)
            {
                if (x == 24 || x == 28)
                    continue;
                for (int y = 20; y <= 23; ++y)
                {
                    Point p = new Point(y, x);
                    wall.addPoint(p);
                }
            }
            ThreadStart threadStart = new ThreadStart(move);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Console.SetWindowSize(40, 40);
            while (true)
            {
                if (cur == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (cur == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (cur == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
        public static void move()
        {
            while (true)
            {
                wall.draw();
                cur = cur + 1;
                if (cur >= 3)
                {
                    cur = 0;
                }
                Thread.Sleep(1000);
            }
        }

    }
}
