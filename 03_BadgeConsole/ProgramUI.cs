using _03_BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeConsole
{
    public class ProgramUI
    {
        public BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedProgram();
            RunMenu();
        }

        private void SeedProgram()
        {
            List<string> listOne = new List<string>();
            List<string> listTwo = new List<string>();
            List<string> listThree = new List<string>();
            DoorKey doorListOne = new DoorKey("A1");
            DoorKey doorListTwo = new DoorKey("B1");
            DoorKey doorListThree = new DoorKey("C1");
            listOne.Add("A1");
            listOne.Add("C1");
            listTwo.Add("C1");
            listThree.Add("A1");
            listThree.Add("B1");
            _badgeRepo.AddToBadgeRepository(1, listOne);
            _badgeRepo.AddToBadgeRepository(2, listTwo);
            _badgeRepo.AddToBadgeRepository(3, listThree);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello security admin, what would you like to do?\n" +
                    "1. Add a Badge.\n" +
                    "2. Update a Badge.\n" +
                    "3. List all Badges.");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateABadge();
                        break;
                    case "3":
                        GetAllBadges();
                        break;
                    case "Exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void GetAllBadges()
        {
            Console.WriteLine("See All Registered Badges");
            Dictionary<int, List<string>> theLIST = _badgeRepo.GetListOfBadges();
            foreach (KeyValuePair<int, List<string>> thePair in theLIST)
            {
                string[] strValues = thePair.Value.ToArray();
                Console.WriteLine($"Badge: {thePair.Key}, Doors: {string.Join(", ", strValues)}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void AddNewBadge()
        {
            Console.WriteLine("Enter number on badge: ");
            int inputBadgeID = int.Parse(Console.ReadLine());
            List<string> listOfKeys = new List<string>();
            Console.WriteLine("List a door to allow access: ");
            listOfKeys.Add(Console.ReadLine());
            Console.WriteLine("Any other doors (y/n)?");
            string response = Console.ReadLine();
            if (response.ToLower() == "y" || response.ToLower() == "yes")
            {
                Console.WriteLine("Enter another door: ");
                listOfKeys.Add(Console.ReadLine());
                Console.WriteLine("Any other doors (y/n)?");
                string responseTwo = Console.ReadLine();
                if(responseTwo.ToLower() == "y" || responseTwo.ToLower() == "yes")
                {
                    Console.WriteLine("Enter another door: ");
                    listOfKeys.Add(Console.ReadLine());
                    Console.WriteLine("Any other doors (y/n)?");
                    string responseThree = Console.ReadLine();
                    if (responseThree.ToLower() == "y" || responseThree.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter another door: ");
                        listOfKeys.Add(Console.ReadLine());
                        Console.WriteLine("Badge created.\nPress any key to return to menu...");
                        Console.ReadKey();
                    }
                    else
                    {
                        _badgeRepo.AddToBadgeRepository(inputBadgeID, listOfKeys);
                        Console.WriteLine("Badge created.\nPress any key to return to menu...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    _badgeRepo.AddToBadgeRepository(inputBadgeID, listOfKeys);
                    Console.WriteLine("Badge created.\nPress any key to return to menu...");
                    Console.ReadKey();
                }
            }
            else
            {
                _badgeRepo.AddToBadgeRepository(inputBadgeID, listOfKeys);
                Console.WriteLine("Badge created.\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
        public void UpdateABadge()
        {
            Console.WriteLine("What is the number of the badge to update?");
            int badgeID = int.Parse(Console.ReadLine());
            List<string> theList = _badgeRepo.GetBadgeDoorList(badgeID);
            string[] strArray = theList.ToArray();
            Console.WriteLine($"Badge {badgeID} has access to {string.Join(", ", strArray)}.\n" +
                $"What would you like to do?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string userInput = Console.ReadLine();
                    theList.Remove(userInput);
                    Console.WriteLine("Door removed. Press any key to return to menu...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Enter door to add: ");
                    string userInputTwo = Console.ReadLine();
                    theList.Add(userInputTwo);
                    Console.WriteLine("Door added. Press any key to return to menu...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to return to menu...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }
    }
}
