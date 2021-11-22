
namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEE_PRICE = (decimal) 3.50;
        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine) 
            : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;
        }
    }
}
