namespace Refactoring.Models
{
    public abstract class AccommodationBase
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Margin { get; set; }
        protected AccommodationBase(string name, float price, float margin)
        {
            Name = name;
            Price = price;
            Margin = margin;
        }
        public abstract double CalculateRevenue();
        public abstract double CalculateProfit();
    }
}
