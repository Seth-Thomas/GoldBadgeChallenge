using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Repo
{
    public class Menu_Content
    {
        public int MealNumber
        {
            get; set;
        }
        public string MealName
        {
            get; set;
        }

        public string MealDescription
        {
            get; set;
        }
        public string ListOfIngredients
        {
            get; set;
        }
        public decimal MealPrice
        {
            get; set;
        }
        public Menu_Content()
        {
        }
        public Menu_Content(int mealNumber, string mealName, string mealDescription, string listOfIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }

    }
}
