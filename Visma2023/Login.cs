using Newtonsoft.Json;
using Visma2023;

class Login
{
    public static User AuthenticatedUser { get; private set; }

    public static async Task<bool> LoginToSystemAsync()
    {
        bool check = false;
        do
        {
            Console.Clear();
            Console.WriteLine("========== LOGIN ==========");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = ReadPassword();

            string path = @"C:\temp\user.json";
            var jsonData = File.ReadAllText(path);
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();

            foreach (var user in userList)
            {
                if (user.Name == username && user.Password == password)
                {
                    check = true;
                    AuthenticatedUser = user;
                    break;
                }
            }

            if (!check)
            {
                Console.WriteLine("\nIncorrect username or password. Press ESC to exit or any other key to try again.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }

        } while (!check);

        return true;
    }

    private static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape)
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        return password;
    }
}
