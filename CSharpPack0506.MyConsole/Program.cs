using System.Reflection;

namespace CSharpPack0506.MyConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num1Str = Console.ReadLine();
            string num2Str = Console.ReadLine();
            int result = Sum(num1Str, num2Str);
            Console.WriteLine(result);

            //(int i = 0; i < 5; i++)
            string mobile = "";
            do
            {
                //0912956420y
                Console.WriteLine("mobile?");
                mobile = Console.ReadLine();
                if (string.IsNullOrEmpty(mobile))
                {
                    Console.WriteLine("try again");
                    continue;
                }

                //Call a function => فراخوانی متد
                mobile = FormatMobileNumber(mobile);
                break;
            } while (true);

            Console.WriteLine("Age?");
            string ageStr = Console.ReadLine();
            int age = int.Parse(ageStr);
            string role = "xxxx";
            int discount = 0;

            switch (role)
            {
                case "admin":
                    discount = 10;
                    break;
                case "technical":
                    discount = 30;
                    break;
                default:
                    discount = 0;
                    break;
            }


            if (role == "admin")
            {
                discount = 10;
            }
            else if (role == "technical")
            {
                discount = 20;
            }
            else
            {
                discount = 0;
            }
            if (result < 50)
            {
                Console.WriteLine("alskndfad");
            }
            else
            {

            }

        }

        // دو تا عدد از کاربر دریافت نمایید و 
        // به وسیله متد جمع آن را جمع کرده و 
        // عدد دریافت شده از متد را نمایش دهید

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Sum(string num1, string num2)
        {
            return int.Parse(num1) + int.Parse(num2);
        }

        static int Sum(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        //Write a function / func
        static string FormatMobileNumber(string mobile)
        {
            mobile = mobile.ToLower().Trim();
            if (mobile.StartsWith("+98"))
            {
                mobile = mobile.Replace("+98", "0");
            }
            if (mobile.Length == 10 && mobile.StartsWith("9"))
            {
                Console.WriteLine("0" + mobile);
            }
            return mobile;
        }

        static decimal CalculateSalary(string employee)
        {
            int x = 10;
            switch (employee)
            {
                case "ava":
                    return 1000000;
                case "nazanin":
                    return 100;
                case "nargess":
                    return 10000000;
                case "asal":
                    return 101;
                default:
                    break;
            }
            return 1;
        }
    }
}
