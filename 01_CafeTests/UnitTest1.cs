using System;
using System.Collections.Generic;
using _01_CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _menuRepo;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            List<string> ingredList = new List<string>();
            ingredList.Add("Lettuce");
            ingredList.Add("Tomatoes");
            ingredList.Add("Ranch");
            _menu = new Menu(1, "Salad", 4.20m, "It's a salad", ingredList);
        }
        [TestMethod]
        public void AddTest()
        {
            int expected = 1;
            _menuRepo.AddMenuItem(_menu);
            Assert.AreEqual(expected, _menuRepo.GetMenuList().Count);
        }
        [TestMethod]
        public void UpdateTest()
        {
            _menuRepo.AddMenuItem(_menu);
            Menu item = _menuRepo.GetMenuItem(1);
            item.MenuNumber = 700;
            _menuRepo.UpdateMenuItem(1, item);
            Assert.AreNotEqual(1, item.MenuNumber);
        }
        [TestMethod]
        public void RemoveTest()
        {
            _menuRepo.AddMenuItem(_menu);
            bool result = _menuRepo.RemoveMenuItem(_menu);
            Assert.IsTrue(result);
        }
    }
}
