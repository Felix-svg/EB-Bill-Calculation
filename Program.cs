using System;

namespace EBBillCalculation;

class Program
{
    static void Main(string[] args)
    {
        bool bill = false;

        do
        {
            User user = new();
            MainMenu(user);

            Console.WriteLine("Do you want to continue? (Y/N)");
            string userChoice = Console.ReadLine().ToUpper().Trim();
            // do
            // {
            if (userChoice == "Y")
            {
                bill = true;
            }
            else if(userChoice == "N")
            {
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again");
            }
            //} while (userChoice == "Y" || userChoice== "N");
        } while (bill == true);
    }

    public static List<User> users = new List<User>();

    static void MainMenu(User user)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Registration");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            Registration();
        }
        else if (userChoice == "2")
        {
            Login(user);
        }
        else if (userChoice == "3")
        {
            Environment.Exit(1);
        }
    }

    static void SubMenu(User user)
    {
        Console.WriteLine("Choose an option");
        Console.WriteLine("1. Calculate amount");
        Console.WriteLine("2. Display my details");
        Console.WriteLine("3. Exit");

        string userChoice = Console.ReadLine();
        if (userChoice == "1")
        {
            Console.WriteLine("Enter units used");
            int unitsUsed = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your bill amount is {string.Format("{0:C}", CalculateAmount(unitsUsed))}");
        }
        else if (userChoice == "2")
        {
            DisplayUserDetails(user);
        }
        else if (userChoice == "3")
        {
            MainMenu(user);
        }
    }

    static void Registration()
    {
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your phone number");
        string phonenumber = Console.ReadLine();
        Console.WriteLine("Enter your mail id");
        string mailId = Console.ReadLine();

        User user = new();
        user.Username = name;
        user.PhoneNumber = phonenumber;
        user.MailId = mailId;
        user.MeterID = GenerateMeterId(user);

        Console.WriteLine(user.MeterID);
        users.Add(user);
    }

    static string validatedMeterID;
    static string Login(User user)
    {
        Console.WriteLine("Enter your meter id");
        string meterId = Console.ReadLine();

        foreach (User user1 in users)
        {
            if (user1.MeterID == meterId)
            {
                validatedMeterID = meterId;
                SubMenu(user);
                break;
            }
            else
            {
                Console.WriteLine("Invalid User ID");
            }
        }
        return validatedMeterID;
    }

    static int CalculateAmount(int units)
    {
        return units * 5;
    }

    static void DisplayUserDetails(User user)
    {
        string id = validatedMeterID;
        foreach (User user1 in users)
        {
            if (user1.MeterID == id)
            {
                Console.WriteLine($"Meter ID - ({user1.MeterID})\nUsername: {user1.Username}\nPhone number: {user1.PhoneNumber}\nMail Id: {user1.MailId}");
                break;
            }
        }
    }

    static string GenerateMeterId(User user)
    {
        user.MeterID = $"EB100{1 + users.Count}";

        return user.MeterID;
    }
}