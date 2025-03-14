namespace WeChipItAvalonia.Models
{
    public class Animal
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Sex { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Type}, {Sex}, {Age}";
        }
    }
}