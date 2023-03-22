using Newtonsoft.Json;

namespace Visma2023
{
    internal class AdminRequestViewFilter
    {
        public static void Listing(string name, string role)
        {
            Console.Clear();
            string filePath = @"C:\temp\shortage.json";
            var jsonData = System.IO.File.ReadAllText(filePath);//Read File
            var result = System.Text.Json.JsonSerializer.Deserialize<Shortage[]>(jsonData);

            var shortages = from item in result
                            select new
                            {
                                Title = item.Title,
                                Name = item.Name,
                                Room = item.Room,
                                Category = item.Category,
                                Priority = item.Priority,
                                CreatedOn = item.CreatedOn,
                            };
            var filterByPriority = from x in shortages orderby x.Priority descending select x;
            foreach (var item in filterByPriority)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" Title: " + item.Title);
                Console.WriteLine(" Name: " + item.Name);
                Console.WriteLine(" Room: " + item.Room);
                Console.WriteLine(" Category: " + item.Category);
                Console.WriteLine(" Priority: " + item.Priority);
                Console.WriteLine(" CreatedOn: " + item.CreatedOn);
            }
            MenuInterface.ShortageMenu();
            int command = Convert.ToInt32(Console.ReadLine());
            if (command == 1)//FilterByTitle
            {
                var filterByTitle = from x in shortages orderby x.Title select x;
                var filterByTitleP = from x in filterByTitle orderby x.Priority descending select x;
                Console.Clear();
                foreach (var item in filterByTitleP)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" Title: " + item.Title);
                    Console.WriteLine(" Name: " + item.Name);
                    Console.WriteLine(" Room: " + item.Room);
                    Console.WriteLine(" Category: " + item.Category);
                    Console.WriteLine(" Priority: " + item.Priority);
                    Console.WriteLine(" CreatedOn: " + item.CreatedOn);
                }
                MenuInterface.ShortageMenu();
                command = Convert.ToInt32(Console.ReadLine());
            }
            if (command == 2)//FilterByCreatedOn
            {
                var filterByCreatedOn = from x in shortages orderby x.CreatedOn select x;
                var filterByCreatedOnP = from x in filterByCreatedOn orderby x.Priority descending select x;
                Console.Clear();
                foreach (var item in filterByCreatedOnP)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" Title: " + item.Title);
                    Console.WriteLine(" Name: " + item.Name);
                    Console.WriteLine(" Room: " + item.Room);
                    Console.WriteLine(" Category: " + item.Category);
                    Console.WriteLine(" Priority: " + item.Priority);
                    Console.WriteLine(" CreatedOn: " + item.CreatedOn);
                }
                MenuInterface.ShortageMenu();
                command = Convert.ToInt32(Console.ReadLine());
            }
            if (command == 3)//FilterByCategory
            {
                var filterByCategory = from x in shortages orderby x.Category select x;
                var filterByCategoryP = from x in filterByCategory orderby x.Priority descending select x;
                Console.Clear();
                foreach (var item in filterByCategoryP)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" Title: " + item.Title);
                    Console.WriteLine(" Name: " + item.Name);
                    Console.WriteLine(" Room: " + item.Room);
                    Console.WriteLine(" Category: " + item.Category);
                    Console.WriteLine(" Priority: " + item.Priority);
                    Console.WriteLine(" CreatedOn: " + item.CreatedOn);
                }
                MenuInterface.ShortageMenu();
                command = Convert.ToInt32(Console.ReadLine());
            }
            if (command == 4)//FilterByRoom
            {
                var filterByRoom = from x in shortages orderby x.Category select x;
                var filterByRoomP = from x in filterByRoom orderby x.Priority descending select x;
                Console.Clear();
                foreach (var item in filterByRoom)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" Title: " + item.Title);
                    Console.WriteLine(" Name: " + item.Name);
                    Console.WriteLine(" Room: " + item.Room);
                    Console.WriteLine(" Category: " + item.Category);
                    Console.WriteLine(" Priority: " + item.Priority);
                    Console.WriteLine(" CreatedOn: " + item.CreatedOn);
                }
                MenuInterface.ShortageMenu();
                command = Convert.ToInt32(Console.ReadLine());
            }
            if (command == 5)//Delete Request
            {

                Console.WriteLine("Please enter request Title you want to delete: ");
                string removeRequest;
                while (string.IsNullOrWhiteSpace(removeRequest = Console.ReadLine())) ;
                var resultList = System.Text.Json.JsonSerializer.Deserialize<List<Shortage>>(jsonData);
                resultList = resultList.Where(x => x.Title != removeRequest).ToList();
                var user = resultList.Where(x => x.Title != removeRequest).ToList();
                jsonData = JsonConvert.SerializeObject(user);
                System.IO.File.WriteAllText(filePath, jsonData);
                Listing(name, role);
            }
            if (command == 6)//Exit
            {
                Program.UserMenu(name, role);
            }
        }
    }
}
