using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMergeSort
{
    class Program
    {
        /*
        Since we didn't get a chance to do this
        on pen and paper, I thought I'd whip it
        up real quick for that guaranteed position ;) 
        I promise I didn't build this until the end!

        I was going to write actual tests for this,
        but that's way too much work for a joke.
        */


        public static void Main(string[] args)
        {
            int[] data = new int[100];
            Random generate = new Random();

            for (int i = 0; i < 100; i++)
            {
                data[i] = generate.Next(-100, 100);
            }

            Console.WriteLine("Unsorted:");
            Print(data);
            data = MergeSort(data);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted:");
            Print(data);
            Console.ReadLine();
        }

        public static int[] MergeSort(int[] unsorted)
        {
            if (unsorted.Length <= 1)
            {
                return unsorted;
            }

            //Integer division is intentional.
            int middle = unsorted.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[unsorted.Length - middle];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = unsorted[i];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = unsorted[middle + i];
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int index = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length || rightIndex < right.Length)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex] < right[rightIndex])
                    {
                        result[index] = left[leftIndex];
                        index++;
                        leftIndex++;
                    }
                    else
                    {
                        result[index] = right[rightIndex];
                        index++;
                        rightIndex++;
                    }
                }
                else if (leftIndex < left.Length)
                {
                    result[index] = left[leftIndex];
                    index++;
                    leftIndex++;
                }
                else if (rightIndex < right.Length)
                {
                    result[index] = right[rightIndex];
                    index++;
                    rightIndex++;
                }
            }
            return result;
        }

        public static void Print(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("{0} ", data[i]);
                if (i % 10 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
