using _05_GreetingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingConsole
{
    public class ProgramUI
    {
        private CustomerRepository _customerRepo = new CustomerRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            Customer customerOne = new Customer("Jane", "Albert", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.", TypeOfCustomer.Current);
            Customer customerTwo = new Customer("Janis", "Roberts", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.", TypeOfCustomer.Current);
            Customer customerThree = new Customer("Roy", "Franklin", "We currently have the lowest rates on Helicopter Insurance!", TypeOfCustomer.Potential);
            _customerRepo.CreateNewCustomer(customerOne);
            _customerRepo.CreateNewCustomer(customerThree);
            _customerRepo.CreateNewCustomer(customerTwo);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance Customer Information: \n" +
                    "1. See list of all people on earth alive\n" +
                    "2. Add new customer\n" +
                    "3. Update a customer\n" +
                    "4. Remove a Customer\n" +
                    "5. Send the mass emails!!");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ComputerWitchPleaseGetMeListOfAllCustomers();
                        break;
                    case "2":
                        AskComputerWitchToCreateNewCustomer();
                        break;
                    case "3":
                        UpdateCustomerByCommandingComputerWitch();
                        break;
                    case "4":
                        DeleteCustomerForverBySacrifaceToComputerWitch();
                        break;
                    case "5":
                        LetComputerWitchContactTheMasses();
                        break;
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to return to menu...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ComputerWitchPleaseGetMeListOfAllCustomers()
        {
            List<Customer> customerList = _customerRepo.GetListOfCustomers();
            Console.WriteLine("The Computer Witch as provided the customer list: ");
            List<Customer> sortedC = customerList.OrderBy(o => o.LastName).ToList();
            foreach (Customer customer in sortedC)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.CustomerType} - {customer.Email}");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        public void AskComputerWitchToCreateNewCustomer()
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("Create a new customer: \n" +
                "Enter customer first name: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter customer last name: ");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Choose a customer type: \n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            newCustomer.CustomerType = (TypeOfCustomer)int.Parse(Console.ReadLine());
            if(newCustomer.CustomerType == TypeOfCustomer.Current)
            {
                newCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }
            else if(newCustomer.CustomerType == TypeOfCustomer.Past)
            {
                newCustomer.Email = "It's been a long time since we've heard from you, we want you back.";
            }
            else if (newCustomer.CustomerType == TypeOfCustomer.Potential)
            {
                newCustomer.Email = "We currently have the lowest rates on Helicopter Insurance!";
            }
            _customerRepo.CreateNewCustomer(newCustomer);
            Console.WriteLine("New customer created.\n" +
                "Press any key to return to menu...");
            Console.ReadKey();
        }
        public void UpdateCustomerByCommandingComputerWitch()
        {
            Console.WriteLine("Updating customer\n" +
                "Enter full name of customer: ");
            string fullName = Console.ReadLine();
            Customer oldCustomer = _customerRepo.GetCustomerByName(fullName);
            Console.WriteLine("Customer found: ");
            Console.WriteLine($"{oldCustomer.FirstName} {oldCustomer.LastName} - {oldCustomer.CustomerType} - {oldCustomer.Email}");
            Console.WriteLine("Enter new full name: ");
            string newFullName = Console.ReadLine();
            string[] nameArray = newFullName.Split(' ');
            oldCustomer.FirstName = nameArray[0];
            oldCustomer.LastName = nameArray[1];
            Console.WriteLine("Choose new customer type: \n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            oldCustomer.CustomerType = (TypeOfCustomer)int.Parse(Console.ReadLine());
            if (oldCustomer.CustomerType == TypeOfCustomer.Current)
            {
                oldCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }
            else if (oldCustomer.CustomerType == TypeOfCustomer.Past)
            {
                oldCustomer.Email = "It's been a long time since we've heard from you, we want you back.";
            }
            else if (oldCustomer.CustomerType == TypeOfCustomer.Potential)
            {
                oldCustomer.Email = "We currently have the lowest rates on Helicopter Insurance!";
            }
            _customerRepo.UpdateCustomerInfo(fullName, oldCustomer);
            Console.WriteLine($"{oldCustomer.FirstName} {oldCustomer.LastName} - {oldCustomer.CustomerType} - {oldCustomer.Email}\n" +
                $"Customer updated. press any key to return to menu...");
            Console.ReadKey();
        }
        public void DeleteCustomerForverBySacrifaceToComputerWitch()
        {
            Console.WriteLine("Remove a customer.\n" +
                "Please enter full name of customer to remove: ");
            string userResponse = Console.ReadLine();
            _customerRepo.RemoveCustomer(userResponse);
            Console.WriteLine("Customer Removed.\n" +
                "Press any key to return to menu...");
            Console.ReadKey();
        }
        public void LetComputerWitchContactTheMasses()
        {
            Console.WriteLine("It might not be the best idea to let the Computer Witch contact the masses.\n" +
                "Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
