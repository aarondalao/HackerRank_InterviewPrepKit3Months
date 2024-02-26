using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackerrank
{
    public class PlusMinus
    {
        public static void AddAndSubtract(List<int> arr)
        {
            decimal arrayCount = arr.Count, post = 0, nega = 0, zero = 0;
            foreach (int a in arr)
            {
                if (a > 0)
                {
                    post++;
                }
                else if (a < 0)
                {
                    nega++;
                }
                else
                {
                    zero++;
                }
            }
            Console.WriteLine("{0:F6}", post /= arrayCount);
            Console.WriteLine("{0:F6}", nega /= arrayCount);
            Console.WriteLine("{0:F6}", zero /= arrayCount);
        }
    }

    public class PlusMinusInitialSetup
    {

        public static void Init()
        {   
            Console.WriteLine("Problem set 1: PlusMinus");
            Console.WriteLine("Enter 5 numbers separated by a space");

            List<int> arr = Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .ToList()
                .Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            PlusMinus.AddAndSubtract(arr);
        }
    }
}