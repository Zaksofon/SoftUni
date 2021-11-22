
namespace Restaurant
{
    public class Dessert : Food
    {
        public int Calories { get; set; }
        public Dessert(string name, decimal price, double grams, int calories) 
            : base(name, price, grams)
        {
            Calories = calories;
        }
    }
}
