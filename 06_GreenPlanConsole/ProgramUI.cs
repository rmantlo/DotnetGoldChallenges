using _06_GreenPlanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanConsole
{
    public class ProgramUI
    {
        private CarRepository _carRepo = new CarRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            _carRepo.CreateNewCar(3000.25m, "Joe", TypeOfCar.Electric);
            _carRepo.CreateNewCar(65.95m, "Tammy", TypeOfCar.Electric);
            _carRepo.CreateNewCar(345.98m, "Gary", TypeOfCar.Gas);
            _carRepo.CreateNewCar(7.8m, "Jane", TypeOfCar.Hybrid);
            _carRepo.CreateNewCar(30.25m, "Bill", TypeOfCar.Hybrid);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance Car Organized List menu.\n" +
                    "Please select an option.\n" +
                    "1. Get all Electric cars\n" +
                    "2. Get all Hybrid cars\n" +
                    "3. Get all Gas cars\n" +
                    "4. Add a car\n" +
                    "5. Update a car\n" +
                    "6. Remove a car");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetAllElectric();
                        break;
                    case "2":
                        GetAllHybrid();
                        break;
                    case "3":
                        GetAllGas();
                        break;
                    case "4":
                        CreateNewCar();
                        break;
                    case "5":
                        UpdateACar();
                        break;
                    case "6":
                        RemoveACar();
                        break;
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to return to menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void GetAllElectric()
        {
            List<ElectricCar> list = _carRepo.GetElectricCarList();
            Console.WriteLine("List of Electric cars: ");

            foreach(ElectricCar car in list)
            {
                Console.WriteLine($"{car.FirstName} - {car.CarPrice}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void GetAllHybrid()
        {
            List<HybridCar> list = _carRepo.GetHybridCarList();
            Console.WriteLine("List of Hybrid cars: ");

            foreach (HybridCar car in list)
            {
                Console.WriteLine($"{car.FirstName} - {car.CarPrice}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void GetAllGas()
        {
            List<GasCar> list = _carRepo.GetGasCarList();
            Console.WriteLine("List of Gas cars: ");

            foreach (GasCar car in list)
            {
                Console.WriteLine($"{car.FirstName} - {car.CarPrice}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void CreateNewCar()
        {
            Console.WriteLine("Create and Add a new care into the database: \n" +
                "Please enter first name of customer: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter price of car: ");
            decimal carPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please choose type of car: \n" +
                "1. Electric\n" +
                "2. Hybrid \n" +
                "3. Gas");
            int response = int.Parse(Console.ReadLine());
            TypeOfCar carType = (TypeOfCar)response;
            int firstCount = _carRepo.GetElectricCarList().Count;

            _carRepo.CreateNewCar(carPrice, firstName, carType);

            int count = _carRepo.GetElectricCarList().Count;
            Console.WriteLine($"{firstCount} -- {count}");
            Console.WriteLine("Car added. Press any key to return to menu...");
            Console.ReadKey();

        }
        public void UpdateACar()
        {
            Console.WriteLine("Update a car \n" +
                "Enter first name of car owner: ");
            string firstName = Console.ReadLine();
            ICar car = _carRepo.GetACar(firstName);
            Console.WriteLine($"{car.FirstName} - {car.CarPrice} - {car.CarType}");
            Console.WriteLine("Please enter new car owner name: ");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Enter new car price: ");
            decimal carPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Choose new Car Type: \n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");
            TypeOfCar carType = (TypeOfCar)int.Parse(Console.ReadLine());

            if (carType == TypeOfCar.Electric)
            {
                ElectricCar newCar = new ElectricCar(TypeOfCar.Electric, carPrice, firstName);
                _carRepo.UpdateElectricCar(firstName, newCar);
            }
            else if (carType == TypeOfCar.Hybrid)
            {
                HybridCar newCar = new HybridCar(TypeOfCar.Hybrid, carPrice, firstName);
                _carRepo.UpdateHybridCar(firstName, newCar);
            }
            else if (carType == TypeOfCar.Gas)
            {
                GasCar newCar = new GasCar(TypeOfCar.Gas, carPrice, firstName);
                _carRepo.UpdateGasCar(firstName, newCar);
            }

            Console.WriteLine($"{car.FirstName} - {car.CarPrice} - {car.CarType}");
            Console.ReadKey();
        }
        public void RemoveACar()
        {
            Console.WriteLine("Enter first name of car owner to remove car: ");
            string firstName = Console.ReadLine();
            _carRepo.RemoveACar(firstName);
        }
    }
}
