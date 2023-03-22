using Newtonsoft.Json;
using System.Text.Json;

namespace Visma2023
{
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
                    Console.WriteLine("This Shortage already exist. Do you want to update it ? Y/N");
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
            if (needNew == true) //Creating new shortage to json
            {
                    ShortageList.Add(new Shortage() { Title = shortage.Title, Name = shortage.Name, Room = shortage.Room,
                        Category = shortage.Category, Priority = shortage.Priority, CreatedOn = shortage.CreatedOn, CreatedBy = shortage.CreatedBy });// Add to list
                    var opt = new JsonSerializerOptions() { WriteIndented = true };
                    jsonData = JsonConvert.SerializeObject(ShortageList);//serialize
                    System.IO.File.WriteAllText(filePath, jsonData);
                    Program.UserMenu(name, role);
            }

            jsonData = JsonConvert.SerializeObject(ShortageList);//serialize
            System.IO.File.WriteAllText(filePath, jsonData);
            Program.UserMenu(name, role);

            string RoomMenu()
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
            string CategoryMenu()
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
            int PriorityCheck()
            {
                Console.WriteLine("Please choose number for priority level 1-10");
                string input = Console.ReadLine();
                int choice;
                Int32.TryParse(input, out choice);
                if (choice <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid range scope");
                    PriorityCheck();
                    return 0;
                }
                if (choice > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid range scope");
                    PriorityCheck();
                    return 0;
                }
                else
                {
                    return choice;
                }
            }

        }
        public static string GetInput(string Prompt)//Readline Cannot be null or empty validation
        {
            string Result = "";
            do
            {
                Console.Write(Prompt + ": ");
                Result = Console.ReadLine();
                if (string.IsNullOrEmpty(Result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(Result));
            return Result;
        }

        //Fixed Values
        public enum Room
        {
            Meeting_Room,
            Kitchen,
            Bathroom

        }
        public enum Category
        {
            Electronics,
            Food,
            Other
        }
    }
}
