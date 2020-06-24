using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
        bool exit = false;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key  = 'W';
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

        public void Input()
        {
            if (Console.KeyAvailable) //sprawdza czy jest wciśniety przycisk
            {
                keyInfo = Console.ReadKey(true); //pobieranie klawisza z klawiatury
                key = keyInfo.KeyChar; //zamienia klawisz na wartość char i przypisuje do zmiennej key
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
                if(Y[0] == fruitY)
                {
                    parts++;
                    fruitX = rnd.Next(2, (Width - 2)); //losowanie położenia owocu
                    fruitY = rnd.Next(2, (Height - 2)); //losowanie położenia owocu
                }
                
            }
            for (int i = parts; i > 1; i--) //logika kolejnych członów węża
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
                case 'd':
                    X[0]++;
                    break;

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
            

            while (!snake.exit)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
                Thread.Sleep(200);
            }
            

        }   
    }
}
