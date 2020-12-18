using Challenge2Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2Tests
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private ClaimsRepo _repo;
        private ClaimsClass _class;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _class = new ClaimsClass(1, "Car", "Fender bender", 200.00, new DateTime(2020, 01, 01), new DateTime(2020, 02, 03), false);

            _repo.AddClaims(_class);
        }
        [TestMethod]
        public void AddClaims_ShouldReturnTrue()
        {
            ClaimsClass content = new ClaimsClass();
            ClaimsRepo repo = new ClaimsRepo();
            

            _class = new ClaimsClass(8, "Car", "Fender bender", 200.00, new DateTime(2020, 01, 01), new DateTime(2020, 02, 03), false);
            _repo.AddClaims(_class);
            
            Queue<ClaimsClass> queue = _repo.ViewClaimsQueue();
            
            bool isEqual = false;
            foreach (ClaimsClass claims in queue)
            {
                if (claims.ClaimAmount == _class.ClaimAmount)
                {
                    isEqual = true;
                    break;
                }
            }
            Assert.IsTrue(isEqual);
            
        }
        [TestMethod]
        public void GetClaimFromTopOfQueue()
        {
            ClaimsClass claims = _repo.ViewSingleClaims();
            Assert.IsNotNull(claims);
        }
        [TestMethod]
        public void DeleteClaimFromQueue()
        {
            _repo.DeleteClaims();
            int expected = 0;
            int actual = _repo.ViewClaimsQueue().Count;
            Assert.AreEqual(expected, actual);
        }


    }
}
