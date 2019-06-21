using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    
    public class Menu
    {
        public int MenuNumber { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> IngredientsItems { get; set; }

        public Menu() { }
        public Menu(int menuNumber, string itemName, decimal price, string description, List<string> ingredients )
        {
            ItemName = itemName;
            MenuNumber = menuNumber;
            Price = price;
            Description = description;
            IngredientsItems = ingredients;
        }
    }
}
