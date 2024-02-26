using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackerrank
{
    public class BreakingTheRecord
    {
        public static List<int> CalculateLeastAndMostPoints(List<int> scores)
        {
            // // first element is the max points, 2nd element is the least points
            // List<int> maxMinPointCount = [0, 0];
            // for some unknown reason, shorthand initialization on a list using a square bracket 
            // is not allowed in HackerRank. so make it a longhand.
            List<int> maxMinPointCount = new List<int>() {0,0}; 
            int tempHighScore = scores[0], tempLowScore = scores[0];


            for (int i = 1; i <= scores.Count - 1; i++)
            {
                if (tempLowScore > scores[i] && tempLowScore != scores[i])
                { 
                    maxMinPointCount[1] += 1;
                    tempLowScore = scores[i];
                }

                if(tempHighScore < scores[i] && tempHighScore != scores[i])
                {
                    maxMinPointCount[0] += 1;
                    tempHighScore = scores[i];
                }
            }

            return maxMinPointCount;
        }
    }
    public class BreakingRecordInitSetup
    {
        public static void Init()
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            // int n = Convert.ToInt32(Console.ReadLine().Trim());

            // List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

            // List<int> result = BreakingTheRecord.BreakingRecords(scores);

            // textWriter.WriteLine(String.Join(" ", result));

            // textWriter.Flush();
            // textWriter.Close();

            Console.WriteLine("Problem set 4: Breaking the Record");

            int n = Convert.ToInt32(Console.ReadLine().Trim());


            List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

            List<int> result = BreakingTheRecord.CalculateLeastAndMostPoints(scores);
            Console.WriteLine(result);
        }
    }
}