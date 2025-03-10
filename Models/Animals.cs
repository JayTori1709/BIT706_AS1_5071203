namespace WeChipItAvalonia.Models
{
    public class Animal
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Sex { get; set; }
        public bool IsMicrochipped { get; set; }
        public required string MicrochipNumber { get; set; }

        public override string ToString()
        {
            return IsMicrochipped 
                ? $"{Name}, {Sex} {Type}, microchipped [#{MicrochipNumber}]" 
                : $"{Name}, {Sex} {Type}, pending";
        }
    }
}
