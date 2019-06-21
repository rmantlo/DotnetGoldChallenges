using _04_OutingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsConsole
{
    public class ProgramUI
    {
        public OutingsRepository _outingsRepo = new OutingsRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            Outings outings = new Outings(DateTime.Parse("5/5/2019"), 27, 1, 30, TypeOfEvent.AmusementPark);
            Outings outingsTwo = new Outings(DateTime.Parse("3/6/2019"), 27, 17, 459, TypeOfEvent.Concert);
            Outings outingsThree = new Outings(DateTime.Parse("1/20/2019"), 27, 8, 300, TypeOfEvent.Golf);
            _outingsRepo.CreateOuting(outings);
            _outingsRepo.CreateOuting(outingsTwo);
            _outingsRepo.CreateOuting(outingsThree);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Komodo company outings directory.\n" +
                    "Please choose an option: \n" +
                    "1. Display all outings\n" +
                    "2. Add new outing\n" +
                    "3. View cost calculations");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ViewAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        Calculations();
                        break;
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, press any key to return to menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ViewAllOutings()
        {
            List<Outings> allOutings = _outingsRepo.GetOutingList();
            Console.WriteLine($"List of all company outings:\n");
            foreach (Outings outing in allOutings)
            {
                Console.WriteLine($"{outing.DateOfOuting} - {outing.EventType} - Attendence: {outing.NumberOfPeople}, Cost/Person: {outing.CostPerPerson}, CostForEvent: {outing.CostForEvent}.");

            }
            Console.WriteLine($"Press any key to return to menu...");
            Console.ReadKey();
        }
        public void AddNewOuting()
        {
            Console.WriteLine("Create new outing: \n");
            Outings newOuting = new Outings();
            Console.WriteLine("Enter date of Outings: mm/dd/yyyy");
            newOuting.DateOfOuting = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Choose type of outing: \n" +
                "1. Amusement Park\n" +
                "2. Bowling\n" +
                "3. Concert\n" +
                "4. Golf");
            int response = int.Parse(Console.ReadLine());
            newOuting.EventType = (TypeOfEvent)response;

            Console.WriteLine("Enter total cost of event: ");
            newOuting.CostForEvent = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of people attending: ");
            newOuting.NumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cost per person attending: ");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());
            _outingsRepo.CreateOuting(newOuting);
            Console.WriteLine("New Outing created and added to list.\n" +
                "Press any key to return to menu...");

            Console.ReadKey();
        }

        public void Calculations()
        {
            List<Outings> outingsList = _outingsRepo.GetOutingList();
            decimal totalCostAllOutings = 0m;
            decimal totalGolfOutingCost = 0m;
            decimal totalAmusementOutingCost = 0m;
            decimal totalBowlingOutingCost = 0m;
            decimal totalConcertOutingCost = 0m;

            foreach(Outings outing in outingsList)
            {
                totalCostAllOutings = totalCostAllOutings + outing.CostForEvent;
                if(outing.EventType == TypeOfEvent.AmusementPark)
                {
                    totalAmusementOutingCost = totalAmusementOutingCost + outing.CostForEvent;
                }
                else if (outing.EventType == TypeOfEvent.Bowling)
                {
                    totalBowlingOutingCost = totalBowlingOutingCost + outing.CostForEvent;
                }
                else if (outing.EventType == TypeOfEvent.Concert)
                {
                    totalConcertOutingCost = totalConcertOutingCost + outing.CostForEvent;
                }
                else if (outing.EventType == TypeOfEvent.Golf)
                {
                    totalGolfOutingCost = totalGolfOutingCost + outing.CostForEvent;
                }
            }
            

            Console.WriteLine("Calculations menu\n" +
                $"Cost of all Events combined: ${totalCostAllOutings}" +
                $"\nTotal Amusement Park events cost: ${totalAmusementOutingCost}\n" +
                $"Total Bowling events cost: ${totalBowlingOutingCost}\n" +
                $"Total Concert events cost: ${totalConcertOutingCost}\n" +
                $"Total Golf events cost: ${totalGolfOutingCost}\n" +
                $"\nPress any key to return to menu...");

            Console.ReadKey();
        }
    }
}
