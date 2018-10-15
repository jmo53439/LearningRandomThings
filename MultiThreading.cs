using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Program
{
    static char[] letters = { 'a', 'b', 'c', 'd', 'e' };
    static char[] numbers = { '1', '2', '3', '4', '5' };
    
    static void PrintNumbers()
    {
        for(int i = 0; i < 5; i++)
        {
            Console.Write(numbers[i] + " ");
            Thread.Sleep(10);
        }
    }
    
    static void PrintLetters()
    {
        for(int i = 0; i < 5; i++)
        {
            Console.Write(letters[i] + " ");
            Thread.Sleep(10);
        }
    }
    
    static void Main(string[] args)
    {
        Thread t1 = new Thread(PrintNumbers);
        Thread t2 = new Thread(PrintLetters);
        
        t1.Start();
        t2.Start();
    } 
}
