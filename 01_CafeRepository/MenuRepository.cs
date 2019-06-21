using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();

        public List<Menu> GetMenuList()
        {
            return _menu;
        }
        //get item by number
        public Menu GetMenuItem(int menuNumber)
        {
            foreach (Menu item in _menu)
            {
                if (item.MenuNumber == menuNumber)
                {
                    return item;
                }
            }
            return null;
        }
        //create item
        public void AddMenuItem(Menu menu)
        {
            _menu.Add(menu);
        }
        //update item
        public void UpdateMenuItem(int menuItemNum, Menu updatedItem)
        {
            Menu item = GetMenuItem(menuItemNum);
            item = updatedItem;
        }
        //delete item
        public bool RemoveMenuItem(Menu item)
        {
            int initialCount = _menu.Count;
            _menu.Remove(item);
            if (initialCount > _menu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
