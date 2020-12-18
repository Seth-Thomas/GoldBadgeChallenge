using Challenge3Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3Tests
{
    [TestClass]
    public class BadgeRepoTest
    {
        private BadgeRepo _repo;
        private BadgeClass _class;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _class = new BadgeClass(123, new List<string>() { "A1","B2","C3" });

            _repo.AddNewBadge(_class);
        }
        [TestMethod]
        public void AddNewBadge_ShouldReturnTrue()
        {
            BadgeClass badge = new BadgeClass();
            BadgeRepo repo = new BadgeRepo();


            _class = new BadgeClass(1299, new List<string>() { "A1","B2","C3" });
            _repo.AddNewBadge(_class);

            //List<string> badgeAdd = GetBadgeById(badgeId);
            Dictionary<int, List<string>> badges = _repo.GetBadgeList();


            bool isEqual = false;
            foreach (KeyValuePair<int, List<string>> badgeNum in badges)
            {
                if (badgeNum.Key == _class.BadgeId)
                {
                    isEqual = true;
                    break;
                }
            }
            Assert.IsTrue(isEqual);

        }
        [TestMethod]
        public void DeleteDoorsOnExistingBadge_ShouldBeEqual()
        {

            _class = new BadgeClass(123, new List<string>() { "A1","B2","C3" });
            int lastCount = _class.Doors.Count;
            bool wasDeleted = _repo.DeleteDoorsOnExistingBadge(123, "A1");
            int newCount = _class.Doors.Count;
            Assert.IsTrue(wasDeleted);




        }
        [TestMethod]
        public void AddDoorOnExistingBadge()
        {
             _class = new BadgeClass(123, new List<string>() { "A1","B2","C3" });
            bool wasAdded = _repo.AddDoorToExistingBadge(123, "A55");
            Assert.IsTrue(wasAdded); 

        }

    }
}
