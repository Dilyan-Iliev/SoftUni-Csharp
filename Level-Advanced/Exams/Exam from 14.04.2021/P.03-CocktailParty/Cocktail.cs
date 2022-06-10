using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly Dictionary<string, Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcohol)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcohol;
            ingredients = new Dictionary<string, Ingredient>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; } //max allowed ingredients in cocktail
        public int MaxAlcoholLevel { get; private set; }
        public IReadOnlyDictionary<string, Ingredient> Ingredients => ingredients;
        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Value.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.ContainsKey(ingredient.Name)
                && Capacity > ingredients.Count)
            {
                ingredients[ingredient.Name] = ingredient;
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients[name];

            if (ingredient.Name == name)
            {
                ingredients.Remove(name);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name) => ingredients
            .Where(x => x.Value.Name == name)
            .FirstOrDefault().Value;

        public Ingredient GetMostAlcoholicIngredient() => ingredients
            .OrderByDescending(x => x.Value.Alcohol)
            .First().Value;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in ingredients)
            {
                sb.AppendLine(item.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
