using Challenge1Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Console
{
    public class ProgramUI
    {
        public Menu_Repo _Cafe_Repo = new Menu_Repo();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                   "1. Add menu items \n" +
                   "2. View all menu items \n" +
                   "3. Update existing menu items\n" +
                   "4. Remove a menu items \n" +
                   "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddMenuItems();
                        break;
                    case "2":
                        ViewMenuItems();
                        break;
                    case "3":
                        UpdateMenuItems();
                        break;
                    case "4":
                        RemoveMenuItems();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from the list");
                        break;

                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        // Add Menu Item
        private void AddMenuItems()
        {
            Console.Clear();
            Menu_Content newItem = new Menu_Content();
            Console.WriteLine("Please enter a menu number");
            newItem.MealNumber = int.Parse(Console.ReadLine());


            Console.WriteLine("Please enter the menu name");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Please enter a list of ingredients");
            newItem.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of the menu item");
            string priceAsDecimal = Console.ReadLine();
            newItem.MealPrice = decimal.Parse(priceAsDecimal);

            _Cafe_Repo.AddMenuItems(newItem);
        }
        private void ViewMenuItems()
        {
            Console.Clear();
            List<Menu_Content> listOfMenuItems = _Cafe_Repo.ViewMenuItems();

            Console.WriteLine("Here is the list of menu items\n");
            foreach (Menu_Content menuItems in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {menuItems.MealNumber}, Meal Name: {menuItems.MealName}, Meal Description: {menuItems.MealDescription}, List of Ingredients:{menuItems.ListOfIngredients}, Meal Price:{menuItems.MealPrice}\n");
            }
        }

        private void UpdateMenuItems()
        {
            Console.Clear();
            ViewMenuItems();

            Console.WriteLine("Enter the menu name you want to update");

            string oldMenuItems = Console.ReadLine();

            Menu_Content newMenuItems = new Menu_Content();

            Console.WriteLine("Enter the meal number");
            string mealNumAsString = Console.ReadLine();
            newMenuItems.MealNumber = int.Parse(mealNumAsString);


            Console.WriteLine("Enter the meal name");
            newMenuItems.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description");
            newMenuItems.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the list of ingredients");
            newMenuItems.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("Enter the price");
            string priceAsString = Console.ReadLine();
            newMenuItems.MealPrice = decimal.Parse(priceAsString);

            bool wasUpdated = _Cafe_Repo.UpdateMenuItems(oldMenuItems, newMenuItems);

            if (wasUpdated)
            {
                Console.WriteLine("Content was successfully updated.");

            }
            else
            {
                Console.WriteLine("Could not updated content.");
            }
        }
        private void RemoveMenuItems()
        {
            Console.Clear();
            ViewMenuItems();

            Console.WriteLine("Which menu item would you like to remove?");

            string input = Console.ReadLine();

            bool wasDeleted = _Cafe_Repo.RemoveMenuItems(input);

            if (wasDeleted)
            {
                Console.WriteLine("Content was deleted");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }
        }

        private void SeedContentList()
        {
            Menu_Content mealNumOne = new Menu_Content(1, "Da Burg", "Cheeseburger, Fry, Drink", "hamburger, cheese, potato", 6.50m);
            Menu_Content mealNumTwo = new Menu_Content(2, "Crispy Chicky", "Crispy chicken sandwhich, oinion rings, soft drink", "chicken, breading, onions", 7.00m);
            Menu_Content mealNumThree = new Menu_Content(3, "Tender Komodo", "Breaded Komodo tenderloin, curly fries, soft drink", "komodo tenderloin, potato", 9.00m);
            Menu_Content mealNumFour = new Menu_Content(4, "Komodo Sketti", "Spaghetti and Komodo dragon meatballs", "noodles, sauce, komodo meat", 12.00m);
            Menu_Content mealNumFive = new Menu_Content(5, "Dragon Mac", "Mac N cheese", "noodles, cheese, hot sauce", 10.00m);

            _Cafe_Repo.AddMenuItems(mealNumOne);
            _Cafe_Repo.AddMenuItems(mealNumTwo);
            _Cafe_Repo.AddMenuItems(mealNumThree);
            _Cafe_Repo.AddMenuItems(mealNumFour);
            _Cafe_Repo.AddMenuItems(mealNumFive);
        }
    }
}
