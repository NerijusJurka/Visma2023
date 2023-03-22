using Newtonsoft.Json;
using System.Text.Json;

namespace Visma2023
{
    class Registration
    {
        public static async void RegistrationToSystem()
        {
             User user = new User();
            Console.Clear();
            Console.WriteLine("REGISTRATION");
            Console.WriteLine("Please Enter your UserName");
             user.Name = Request.GetInput(user.Name);

             Console.WriteLine("Please Enter your password");
             user.Password = Request.GetInput(user.Password);
             user.Role = "Basic";
            bool exits = false;
            string filePath = @"C:\temp\user.json";
            var jsonData = System.IO.File.ReadAllText(filePath);//Read File
            var UserList = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();//Deserialize
            exits = CheckIfExist(user.Name,jsonData,exits);
            if (exits == true)
            {
                Console.Clear();
                Console.WriteLine("Username already taken");
                RegistrationToSystem();
                
            }
            else if (exits == false)
            {
                UserList.Add(new User() {Name = user.Name, Password = user.Password, Role = user.Role });// Add to list
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                jsonData = JsonConvert.SerializeObject(UserList);//serialize
                System.IO.File.WriteAllText(filePath, jsonData);
                Login.LoginToSystem();
            }
        }
        public static bool CheckIfExist(string name,string? jsonData,bool exits)//Checking if username is taken or not if taken returns true
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<User[]>(jsonData);
            var username = from item in result where item.Name == name select item.Name;
            foreach(var x in  username)
            {
                if (name == x)
                {
                    exits = true;
                    break;
                }
            }
            if (username == null) 
            {
                exits = false;
            }
            return exits;
        }
    } 
}
