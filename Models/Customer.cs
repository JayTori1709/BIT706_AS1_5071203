namespace WeChipItAvalonia.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public Customer(string name, string contactNumber, string email)
        {
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name}, {ContactNumber}, {Email}";
        }
    }
}
