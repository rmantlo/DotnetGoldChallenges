using System;
using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _claimsRepo;
        private Claims _claim;
        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepository();
            _claim = new Claims(1, "Hit by car", TypeOfClaim.Car, 500.25m, DateTime.Today, DateTime.Today, true);
        }
        [TestMethod]
        public void AddClaimToQueue()
        {
            int initialCount = _claimsRepo.GetListOfClaims().Count;
            _claimsRepo.AddNewClaim(_claim);
            Assert.AreNotEqual(initialCount, _claimsRepo.GetListOfClaims().Count);
        }
        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
