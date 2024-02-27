using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackerrank
{
    public class CamelCase4New
    {
        public static void Init()
        {
            string text = Console.ReadLine();
            if (text != null)
            {
                // Operation checker
                if (text[0] != 'S' && text[0] != 'C')
                {
                    Environment.Exit(0);
                }
                // edge case conversion checker
                if (text[2] != 'M' && text[2] != 'V' && text[2] != 'C')
                {
                    Environment.Exit(0);
                }
                // preliminary Split to extract the actual series of strings
                List<string> temp = text.Split(";").ToList();
                Console.WriteLine(conversionChecker(temp[0], temp[1], temp[2]));
            }
            else
            {
                Console.WriteLine("input is null");
                Environment.Exit(0);
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
        // convert to variable camel case
        public static string convertToVariableCamelCase(string e, string s)
        {
            string temp = " ", charToUpper = " ";
            int uppercaseCount = 0;
            if (e == "S") // Split Operation
            {
                // check the string if it has open and close parenthesis, if yes, remove it
                if (s.Contains('(') || s.Contains(')'))
                {
                    s = s.Substring(0, s.Length - 2);
                }
                // find the capital letter 
                for (int i = 0; i <= s.Count() - 1; i++)
                {
                    if (Char.IsUpper(s[i]) && i != 0)
                    {
                        uppercaseCount++;
                        if (uppercaseCount > 1)
                        {
                            temp = temp.Substring(0, i + uppercaseCount - 1);
                            temp = temp + " " + s.Substring(i);
                        }
                        else
                        {
                            // insert white space before the uppercase 
                            temp = s.Insert(i, " ");
                        }
                    }
                }
                s = temp;
                s = s.ToLower();
                return s;
            }
            else // Combine Operation
            {
                // replace small letters after each whitespaces
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                    {
                        temp = s.Substring(0, i);
                        charToUpper = s.Substring(i + 1, 1).ToUpper();
                        s = temp + charToUpper + s.Substring(i + 2);
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
            int uppercaseCount = 0;
            if (e == "S")
            {
                // check the string if it has open and close parenthesis, if yes, remove it
                if (s.Contains('(') || s.Contains(')'))
                {
                    s = s.Substring(0, s.Length - 2);
                }
                // find the capital letter 
                for (int i = 0; i <= s.Count() - 1; i++)
                {
                    if (Char.IsUpper(s[i]) && i != 0)
                    {
                        uppercaseCount++;
                        if (uppercaseCount > 1)
                        {
                            temp = temp.Substring(0, i + uppercaseCount - 1);
                            temp = temp + " " + s.Substring(i);
                        }
                        else
                        {
                            // insert white space before the uppercase 
                            temp = s.Insert(i, " ");
                        }
                    }
                }
                s = temp;
                s = s.ToLower();
                return s;
            }
            else
            {
                // replace small letters after each whitespaces
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                    {
                        // s = s.Replace(s[i+1], Char.ToUpper(s[i+1]));
                        temp = s.Substring(0, i);
                        charToUpper = s.Substring(i + 1, 1).ToUpper();
                        s = temp + charToUpper + s.Substring(i + 2);
                    }
                }
                if (!Char.IsLower(s[0]))
                {
                    temp = s.Substring(0, 1).ToLower();
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
            int uppercaseCount = 0;
            if (e == "S")
            {
                // check the string if it has open and close parenthesis, if yes, remove it
                if (s.Contains('(') || s.Contains(')'))
                {
                    s = s.Substring(0, s.Length - 2);
                }

                // find the capital letter 
                for (int i = 0; i <= s.Count() - 1; i++)
                {
                    if (Char.IsUpper(s[i]) && i != 0)
                    {
                        uppercaseCount++;
                        if (uppercaseCount > 1)
                        {
                            temp = temp.Substring(0, i + uppercaseCount - 1);
                            temp = temp + " " + s.Substring(i);
                        }
                        else
                        {
                            // insert white space before the uppercase 
                            temp = s.Insert(i, " ");
                        }
                    }
                }
                s = temp;
                s = s.ToLower();
                return s;
            }
            else
            {
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                    {
                        s = s.Replace(s[i + 1], Char.ToUpper(s[i + 1]));
                    }
                }
                if (!Char.IsUpper(s[0]))
                {
                    temp = s.Substring(0, 1).ToUpper();
                    s = temp + s.Substring(1);
                }
            }
            return s;
        }
    }
}