namespace Visma2023
{
    class MenuInterface
    {
        public static void Menu(string name, string role)
        {
            Console.Clear();
            Console.WriteLine($"Welcome: {name} role: {role}");
            var consoleMenu = new List<string>
            {
                "1.Register a new shortage",
                "2.List all requests",
                "3.Exit"
            };
            consoleMenu.ForEach(Console.WriteLine);
        }

        public static void StartUp()
        {
            Console.Clear();
            var consoleMenu = new List<string>
            {
                "1.Login",
                "2.Register",
                "3.Exit",
                " ",
                "To use Admin register new user and change users role in user.json located in /temp folder"
            };
            consoleMenu.ForEach(Console.WriteLine);
        }

        public static int ShortageMenu()
        {
            Console.Clear();
            var consoleMenu = new List<string>
            {
                "",
                "1.Filter by Title",
                "2.Filter by CreatedOn",
                "3.Filter by Category",
                "4.Filter by Room",
                "5.Remove Request",
                "6.Exit"
            };
            consoleMenu.ForEach(Console.WriteLine);

            int command;
            while (!int.TryParse(Console.ReadLine(), out command))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            return command;
        }
    }
}