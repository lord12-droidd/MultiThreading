/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code
            Random randomizer = new Random();

            Task<int[]> task1 = new Task<int[]>(() => 
            {
                int[] array = new int[10];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = randomizer.Next(-150, 150);
                }
                Console.WriteLine($"Result of first task: {String.Join(",", array)}");
                return array;
            });
            task1.Start();
            Task<int[]> task2 = task1.ContinueWith((taskOneInfo) =>
            {
                int multiplier = randomizer.Next(2,5);
                int[] multipliedArray = taskOneInfo.Result;
                for (int i = 0; i < multipliedArray.Length; i++)
                {
                    multipliedArray[i] = multipliedArray[i] * multiplier;
                }
                Console.WriteLine($"Result of second task: {String.Join(",", multipliedArray)}");
                return multipliedArray;
            });
            Task<int[]> task3 = task2.ContinueWith((taskTwoInfo) =>
            {
                int[] sortedArray = taskTwoInfo.Result;
                Array.Sort(sortedArray);
                Console.WriteLine($"Result of third task: {String.Join(",", sortedArray)}");
                return sortedArray;
            });
            Task task4 = task3.ContinueWith((taskThreeInfo) =>
            {
                Console.WriteLine($"Result of fourth task: {String.Join(",", taskThreeInfo.Result.Average())}");
            });

            Console.ReadLine();
        }


    }
}
