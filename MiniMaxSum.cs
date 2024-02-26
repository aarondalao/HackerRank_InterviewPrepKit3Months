using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackerrank
{
    public class MiniMaxSum
    {
        public static void CalculateMinMaxSum(List<long> arr)
        {
            // declare and assign temporary minimum/maximum numbers
            long minSum = 0, maxSum = 0, minimumNumber = arr[0], maximumNumber = arr[arr.Count - 1]; // or arr[^1]


            // find minimum number and maximum 
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                if (minimumNumber >= arr[i])
                {
                    minimumNumber = arr[i];
                }

                if (maximumNumber <= arr[i])
                {
                    maximumNumber = arr[i];
                }
            }

            // to find the minimum numbers in the list, add all exept the maximum number and vise versa. if the minimum 
            // number is equal to max then its safe to assume all elements  in the list are all equal. truncate/chop one 
            //element in the array then just all 4 remaining elements.

            if (minimumNumber != maximumNumber)
            {
                for (int i = 0; i <= arr.Count - 1; i++)
                {
                    if (arr[i] != maximumNumber) minSum += arr[i];
                    if (arr[i] != minimumNumber) maxSum += arr[i];
                }
            }
            else
            {
                arr.RemoveRange(0, 1);
                for (int i = 0; i <= arr.Count - 1; i++)
                {
                    minSum += arr[i];
                    maxSum += arr[i];
                }
            }

            Console.WriteLine(minSum + " " + maxSum);
        }
    }

    public class MiniMaxSumInitialSetup
    {
        public static void Init()
        {
            Console.WriteLine("Problem set 2: MiniMaxSum}");
            Console.WriteLine("Enter 5 numbers separated by a space");

            List<long> arr = Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .ToList()
                .Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            MiniMaxSum.CalculateMinMaxSum(arr);
        }
    }
}