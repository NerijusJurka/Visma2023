using Newtonsoft.Json;

namespace Visma2023
{
    class Login
    {
        public static void LoginToSystem()
        {
            bool check = false;
            do
            {
                Console.Clear();
                Console.WriteLine("LOGIN");
                Console.WriteLine("Please enter your login name: ");
                string name = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Please enter your login password");
                string password = Console.ReadLine();
                string path = @"C:\temp\user.json";

                var jsonData = System.IO.File.ReadAllText(path);//Read File
                var UserList = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();//Deserialize
                for (int i = 0; i < UserList.Count; i++)
                {
                    if (name == UserList[i].Name && password == UserList[i].Password)
                    {
                        check = true;
                        if (UserList[i].Role == "Basic")
                        {
                            Program.UserMenu(UserList[i].Name,UserList[i].Role);
                            break;
                        }
                        if (UserList[i].Role == "Admin")
                        {
                            Program.UserMenu(UserList[i].Name, UserList[i].Role);
                            break;
                        }
                    }
                    else if (name != UserList[i].Name || password != UserList[i].Password)
                    {
                        Console.WriteLine("Incorrect Name or Password");
                    }
                }
            }
            while (check == false);

        }
    }
}
