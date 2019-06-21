using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingRepository
{
    public enum TypeOfCustomer { Current = 1, Potential, Past}
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfCustomer CustomerType { get; set; }
        public string Email { get; set; }
        public Customer() { }
        public Customer(string firstName, string lastName, string email, TypeOfCustomer customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CustomerType = customerType;
        }
    }
}
