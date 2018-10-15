using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Array of Ints
        int[] array = { 8, 9, 20. 34, 5, 59, 1, 100, 93, 49, 7, 77 };
        
        int searchNum = 0;
        
        // Sort Array
        Array.Sort(array);
        
        Console.WriteLine("Which number would you like to search for?");
        bool result = Int32.TryParse(Console.ReadLine(), out searchNum);
        
        while(!result)
        {
            Console.WriteLine("Please enter a valid number:");
            result = Int32.TryParse(Console.ReadLine(), out searchNum);
        }
        
        int answer = BinarySearchRecur(array, searchNum);
        
        if(answer > 0)
        {
            Console.WriteLine("Found the number!");
        }
        else
        {
            Console.WriteLine("Number not found...");
        }
        
        Console.ReadLine();
    }
    
    public static int BinarySearch(int[] input, int searchNum)
    {
        int min = 0;
        int max = input.Length - 1;
        int mid = 0;
        
        while(min <= max)
        {
            // Finds the middle of the Array
            mid = (min + max) / 2;
            
            if(searchNum > input[mid])
            {
                // If the number is greater than the middle then
                // it resets the minimum to be one greater than
                // the middle
                min = mid + 1;
            }
            else
            {
                // If its less than the middle, then
                // it resets the maximum to be greater than
                // the middle
                max = mid + 1; 
            }
            
            if(searchNum == input[mid])
            {
                return mid;
            }
        }
        return -1;
    }
    
    public static int BinarySearchRecur(int[] input, int searchNum)
    {
        int min = 0;
        int max = input.Length - 1;
        int mid = (min + max) / 2;
        int j = 0;
        int midPoint = input[mid];
        
        // If the Array is of size one and the midpoint in not
        // the number, then it is not in the Array
        if((input.Length) <= 1 && (searchNum != midPoint))
        {
            return -1;
        }
        
        // If the number is less than the midpoint then it will split the Array in half and create a new one
        // and then recursively apply this function to the new Array
        
        if(searchNum < midPoint)
        {
            int[] array = new int[mid];
            for(int i = 0; i < mid; i++)
            {
                array[j] = input[i];
                j++;
            }
            return BinarySearchRecur(array, searchNum)
        }
        
        // If the number we are looking for is the midpoint then we are done
        // and it returns that number
        if(searchNum == midPoint)
        {
            return midPoint;
        }
    }
}
