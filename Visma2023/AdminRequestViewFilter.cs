using Newtonsoft.Json;

namespace Visma2023
{
    class AdminRequestViewFilter
    {
        private const string FilePath = @"C:\temp\shortage.json";

        public static void Listing(string name, string role)
        {
            if (role != "Admin")
            {
                Console.WriteLine("Access denied. This feature is only available to users with admin role.");
                return;
            }

            Console.Clear();

            var jsonData = System.IO.File.ReadAllText(FilePath);
            var result = JsonConvert.DeserializeObject<Shortage[]>(jsonData);

            var shortages = result.Select(item => new
            {
                item.Title,
                item.Name,
                item.Room,
                item.Category,
                item.Priority,
                item.CreatedOn,
            });

            var filterByPriority = shortages.OrderByDescending(x => x.Priority);

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

            while (command != 6)
            {
                switch (command)
                {
                    case 1: // FilterByTitle
                        var filterByTitle = shortages.OrderBy(x => x.Title).ThenByDescending(x => x.Priority);
                        DisplayShortages(filterByTitle);
                        break;
                    case 2: // FilterByCreatedOn
                        var filterByCreatedOn = shortages.OrderBy(x => x.CreatedOn).ThenByDescending(x => x.Priority);
                        DisplayShortages(filterByCreatedOn);
                        break;
                    case 3: // FilterByCategory
                        var filterByCategory = shortages.OrderBy(x => x.Category).ThenByDescending(x => x.Priority);
                        DisplayShortages(filterByCategory);
                        break;
                    case 4: // FilterByRoom
                        var filterByRoom = shortages.OrderBy(x => x.Room).ThenByDescending(x => x.Priority);
                        DisplayShortages(filterByRoom);
                        break;
                    case 5: // DeleteRequest
                        DeleteRequest();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }

                MenuInterface.ShortageMenu();
                command = Convert.ToInt32(Console.ReadLine());
            }

            Program.UserMenu(name, role);
        }

        private static void DisplayShortages(IEnumerable<dynamic> shortages)
        {
            Console.Clear();

            foreach (var item in shortages)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" Title: " + item.Title);
                Console.WriteLine(" Name: " + item.Name);
                Console.WriteLine(" Room: " + item.Room);
                Console.WriteLine(" Category: " + item.Category);
                Console.WriteLine(" Priority: " + item.Priority);
                Console.WriteLine(" CreatedOn: " + item.CreatedOn);
            }
        }

        private static void DeleteRequest()
        {
            Console.WriteLine("Please enter request Title you want to delete: ");
            string removeRequest;
            while (string.IsNullOrWhiteSpace(removeRequest = Console.ReadLine())) ;

            var jsonData = System.IO.File.ReadAllText(FilePath);
            var resultList = JsonConvert.DeserializeObject<List<Shortage>>(jsonData);
            resultList = resultList.Where(x => x.Title != removeRequest).ToList();
            jsonData = JsonConvert.SerializeObject(resultList);
            System.IO.File.WriteAllText(FilePath, jsonData);
        }
    }
}
