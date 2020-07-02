using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake3
{
    public class Snake
    {
        int Height = 20; //wysokosc planszy
        int Width = 30; //szerokosc planszy

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX, fruitY, score = 0, parts = 3;
        public bool exit = false;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char keyBefore, key = 'w';

        Random rnd = new Random();

        public Snake()
        {
            X[0] = 15;
            Y[0] = 10;
            fruitX = rnd.Next(2, (Width - 2)); //losowanie położenia owocu
            fruitY = rnd.Next(2, (Height - 2)); //losowanie położenia owocu
        }



        public void WritePoint(int x, int y) //rysuje pojedynczny człon węża
        {
            Console.SetCursorPosition(x, y); //ustawia kursor
            Console.Write("#");

            for (int i = parts; i > 0; i--)
            {
                if (X[i] == X[0] && Y[i]==Y[0])
                {
                    exit = true;
                }
            }


            if (X[0] <= 1 || X[0] >= (Width + 2) || Y[0] <= 1 || Y[0] >= (Height + 2)) //sprawdza czy wąż nie wychodzi poza obszar gry 
            {
                exit = true;
                //Console.Write("Poza obszarem"); 
            }
        }

        public void WriteSnake()
        {
            for (int i = 0; i <= (parts - 1); i++)
            {

                WritePoint(X[i], Y[i]);
            }
            if (X[parts] != 0)
            {
                Console.SetCursorPosition(X[parts], Y[parts]);
                Console.Write("\0");
            }
        }
        public void Input()
        {
            if (Console.KeyAvailable) //sprawdza czy jest wciśniety przycisk
            {
                keyInfo = Console.ReadKey(true); //pobieranie klawisza z klawiatury
                keyBefore = key;//dodaje nową zmienną aby uniemożliwić ruch w przeciwnym kierunku
                key = keyInfo.KeyChar;//zamienia klawisz na wartość char i przypisuje do zmiennej key

                if (keyBefore == 'w' && key == 's' || keyBefore == 's' && key == 'w' || keyBefore == 'a' && key == 'd' || keyBefore == 'd' && key == 'a')
                {
                    key = keyBefore;
                }

            }
        }
        public void Shift()
        {
            for (int i = parts + 1; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
        }

        public void Result()
        {
            Console.SetCursorPosition(Width/2 - 5, Height + 3);
            Console.WriteLine("Score: " + score);
        }


        public void Logic()
        {
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++;
                    score += 100;
                    fruitX = rnd.Next(2, (Width - 2)); //losowanie położenia owocu
                    fruitY = rnd.Next(2, (Height - 2)); //losowanie położenia owocu
                }

            }
            /*
            for (int i = parts; i > 1; i--) //logika kolejnych członów węża
            {

                if (true)
                {
                    X[i - 1] = X[i - 2];
                    Y[i - 1] = Y[i - 2];
                }
                else exit = true;
             
            }
            */
            switch (key)
            {
                case 'w':
                    Shift();
                    Y[0]--;
                    break;
                case 's':
                    Shift();
                    Y[0]++;
                    break;
                case 'a':
                    Shift();
                    X[0]--;
                    break;
                case 'd':
                    Shift();
                    X[0]++;
                    break;

            }
            for (int i = 0; i <= (parts - 1); i++) //rusyje węża
            {

                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
            }

         
            Thread.Sleep(80);
           

        }

      
    }
}
