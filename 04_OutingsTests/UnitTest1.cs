using System;
using _04_OutingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_OutingsTests
{
    [TestClass]
    public class UnitTest1
    {
        private OutingsRepository _outingsRepo;
        private Outings _outings;
        [TestMethod]
        public void TestMethod1()
        {
            _outingsRepo = new OutingsRepository();
            _outings = new Outings(DateTime.Parse("5/5/2019"), 27, 17, 459, TypeOfEvent.AmusementPark);

            _outingsRepo.CreateOuting();
        }
    }
}
