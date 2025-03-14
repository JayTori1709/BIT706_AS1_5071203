using System.Collections.Generic;

namespace WeChipItAvalonia.Models
{
    public class Customer
    {
        public required string Name { get; set; }
        public required string Contact { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();

        public override string ToString()
        {
            return $"{Name}, {Contact}, {Email}";
        }
    }
}