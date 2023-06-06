using System;
using System.Threading.Tasks;

namespace Visma2023
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Visma2023 System!");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");
                Console.WriteLine("3 - Exit");
                Console.Write("Please choose an option: ");

                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case "1":
                        if (await Login.LoginToSystemAsync())
                        {
                            User user = Login.AuthenticatedUser;
                            await UserMenu(user.Name, user.Role);
                        }
                        break;

                    case "2":
                        await Registration.RegistrationToSystemAsync();
                        Console.WriteLine("Press any key to continue to login...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid command. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static async Task UserMenu(string name, string role)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {name} ({role})!");
                Console.WriteLine("1 - Request a shortage");
                Console.WriteLine("2 - View requests");
                Console.WriteLine("3 - Logout");
                Console.Write("Please choose an option: ");

                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case "1":
                        Request.ShortageRequest(name, role);
                        break;

                    case "2":
                        if (role == "Basic")
                        {
                            BasicRequestViewFilter.Listing(name, role);
                        }
                        else if (role == "Admin")
                        {
                            AdminRequestViewFilter.Listing(name, role);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Logout successful. Press any key to continue...");
                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Invalid command. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}