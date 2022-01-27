using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => ingredients.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredient) && ingredients.Count <= Capacity)
            {
                ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            Ingredient ingredientToRemove = ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredientToRemove != null)
            {
                ingredients.Remove(ingredientToRemove);
                return true;
            }

            return false;
        }
       
        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredientToFind = ingredients.FirstOrDefault(i => i.Name == name);

            return ingredientToFind;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngredient = ingredients
                .OrderByDescending(i => i.Alcohol == MaxAlcoholLevel)
                .FirstOrDefault();

            return mostAlcoholicIngredient;
        }
        //•	Method Report() - returns information about the Cocktail and the Ingredients inside it in the following format:
        //"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}
        //{Ingredient1}
        //{Ingredient2}"
        public string Report()
        {
            var result = $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}\n";
            foreach (Ingredient ingredient in ingredients)
            {
                result += $"{ingredient}\n";
            }

            return result.TrimEnd();
        }
    }
}
