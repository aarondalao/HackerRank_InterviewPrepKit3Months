using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackerrank
{
    public class CamelCase4InitSetup
    {
        public static void Init()
        {
            List<string> driverCode = ["S;M;plasticCup()", "C;V;mobile phone", "C;C;coffee machine",
                "S;C;LargeSoftwareBook", "C;M;white sheet of paper", "S;V;pictureFrame","S;C;HuHuHuHu"];
            
            // this can be removed 
            foreach (string item in driverCode)
            {
                // Operation checker
                if (item[0] != 'S' && item[0] != 'C')
                {
                    Environment.Exit(0);
                }
                // edge case conversion checker
                if (item[2] != 'M' && item[2] != 'V' && item[2] != 'C')
                {
                    Environment.Exit(0);
                }
                if (item[0] == 'S')
                {
                    Console.WriteLine(splitText(item));
                }
                if (item[0] == 'C')
                {
                    Console.WriteLine(combineText(item));
                }
            }
        }
        public static string conversionChecker(string extractionIdentifier, string convertIdentifier, string textToConvert)
        {
            string result = "";

            if (convertIdentifier == "V")
            {
                result = convertToVariableCamelCase(extractionIdentifier, textToConvert);
                return result;
            }

            if (convertIdentifier == "M")
            {
                result = convertToMethodCamelCase(extractionIdentifier, textToConvert);
                return result;
            }
            else // this is for the Class case
            {
                result = convertToClassCamelCase(extractionIdentifier, textToConvert);
                return result;
            }
        }
        // Split text
        public static string splitText(string text)
        {
            int uppercaseCount = 0;
            string result = "";
            // preliminary Split to extract the actual text
            List<string> temp = text.Split(";").ToList();
            // get the necessary text to split.
            text = temp[2];
            // check the string if it has open and close parenthesis, if yes, remove it
            if (text.Contains('(') || text.Contains(')'))
            {
                text = text.Substring(0, text.Length - 2);
            }
            // find the capital letter 
            for (int i = 0; i <= text.Count() - 1; i++)
            {
                if (Char.IsUpper(text[i]) && i != 0)
                {
                    uppercaseCount++;
                    if (uppercaseCount > 1)
                    {
                        result = result.Substring(0, i + uppercaseCount - 1);
                        result = result + " " + text.Substring(i);
                    }
                    else
                    {
                        // insert white space before the uppercase 
                        result = text.Insert(i, " ");
                    }
                }
            }
            result = conversionChecker(temp[0], temp[1], result);
            return result;
        }
        
        // Combine text
        public static string combineText(string text)
        {
            string result = " ";
            int whitespaceCount = 0;
            // preliminary Split to extract the actual text
            List<string> temp = text.Split(";").ToList();
            result = conversionChecker(temp[0], temp[1], temp[2]);
            // get the necessary text to split.
            text = result;
            for (int i = 0; i <= text.Count() - 1; i++)
            {
                if (Char.IsWhiteSpace(text[i]))
                {
                    whitespaceCount++;
                    // result = text.Replace(text[i],'\n');
                    if( whitespaceCount > 1)
                    {
                        result = result.Substring(0, i + whitespaceCount - 1);
                        result = result + " " + text.Substring(i);
                    }
                    result = text.Substring(0, i);
                    result += text.Substring(i+1);
                }
            }
            return result;
        }
        // convert to variable camel case
        public static string convertToVariableCamelCase(string e, string s)
        {   
            string temp = " ", charToUpper = " ";
            if (e == "S")
            {
                s = s.ToLower();
            }
            else
            {
                // replace small letters after each whitespaces
                for(int i = 0 ; i <= s.Length -1 ; i++)
                {
                    if(Char.IsWhiteSpace(s[i]))
                    {
                        temp = s.Substring(0,i);
                        charToUpper = s.Substring(i+1,1).ToUpper();
                        s = temp +  charToUpper + s.Substring(i+2);
                    }
                }

                if (!Char.IsLower(s[0]))
                {
                    s = s.Replace(s[0], Char.ToLower(s[0]));
                }
            }
            return s;
        }
        // convert to method camel case
        public static string convertToMethodCamelCase(string e, string s)
        {
            string temp = " ", charToUpper = " ";
            if (e == "S")
            {
                s = s.ToLower();
                return s;
            }
            else
            {
                // replace small letters after each whitespaces
                for(int i = 0 ; i <= s.Length -1 ; i++)
                {
                    if(Char.IsWhiteSpace(s[i]))
                    {
                        // s = s.Replace(s[i+1], Char.ToUpper(s[i+1]));
                        temp = s.Substring(0,i);
                        charToUpper = s.Substring(i+1,1).ToUpper();
                        s = temp +  charToUpper + s.Substring(i+2);
                    }
                }

                if (!Char.IsLower(s[0]))
                {
                    temp = s.Substring(0,1).ToLower();
                    s = temp + s.Substring(1);
                }
                s += "()";
            }
            return s;
        }
        // convert to class camelcase
        public static string convertToClassCamelCase(string e, string s)
        {
            string temp = " ";
            if (e == "S")
            {
                s = s.ToLower();
            }
            else
            {       
                for(int i = 0 ; i <= s.Length -1 ; i++)
                {
                    if(Char.IsWhiteSpace(s[i]))
                    {
                        s = s.Replace(s[i+1], Char.ToUpper(s[i+1]));
                    }
                }
                if (!Char.IsUpper(s[0]))
                {
                    temp = s.Substring(0,1).ToUpper();
                    s = temp + s.Substring(1);
                }
            }
            return s;
        }
    }
}