namespace Refactoring.Models
{
    public class Apartment : AccommodationBase
    {
        public int Participants { get; set; }
        public Apartment(string name, float price, float margin, int participants)
            : base(name, price, margin)
        {
            Participants = participants;
        }
        public override double CalculateRevenue() => Math.Round(Participants * Price, 2);
        public override double CalculateProfit()
            => Math.Round(CalculateRevenue() * (Margin / 100), 2);
    }
}
