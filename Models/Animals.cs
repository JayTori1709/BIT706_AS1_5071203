namespace WeChipItAvalonia.Models
{
    public class Animal
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Sex { get; set; }
        public int Age { get; set; }
        public string MicrochipNumber { get; set; } = string.Empty; // Added for microchip functionality

        public override string ToString()
        {
            return $"{Name}, {Type}, {Sex}, {Age}, Microchip: {MicrochipNumber}";
        }
    }
}