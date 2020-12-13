using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Repo
{
    public class Menu_Repo
    {

        public List<Menu_Content> _listOfMenuItems = new List<Menu_Content>();


        public void AddMenuItems(Menu_Content menuItems)
        {
            _listOfMenuItems.Add(menuItems);
        }

        public List<Menu_Content> ViewMenuItems()
        {
            return _listOfMenuItems;
        }

        public bool UpdateMenuItems(string mealName, Menu_Content newMenuItems)
        {
            Menu_Content oldMenuItems = GetMenuItems(mealName);

            if (oldMenuItems != null)
            {
                oldMenuItems.MealNumber = newMenuItems.MealNumber;
                oldMenuItems.MealName = newMenuItems.MealName;
                oldMenuItems.MealDescription = newMenuItems.MealDescription;
                oldMenuItems.ListOfIngredients = newMenuItems.ListOfIngredients;
                oldMenuItems.MealPrice = newMenuItems.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveMenuItems(string mealName)
        {
            Menu_Content menuItems = GetMenuItems(mealName);

            if (menuItems == null)
            {
                return false;
            }

            int intitialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItems);

            if (intitialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Menu_Content GetMenuItems(string mealName)
        {
            foreach (Menu_Content menuItems in _listOfMenuItems)
            {
                if (menuItems.MealName.ToLower() == mealName.ToLower())
                {
                    return menuItems;
                }
            }
            return null;
        }
    }
}
