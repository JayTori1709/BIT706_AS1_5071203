using System.Collections.Generic;
using System.Linq;
using WeChipItAvalonia.Models;

namespace WeChipItAvalonia.Services
{
    public class DataStore
    {
        private static DataStore? _instance;
        public static DataStore Instance => _instance ??= new DataStore();

        private List<Customer> _customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer? GetCustomerByPhone(string phone)
        {
            return _customers.FirstOrDefault(c => c.Contact == phone);
        }
    }
}