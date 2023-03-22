
namespace Visma2023
{
    class MenuInterface
    {
        public static void Menu(string name, string role)
        {
            Console.Clear();
            Console.WriteLine("Welcome: " + name + " role:" + role);
            var consoleMenu = new List<string>();
            consoleMenu.Add("1.Register a new shortage");
            consoleMenu.Add("2.List all requests");
            consoleMenu.Add("3.Exit");
            foreach (var menu in consoleMenu)
            {
                Console.WriteLine(menu);
            }
        }
        public static void StartUp()
        {
            Console.Clear();
            var consoleMenu = new List<string>();
            consoleMenu.Add("1.Login");
            consoleMenu.Add("2.Register");
            consoleMenu.Add("3.Exit");
            consoleMenu.Add(" ");
            consoleMenu.Add("To use Admin register new user and change users role in user.json located in /temp folder ");
            foreach (var menu in consoleMenu)
            {
                Console.WriteLine(menu);
            }
        }
        public static void ShortageMenu()
        {
            var consoleMenu = new List<string>();
            consoleMenu.Add("");
            consoleMenu.Add("1.Filter by Title");
            consoleMenu.Add("2.Filter by CreatedOn");
            consoleMenu.Add("3.Filter by Category");
            consoleMenu.Add("4.Filter by Room");
            consoleMenu.Add("5.Remove Request");
            consoleMenu.Add("6.Exit");
            foreach (var menu in consoleMenu)
            {
                Console.WriteLine(menu);
            }
        }

    }
}
