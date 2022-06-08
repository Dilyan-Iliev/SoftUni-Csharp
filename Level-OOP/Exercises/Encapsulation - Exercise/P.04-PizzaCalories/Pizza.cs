using System;
using System.Collections.Generic;
using System.Linq;

namespace P._04_PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set { this.dough = value; }
        }

        public IReadOnlyCollection<Topping> Toppings => this.toppings; 
                                                     //ако някой отвън се опита да достъпи Toppings,
                                                     //няма да може да му каже Add, защото е ReadOnly,
                                                     //ако иска да добавя ще трябва да мине през нашия метод AddTopping
                                                     //където имаме валидация
        

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10) 
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
        
        public double CalculateTotalCalories()
        {
            double result = this.Dough.Calories + this.toppings.Sum(x => x.Calories);

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateTotalCalories():f2} Calories.";
        }
    }
}
