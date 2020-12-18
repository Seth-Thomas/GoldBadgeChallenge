using Challenge3Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Console
{
    class ProgramUI
    {
        private BadgeRepo _badges = new BadgeRepo();
        public void Run()
        {
            SeedBadgesList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Which function would you like to perform?\n" +
                    "1. Add badge \n" +
                    "2. Add Door Access \n" +
                    "3. Delete Door Access \n" +
                    "4. List all badges\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        AddDoorACcess();
                        break;
                    case "3":
                        DeleteDoorAccess();
                        break;
                    case "4":
                        ListAllBadges();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void AddBadge()
        {
            BadgeClass badge = new BadgeClass();
            Console.Clear();
            Console.WriteLine("Enter the badge number you would like to add");

            badge.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Which doors does the badge have access to?");
            badge.Doors.Add(Console.ReadLine());

            _badges.AddNewBadge(badge);

        }
        private void AddDoorACcess()
        {
            Console.WriteLine("Enter badge ID you want to add door access to");

            int badgeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Which door would you like to add to this badge ID?");
            string access = Console.ReadLine();

            _badges.AddDoorToExistingBadge(badgeId, access);

        }
        private void DeleteDoorAccess()
        {
            Console.WriteLine("Enter badge ID you want to delete door access from");

            int badgeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Which door would you like to delete from this badge ID?");
            string access = Console.ReadLine();

            _badges.DeleteDoorsOnExistingBadge(badgeId, access);
        }
        private void ListAllBadges()
        
        {
            Dictionary<int, List<string>> badges = _badges.GetBadgeList();
            Console.WriteLine($"{"Badge #",-15}{"Door Access"}");

            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorAccess = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key,-15}{doorAccess}");
            }

        }
        private void SeedBadgesList()
        {
            List<string> doors = new List<string>();

            BadgeClass badge1 = new BadgeClass(123, new List<string>() { "A1,B2,C3" });
            BadgeClass badge2 = new BadgeClass(456, new List<string>() { "A1,B2" });
            BadgeClass badge3 = new BadgeClass(789, new List<string>() { "C3" });

            _badges.AddNewBadge(badge1);
            _badges.AddNewBadge(badge2);
            _badges.AddNewBadge(badge3);

        }
    }
}
