using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Visma2023;

namespace Visma2023
{
    enum Room
    {
        Meeting_room,
        Kitchen,
        Bathroom
    }

    enum Category
    {
        Electronics,
        Food,
        Other
    }
    class Request
    {
        public static void ShortageRequest(string name, string role)//Create Shortage request
        {
            Shortage shortage = new Shortage();
            Console.Clear();
            Console.WriteLine("Please enter the title: ");
            shortage.Title = GetInput(shortage.Title);

            Console.Clear();
            Console.WriteLine("Please enter the name: ");
            shortage.Name = GetInput(shortage.Name);

            Console.Clear();
            var t = RoomMenu();
            shortage.Room = t.ToString();

            Console.Clear();
            var r = CategoryMenu();
            shortage.Category = r.ToString();

            Console.Clear();
            var choice = PriorityCheck();
            shortage.Priority = choice;
            shortage.CreatedOn = DateTime.Now;
            shortage.CreatedBy = name;

            bool needNew = true;
            string filePath = @"C:\temp\shortage.json";
            var jsonData = System.IO.File.ReadAllText(filePath);//Read File
            var ShortageList = JsonConvert.DeserializeObject<List<Shortage>>(jsonData) ?? new List<Shortage>();//Deserialize

            for (int i = 0; i < ShortageList.Count; i++)
            {
                if (ShortageList[i].Title == shortage.Title && ShortageList[i].Room == shortage.Room)
                {
                    Console.Clear();
                    Console.WriteLine("This Shortage already exists. Do you want to update it ? Y/N");
                    string a = " ";
                    a = GetInput(a);
                    if (a == "Y")
                    {
                        if (ShortageList[i].Priority < shortage.Priority)
                        {
                            ShortageList[i].Priority = shortage.Priority;
                            needNew = false;
                        }
                        else { break; }
                    }
                    else { needNew = false; }
                }
            }
            if (needNew == true) //Creating new shortage request to json
            {
                ShortageList.Add(new Shortage()
                {
                    Title = shortage.Title,
                    Name = shortage.Name,
                    Room = shortage.Room,
                    Category = shortage.Category,
                    Priority = shortage.Priority,
                    CreatedOn = shortage.CreatedOn,
                    CreatedBy = shortage.CreatedBy
                });// Add to list
                var opt = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                jsonData = JsonConvert.SerializeObject(ShortageList, opt);//serialize
                System.IO.File.WriteAllText(filePath, jsonData);
                Program.UserMenu(name, role);
            }

            jsonData = JsonConvert.SerializeObject(ShortageList);//serialize
            System.IO.File.WriteAllText(filePath, jsonData);
            Program.UserMenu(name, role);
        }

        static string RoomMenu()
        {

            Console.WriteLine("Please pick from the list:\n\n");
            foreach (var room in Enum.GetValues(typeof(Room)))
            {
                Console.WriteLine($"{(int)room} - {room}");
            }
            Console.Write("\n\nEnter Choice > ");
            var result = Console.ReadLine();

            var choice = 0;
            Int32.TryParse(result, out choice);
            Room choice1 = (Room)choice;
            string t = choice1.ToString();
            return t;
        }

        static string CategoryMenu()
        {
            int n = 0;
            Console.WriteLine("Please pick from the list:\n\n");
            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{(int)category} - {category}");
            }
            var result = Console.ReadLine();

            var choice = 0;
            Int32.TryParse(result, out choice);
            Category choice1 = (Category)choice;
            string r = choice1.ToString();
            return r;
        }
        static int PriorityCheck()
        {
            Console.WriteLine("Please pick the priority level (0-10):");

            var result = Console.ReadLine();
            var choice = 0;
            Int32.TryParse(result, out choice);

            if (choice >= 0 && choice <= 10)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 0 and 10.");
                return PriorityCheck();
            }
        }
        public static string GetInput(string prop)
        {
            string result;
            do
            {
                result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.Clear();
                    Console.WriteLine($"{prop} cannot be empty. Please try again:");
                }
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }
    }
}
