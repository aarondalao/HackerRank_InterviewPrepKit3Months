using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace hackerrank
{
    public class TimeConversion
    {
        public static string CalculateTimeConversion(string s)
        {

            // we are only concerned about the hour bit and the am/pm bit as these will
            // determine the correct 24 hour time
            

            List<string> timeList = s.Split(":").ToList();
            
            if (s[8] == 'A')
            {
                
                if(s[0] == '1' && s[1] == '2')
                {
                    timeList[0] = "00";
                }
            }
            else{
                
                if(s[0] == '0' && s[1] == '1')
                {
                    timeList[0] = "13";
                }

                if(s[0] == '0' && s[1] == '2')
                {
                    timeList[0] = "14";
                }

                if(s[0] == '0' && s[1] == '3')
                {
                    timeList[0] = "15";
                }

                if(s[0] == '0' && s[1] == '4')
                {
                    timeList[0] = "16";
                }

                if(s[0] == '0' && s[1] == '5')
                {
                    timeList[0] = "17";
                }

                if(s[0] == '0' && s[1] == '6')
                {
                    timeList[0] = "18";
                }

                if(s[0] == '0' && s[1] == '7')
                {
                    timeList[0] = "19";
                }

                if(s[0] == '0' && s[1] == '8')
                {
                    timeList[0] = "20";
                }

                if(s[0] == '0' && s[1] == '9')
                {
                    timeList[0] = "21";
                }

                if(s[0] == '1' && s[1] == '0')
                {
                    timeList[0] = "22";
                }

                if(s[0] == '1' && s[1] == '1')
                {
                    timeList[0] = "23";
                }
            } 
            s = string.Join(":", timeList);
            s = s.Substring(0, 8);
            // s = s.Remove(8, 2);

            
            return s;
        }
    }

    public class TimeConversionInitSetup
    {
        public static void Init()
        {
            // TextWriter textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            Console.WriteLine("Problem set 3: Time conversion");
            Console.WriteLine("enter AM/PM time to be converted (format: hh:mm:ssAM OR hh:mm:ssPM):");

            string s = Console.ReadLine();

            string result = TimeConversion.CalculateTimeConversion(s);
            Console.WriteLine(result);

            // textWriter.WriteLine(result + " using stream writer");
            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}