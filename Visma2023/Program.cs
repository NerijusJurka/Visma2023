using Visma2023;
internal class Program
{ 
    private static void Main(string[] args)
    {
        MenuInterface.StartUp();
        string command = Console.ReadLine();
        if (command == "1")
        {
            Login.LoginToSystem();
        }
        if (command == "2")
        {
            Registration.RegistrationToSystem();
        }
        if (command == "3")
        {
            Environment.Exit(0);
        }
    }
    public static void UserMenu(string name ,string role)
    {

        MenuInterface.Menu(name,role);
        string command = Console.ReadLine();
        if (command == "1")
        {
            Request.ShortageRequest(name, role);
        }
        if (command == "2")
        {
            if (role == "Basic")
            {
                BasicRequestViewFilter.Listing(name, role);
            }
            else if (role == "Admin")
            {
                AdminRequestViewFilter.Listing(name, role);
            }
        }
        if (command == "3")
        {
            Environment.Exit(0);
        }
    } 
}