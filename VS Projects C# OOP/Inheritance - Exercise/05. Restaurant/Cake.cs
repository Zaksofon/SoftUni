
namespace Restaurant
{
    public class Cake : Dessert
    {
        private const int GRAMS = 250;
        private const int CALORIES = 1000;
        private const int CAKE_PRICE = 5;
        public Cake(string name) 
            : base(name, CAKE_PRICE, GRAMS, CALORIES)
        {
        }
    }
}
