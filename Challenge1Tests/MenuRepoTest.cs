using Challenge1Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1Tests
{
    [TestClass]
    public class MenuRepoTest
    {
        private Menu_Repo _repo;
        private Menu_Content _content;



        [TestInitialize]

        public void Arrange()
        {
            _repo = new Menu_Repo();
            _content = new Menu_Content(1, "Da Burg", "Cheeseburger, Fry, Drink", "hamburger, cheese, potato", 6.50m);

            _repo.AddMenuItems(_content);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Menu_Content menuItems = new Menu_Content();
            menuItems.MealName = "Komodo Pizza";
            Menu_Repo repo = new Menu_Repo();

            repo.AddMenuItems(menuItems);
            Menu_Content mealItemsFromMenu = repo.GetMenuItems("Komodo Pizza");

            Assert.IsNotNull(mealItemsFromMenu);
        }
        [TestMethod]
        public void UpdateMenuItems_ShouldReturnTrue()
        {
            Menu_Content newMenutItems = new Menu_Content(1, "Da Burg", "Cheeseburger, Fry, Drink", "hamburger, cheese, potato", 6.50m);

            bool updateResult = _repo.UpdateMenuItems("Da Burg", newMenutItems);

            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow("Da Burg", true)]
        [DataRow("Komodo Pizza", false)]

        public void UpdateMenuItems_ShouldMatchGivenBool(string mealName, bool shouldUpdate)
        {
            Menu_Content newMenuItems = new Menu_Content(1, "Da Burg", "Cheeseburger, Fry, Drink", "hamburger, cheese, potato", 6.50m);

            bool updateResult = _repo.UpdateMenuItems(mealName, newMenuItems);

            Assert.AreEqual(shouldUpdate, updateResult);

        }
        [TestMethod]
        public void RemoveMenuItems_ShouldReturnTrue()

        {
            bool removeResult = _repo.RemoveMenuItems(_content.MealName);

            Assert.IsTrue(removeResult);
        }



    }
}
