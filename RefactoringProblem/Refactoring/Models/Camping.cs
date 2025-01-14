namespace Refactoring.Models
{
    public class Camping : AccommodationBase
    {
        public double SpecialLevy { get; set; }

        public Camping(string name, float price, float margin, double specialLevy)
            : base(name, price, margin)
        {
            SpecialLevy = specialLevy;
        }

        public override double CalculateRevenue() => Math.Round(Price, 2);

        public override double CalculateProfit()
            => Math.Round(CalculateRevenue() * (Margin / 100), 2) - SpecialLevy;
    }
}
