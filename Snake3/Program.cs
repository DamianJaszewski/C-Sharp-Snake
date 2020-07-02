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
                snake.Input();
                snake.Logic();
                snake.WriteSnake();
                snake.Shift();
                
            }

        }   
    }
}
