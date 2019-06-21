using System;
using _06_GreenPlanRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_GreenPlanTests
{
    [TestClass]
    public class UnitTest1
    {
        private CarRepository _carRepo = new CarRepository();

        [TestInitialize]
        public void Arrange()
        {
            _carRepo.CreateNewCar(3000.25m, "Joe", TypeOfCar.Electric);
            _carRepo.CreateNewCar(65.95m, "Tammy", TypeOfCar.Electric);
            _carRepo.CreateNewCar(345.98m, "Gary", TypeOfCar.Gas);
            _carRepo.CreateNewCar(7.8m, "Jane", TypeOfCar.Hybrid);
            _carRepo.CreateNewCar(30.25m, "Bill", TypeOfCar.Hybrid);
        }
        [TestMethod]
        public void CreateAddCar()
        {
            int initialCount = _carRepo.GetElectricCarList().Count;
            _carRepo.CreateNewCar(3, "becky", TypeOfCar.Electric);

            Assert.AreNotEqual(initialCount, _carRepo.GetElectricCarList().Count);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            _carRepo.RemoveACar("Joe");
        }
    }
}
