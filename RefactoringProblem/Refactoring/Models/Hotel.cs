
namespace Refactoring.Models
{
    public class Hotel : AccommodationBase
    {
        public int Rooms { get; set; }
        public Hotel(string name, float price, float margin, int rooms)
          : base(name, price, margin)
        {
            Rooms = rooms;
        }

        public override double CalculateRevenue() => Math.Round(Rooms * Price, 2);

        public override double CalculateProfit() => Math.Round(CalculateRevenue() * (Margin / 100), 2);
    }
}
