using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Visma2023
{
    class Registration
    {
        private const string UserFilePath = @"C:\temp\user.json";

        public static async Task RegistrationToSystemAsync()
        {
            User user = new User();
            Console.Clear();
            Console.WriteLine("========== REGISTRATION ==========");
            Console.Write("Please enter your desired username: ");
            user.Name = Request.GetInput(user.Name);

            Console.Write("Please enter your password: ");
            user.Password = Request.GetInput(user.Password);

            user.Role = "Basic";
            user.Id = Guid.NewGuid().GetHashCode();

            if (!File.Exists(UserFilePath))
            {
                File.Create(UserFilePath).Dispose();
            }

            bool exists = await CheckIfExistAsync(user.Name);

            if (exists)
            {
                Console.Clear();
                Console.WriteLine("Username already taken. Please choose a different one.");
                await RegistrationToSystemAsync();
            }
            else
            {
                List<User> userList = new List<User>();
                string jsonData = await File.ReadAllTextAsync(UserFilePath);
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    userList = JsonConvert.DeserializeObject<List<User>>(jsonData);
                }

                userList.Add(user);
                jsonData = JsonConvert.SerializeObject(userList, Formatting.Indented);
                await File.WriteAllTextAsync(UserFilePath, jsonData);

                Console.Clear();
                Console.WriteLine("Registration successful!");
                Console.WriteLine("Press any key to continue to login...");
                Console.ReadKey();

                await Login.LoginToSystemAsync();
            }
        }

        public static async Task<bool> CheckIfExistAsync(string name)
        {
            try
            {
                string jsonData = await File.ReadAllTextAsync(UserFilePath);
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var username = JsonConvert.DeserializeObject<List<User>>(jsonData)
                        .Where(u => u.Name == name)
                        .Select(u => u.Name);
                    return username.Count() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if username exists: {ex.Message}");
                return false;
            }
        }
    }
}