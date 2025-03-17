using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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

        public Customer? GetCustomerByName(string name)
        {
            return _customers.FirstOrDefault(c => c.Name == name);
        }

        public void SaveData()
        {
            try {
                var json = JsonSerializer.Serialize(_customers);
                File.WriteAllText("data.json", json);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }
    }
}