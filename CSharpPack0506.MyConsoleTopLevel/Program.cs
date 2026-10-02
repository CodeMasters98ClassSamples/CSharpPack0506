
//Temp
//Declare Vaiable -> Syntax C#

//DataType name = value
//Initial Value
int number = default;
int number2 = 255;
long number3 = 0;

number2 = (int)number3;

number = number2;
byte b = default;
bool isAdmin = false;
char c = 'C';
string name = Console.ReadLine();



Console.Write("Enter your mobile number: ");
string mobile = Console.ReadLine();

if (mobile.Length == 10) 
{
	if (mobile.StartsWith("9"))
	{
        mobile = "0" + mobile;
    }
}

if (mobile.Length == 10 && mobile.StartsWith("9"))
{
    mobile = "0" + mobile;
}

Console.WriteLine("Your mobile number is: " + mobile);
for (int i = 0; i <= 10; i++)
{
    Random random = new Random(); //Technical deb
    var r = random.Next(10, 20000);
    Console.WriteLine(i + " - " + r);
}

Console.Write("Enter a number: ");
int number1 = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i <= number1; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine($"{i} is Even");
    }
    else
    {
        Console.WriteLine($"{i} is Odd");
    }
}

Console.WriteLine("***********");
for (int i = 0; i < 10; i++)
{
    if (i == 4)
    {
        continue;
    }
    if (i == 9)
    {
        break;
    }
    Console.WriteLine(i * i);
}

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
    //What you want to do!!!
    //Calc Wallet
    //Double check data loop
}


//Block => generate random number
//Random random = new Random();
//var r = random.Next(10, 1000);
//Console.WriteLine(r);
int index = 0;
while (index < 5)
{
    Console.WriteLine(index * index);
    index++;
}
Console.WriteLine("***********");
int index2 = 0;
do
{
    Console.WriteLine(index2 * index2);
    index2++;
} while (index2 < 5);
