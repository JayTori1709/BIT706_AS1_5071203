using System;

namespace WeChipItAvalonia.Models
{
    public class Microchip
    {
        public required string MicrochipNumber { get; set; }
        public required string TargetType { get; set; }
        public DateTime DateIssued { get; set; }
        public required string State { get; set; }

        public override string ToString()
        {
            return $"{MicrochipNumber}, {TargetType}, issued {DateIssued:dd-MMM-yyyy}, {State}";
        }
    }
}
