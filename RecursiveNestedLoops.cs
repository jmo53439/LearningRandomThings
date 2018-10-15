using System.IO;
using System;

class Program
{
    static int numberOfLoops;
    static int numberOfIterations;
    static int[] loops;
    
    static void Main()
    {
        Console.Write("N = ");
        numberOfLoops = int.Parse(Console.ReadLine());
        
        Console.Write("K = ");
        numberOfIterations = int.Parse(Console.ReadLine());
        
        loops = new int[numberOfLoops];
        
        NestedLoops(0);
    }
    
    static void NestedLoops(int currentLoops)
    {
        if(currentLoop == numberOfLoops)
        {
            PrintLoops();
            return;
        }
        
        for(int counter = 1; counter <= numberOfIterations; counter++)
        {
            loops[currentLoop] = counter;
            NestedLoops(currentLoop + 1);
        }
    }
    
    static void PrintLoops()
    {
        for(int i = 0; i < numberOfLoops; i++)
        {
            Console.Write("{0} ", loops[i]);
        }
        
        Console.WriteLine();
    }
}
