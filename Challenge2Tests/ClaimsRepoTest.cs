using Challenge2Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2Tests
{
    [TestClass]
    public class ClaimsRepoTest
    {
        //    private ClaimsRepo _repo;
        //    private ClaimsClass _class;

        //    [TestInitialize]
        //    public void Arrange()
        //    {
        //        _repo = new ClaimsRepo();
        //        _class = new ClaimsClass(1, "Car", "Fender bender", 200.00, new DateTime(2020, 01, 01), new DateTime(2020, 02, 03), false);

        //        _repo.AddClaims(_class);
        //    }
        //    public void AddClaims_ShouldGetNull()
        //    {
        //        ClaimsClass claims = new ClaimsClass();
        //        claims.ClaimType = "boat";
        //        ClaimsRepo repo = new ClaimsRepo();

        //        repo.AddClaims(claims);
        //        ClaimsClass claimFromQueue = repo.ViewClaimsQueue("boat");

        //        Assert.IsNotNull(claimFromQueue);
        //    }
        //}
        [TestMethod]
        public void AddClaims_ShouldNotGetNull()
        {
            ClaimsRepo repo = new ClaimsRepo();
            ClaimsClass claims = new ClaimsClass();
            {
                

            }

        
    }
    

    
}
