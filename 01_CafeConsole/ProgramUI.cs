using _01_CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsole
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            List<string> listOne = new List<string>();
            listOne.Add("lettuce");
            listOne.Add("Ranch");
            listOne.Add("Croutons");
            List<string> listTwo = new List<string>();
            listTwo.Add("Water");
            listTwo.Add("Tomato");
            listTwo.Add("Spices");
            List<string> listThree = new List<string>();
            listThree.Add("Bread");
            listThree.Add("Cheese");
            listThree.Add("Butter");
            Menu itemOne = new Menu(1, "salad", 4, "It's a salad", listOne);
            Menu itemTwo = new Menu(2, "Tomato Soup", 8, "Soup of tomatos", listTwo);
            Menu itemThree = new Menu(3, "Grilled Cheese", 7, "Hot sandwich with cheese in it", listThree);
            _menuRepo.AddMenuItem(itemOne);
            _menuRepo.AddMenuItem(itemTwo);
            _menuRepo.AddMenuItem(itemThree);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe.\n" +
                    "Please enter a number to select an option below:\n" +
                    "1. Get full menu list\n" +
                    "2. Get menu item by item number\n" +
                    "3. Add item to menu\n" +
                    "4. Update item from menu\n" +
                    "5. Remove item from menu\n" +
                    "6. Exit Program.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetFullMenu();
                        break;
                    case "2":
                        GetMenuItem();
                        break;
                    case "3":
                        AddItemToMenu();
                        break;
                    case "4":
                        UpdateItemOnMenu();
                        break;
                    case "5":
                        RemoveItemFromMenu();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n" +
                            "Press any key to return to menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GetFullMenu()
        {
            List<Menu> menuList = _menuRepo.GetMenuList();
            Console.WriteLine("Full KomodoCafe Menu: ");
            foreach (Menu item in menuList)
            {
                Console.WriteLine($"{item.MenuNumber}: {item.ItemName} - {item.Price}\n");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
        private void GetMenuItem()
        {
            Console.WriteLine("Please enter the menu number for the item: ");
            int userInput = int.Parse(Console.ReadLine());
            Menu item = _menuRepo.GetMenuItem(userInput);
            if (item == null)
            {
                Console.WriteLine($"No item found. Press any key to return to menu...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Item found: \n" +
                    $"{item.MenuNumber}: {item.ItemName} - ${item.Price}\n" +
                    $"{item.Description}\n" +
                    $"Ingredients: \n");
                foreach (string ingredient in item.IngredientsItems)
                {
                    Console.WriteLine($"{ingredient}");
                }
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
        private void AddItemToMenu()
        {
            Menu newItem = new Menu();
            Console.WriteLine("Enter a menu number for new item: ");
            int menuNum = int.Parse(Console.ReadLine());
            List<Menu> menu = _menuRepo.GetMenuList();
            foreach (Menu item in menu)
            {
                if (item.MenuNumber == menuNum)
                {
                    Console.WriteLine("Menu number already in use, please choose an unused number");
                    Console.ReadKey();
                }
            }
            newItem.MenuNumber = menuNum;
            Console.WriteLine("Enter name of item: ");
            newItem.ItemName = Console.ReadLine();
            Console.WriteLine("Enter description of item: ");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("Enter price of item: ");
            newItem.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a list of ingredients, each item separated by a comma: ");
            string userIngredients = Console.ReadLine();
            string[] ingredArray = userIngredients.Replace(" ", string.Empty).Split(',');
            List<string> listOfIngredients = new List<string>();
            foreach (string ingred in ingredArray)
            {

                listOfIngredients.Add(ingred);
            }
            newItem.IngredientsItems = listOfIngredients;
            _menuRepo.AddMenuItem(newItem);

            Console.WriteLine($"Item added to menu: \n" +
                $"{newItem.MenuNumber}: {newItem.ItemName} - ${newItem.Price}\n" +
                $"{newItem.Description}\n" +
                $"Ingredients: ");
            foreach (string something in listOfIngredients)
            {
                Console.WriteLine($"{something}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();


        }
        private void UpdateItemOnMenu()
        {
            Console.WriteLine("Enter menu number of item to update: ");
            int userInput = int.Parse(Console.ReadLine());
            Menu item = _menuRepo.GetMenuItem(userInput);

            Console.WriteLine($"Item found: \n" +
                    $"{item.MenuNumber}: {item.ItemName} - ${item.Price}\n" +
                    $"{item.Description}\n" +
                    $"Ingredients: \n");
            foreach (string ingredient in item.IngredientsItems)
            {
                Console.WriteLine($"{ingredient}");
            }
            Console.WriteLine("Please enter new menu number: ");
            int menuItemNum = int.Parse(Console.ReadLine());
            List<Menu> menu = _menuRepo.GetMenuList();
            foreach (Menu thing in menu)
            {
                if (thing.MenuNumber == menuItemNum && menuItemNum!=item.MenuNumber)
                {
                    Console.WriteLine("Menu number already in use, please choose an unused number");
                    Console.ReadKey();
                }
            }
            item.MenuNumber = menuItemNum;

            Console.WriteLine("Enter new item name: ");
            item.ItemName = Console.ReadLine();
            Console.WriteLine("Enter new item description: ");
            item.Description = Console.ReadLine();
            Console.WriteLine("Enter new item price: ");
            item.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Update ingredient list? yes/no");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                foreach (string str in item.IngredientsItems)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("Please enter a list of ingredients separated by commas: ");
                string[] ingred = Console.ReadLine().Replace(" ", string.Empty).Split(',');
                List<string> newIngredients = new List<string>();
                foreach (string strs in ingred)
                {
                    newIngredients.Add(strs);
                }
                item.IngredientsItems = newIngredients;
                _menuRepo.UpdateMenuItem(menuItemNum, item);
                Console.WriteLine("Ingredients updated\n" +
                    "Menu item updated\n" +
                    "Press any key to return to menu...");
                Console.ReadKey();

            }
            else if (userResponse.ToLower() == "no")
            {
                _menuRepo.UpdateMenuItem(menuItemNum, item);
                Console.WriteLine("Ingredients not updated\n" +
                    "Menu item updated.\n" +
                    "Press any key to return to menu...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter a valid response.");
                Console.ReadKey();

            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
        private void RemoveItemFromMenu()
        {
            Console.WriteLine("Enter menu number of item to remove from menu: ");
            int userInput = int.Parse(Console.ReadLine());
            Menu menuItem = _menuRepo.GetMenuItem(userInput);
            if (menuItem == null)
            {
                Console.WriteLine("Item not found, press any button to return to menu...");
                Console.ReadKey();
            }
            else
            {
                bool isRemoved = _menuRepo.RemoveMenuItem(menuItem);
                if (isRemoved)
                {
                    Console.WriteLine("Item removed from menu. Press any key to return to menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Item unsuccessfully removed. press any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
