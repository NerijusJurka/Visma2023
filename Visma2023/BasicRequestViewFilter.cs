using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Visma2023
{
    class BasicRequestViewFilter
    {
        private const string filePath = @"C:\temp\shortage.json";

        public static void Listing(string name, string role)
        {
            if (role != "Basic")
            {
                Console.WriteLine("Error: Only users with 'basic' role can access this feature.");
                return;
            }

            Console.Clear();

            var result = JsonConvert.DeserializeObject<List<Shortage>>(File.ReadAllText(filePath));

            var shortages = result.Where(item => item.CreatedBy == name)
                                  .Select(item => new
                                  {
                                      Title = item.Title,
                                      Name = item.Name,
                                      Room = item.Room,
                                      Category = item.Category,
                                      Priority = item.Priority,
                                      CreatedOn = item.CreatedOn,
                                  });

            var filterByPriority = shortages.OrderByDescending(x => x.Priority);

            PrintShortages(filterByPriority);

            while (true)
            {
                int command = MenuInterface.ShortageMenu();
                if (command == 1)
                {
                    var filterByTitle = shortages.OrderBy(x => x.Title).ThenByDescending(x => x.Priority);
                    PrintShortages(filterByTitle);
                }
                else if (command == 2)
                {
                    var filterByCreatedOn = shortages.OrderBy(x => x.CreatedOn).ThenByDescending(x => x.Priority);
                    PrintShortages(filterByCreatedOn);
                }
                else if (command == 3)
                {
                    var filterByCategory = shortages.OrderBy(x => x.Category).ThenByDescending(x => x.Priority);
                    PrintShortages(filterByCategory);
                }
                else if (command == 4)
                {
                    var filterByRoom = shortages.OrderBy(x => x.Room).ThenByDescending(x => x.Priority);
                    PrintShortages(filterByRoom);
                }
                else if (command == 5)
                {
                    Console.WriteLine("Please enter request Title you want to delete: ");
                    string removeRequest = Console.ReadLine().Trim();
                    result.RemoveAll(x => x.Title == removeRequest);
                    var user = result.Where(x => x.CreatedBy == name).ToList();
                    var jsonData = JsonConvert.SerializeObject(user);
                    File.WriteAllText(filePath, jsonData);
                    break;
                }
                else if (command == 6)
                {
                    Program.UserMenu(name, role);
                    break;
                }
            }
        }

        private static void PrintShortages(IEnumerable<dynamic> shortages)
        {
            Console.Clear();
            foreach (var item in shortages)
            {
                Console.WriteLine();
                Console.WriteLine(" Title: " + item.Title);
                Console.WriteLine(" Name: " + item.Name);
                Console.WriteLine(" Room: " + item.Room);
                Console.WriteLine(" Category: " + item.Category);
                Console.WriteLine(" Priority: " + item.Priority);
                Console.WriteLine(" CreatedOn: " + item.CreatedOn);
            }
        }
    }
}
