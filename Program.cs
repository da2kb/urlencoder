using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLEncode
{
    class Program
    {
        
            static Dictionary<string, string> conversion = new Dictionary<string, string> {
            {" ", "%20"},
            {"<", "%3C"},
            {">", "%3E"},
            {"#", "%23"},
            {"\"", "%22"},
            {";", "%3B"},
            {"/", "%2F"},
            {"?", "%3F"},
            {":", "%3A"},
            {"@", "%40"},
            {"&", "%26"},
            {"=", "%3D"},
            {"+", "%2B"},
            {"$", "%24"},
            {",", "%2C"},
            {"{", "%7B"},
            {"}", "%7D"},
            {"|", "%7C"},
            {"\\", "%5C"},
            {"^", "%5E"},
            {"[", "%5B"},
            {"]", "%5D"},
            {"`", "%60"}

        };
            static bool checkInvalid(string value)
            {
                foreach (char C in value.ToCharArray())
                {
                    if ((C >= 0x00 && C <= 0x1F) || C == 0x7F)
                    {
                        return false;
                    }
                }
                return true;
            }
            static string Encode(string value)
            {
                foreach (var C in conversion)
                {
                    value = value.Replace(C.Key, C.Value);
                }
                return value;
            }
            static void Main(string[] args)
            {
                int loop = 1;
                while (loop != 0)
                {
                    Console.WriteLine("Please enter your project name:");
                    string x = Console.ReadLine();
                    checkInvalid(x);
                    while (checkInvalid(x) == false)
                    {
                        Console.WriteLine("Invalid project name. Please enter your project name again:");
                        x = Console.ReadLine();
                        checkInvalid(x);
                    }
                    x = Encode(x);
                    Console.WriteLine("Please enter your activity name:");
                    string y = Console.ReadLine();
                    checkInvalid(y);
                    while (checkInvalid(y) == false)
                    {
                        Console.WriteLine("Invalid activity name. Please enter your activity name again:");
                        y = Console.ReadLine();
                        checkInvalid(y);
                    }
                    y = Encode(y);

                    Console.WriteLine("Result URL:\n");

                    Console.WriteLine("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", x, y, y);
                    Console.WriteLine("Do you want to create a new URL? Click y for yes, n for no.");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        loop = 1;
                    }
                    if (ans == "n")
                    {
                        loop = 0;
                    }
                }

            }
        }
    }


    

