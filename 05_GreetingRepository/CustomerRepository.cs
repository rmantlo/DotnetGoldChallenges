using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingRepository
{
    public class CustomerRepository
    {
        List<Customer> _customerRepo = new List<Customer>();

        public List<Customer> GetListOfCustomers()
        {
            return _customerRepo;
        }
        public Customer GetCustomerByName(string fullName)
        {
            string[] nameArray = fullName.Split(' ');
            foreach(Customer customer in _customerRepo)
            {
                if (customer.FirstName.ToLower() == nameArray[0].ToLower() && customer.LastName.ToLower() == nameArray[1].ToLower() )
                {
                    return customer;
                }
            }
            return null;
        }
        public void CreateNewCustomer(Customer customer)
        {
            _customerRepo.Add(customer);
        }
        public void UpdateCustomerInfo(string fullName, Customer updatedCustomer)
        {
            Customer oldCustomer = GetCustomerByName(fullName);
            oldCustomer = updatedCustomer;
        }
        public void RemoveCustomer(string fullName)
        {
            Customer customer = GetCustomerByName(fullName);
            _customerRepo.Remove(customer);
        }
    }
}
