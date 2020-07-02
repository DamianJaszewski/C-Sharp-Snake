using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake3
{
    class Program
    {
      
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Snake snake = new Snake();


            while (!snake.exit)
            {
                Board board = new Board();
                board.WriteBoard();
                snake.Result();
                snake.Input();
                snake.Logic();
                snake.WriteSnake();
                snake.Shift();
              

            }

           

            /*
            //Login Attempts counter
            int loginAttempts = 0;

            //Simple iteration upto three times
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                if (username != "valid" || password != "valid")
                    loginAttempts++;
                else
                    break;
            }

            //Display the result
            if (loginAttempts > 2)
                Console.WriteLine("Login failure");
            else
                Console.WriteLine("Login successful");

         */

        

        }   
    }
}
