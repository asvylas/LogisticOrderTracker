using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Models
{
    public class Package : Base
    {
        public PackageType Type { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    public enum PackageType
    {
        Pallet,
        Box,
        Container,
        Barrel
    }
}