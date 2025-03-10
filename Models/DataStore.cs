using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace WeChipItAvalonia.Models
{
    public class DataStore
    {
        private List<Customer> customers = new List<Customer>();
        private List<Animal> animals = new List<Animal>();
        private List<Microchip> microchips = new List<Microchip>();

        public void AddCustomer(Customer customer) => customers.Add(customer);
        public void AddAnimal(Animal animal) => animals.Add(animal);
        public void AddMicrochip(Microchip microchip) => microchips.Add(microchip);

        public List<Customer> GetCustomers() => customers;
        public List<Animal> GetAnimals() => animals;
        public List<Microchip> GetMicrochips() => microchips;

        public void SaveData()
        {
            File.WriteAllText("data.json", JsonSerializer.Serialize(this));
        }

        public static DataStore LoadData()
        {
            if (!File.Exists("data.json")) return new DataStore();
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<DataStore>(File.ReadAllText("data.json"));
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
