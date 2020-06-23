using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    class Snake
    {
        int Height = 20; //wysokosc planszy
        int Width = 30; //szerokosc planszy

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX, fruitY, parts = 3;

        Random rnd = new Random();

        Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            fruitX = rnd.Next(2, (Width - 2));
            fruitY = rnd.Next(2, (Height - 2));
        }
        public void WriteBoard()
        {
            Console.Clear();
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write("|");
            }
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        public void Logic()
        {
            if (X[0] == fruitX)
            {
                parts++;
                fruitX = rnd.Next(2, (Width - 2)); //losowanie położenia owocu
                fruitY = rnd.Next(2, (Height - 2)); //losowanie położenia owocu
            }
            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            for(int i = 0; i <= (parts - 1); i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
            }
            
        }


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Snake snake = new Snake();
            bool exit = false;


            while (!exit)
            {
                snake.WriteBoard();
                snake.Logic();
                

                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.W:
                        snake.Y[0]--;
                        break;
                    case ConsoleKey.S:
                        snake.Y[0]++;
                        break;
                    case ConsoleKey.A:
                        snake.X[0]--;
                        break;
                    case ConsoleKey.D:
                        snake.X[0]++;
                        break;

                }
            }
            

        }   
    }
}
