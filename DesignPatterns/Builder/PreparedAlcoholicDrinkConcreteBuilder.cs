﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class PreparedAlcoholicDrinkConcreteBuilder : IBuilder
    {
        private PreparedDrink _preparedDrink;

        public PreparedAlcoholicDrinkConcreteBuilder()
        {
            Reset();
        }

        public void AddIngredients(string ingredient)
        {
            if (_preparedDrink.Ingredients == null)
                _preparedDrink.Ingredients = new List<string>();
            _preparedDrink.Ingredients.Add(ingredient);
        }

        public void Mix()
        {
            string ingredients = _preparedDrink.Ingredients.Aggregate((i, j) => i + ", " + j);
            _preparedDrink.Result = $"Bebida preparada con {_preparedDrink.Alcohol} de alcohol" +
                $" con los ingredientes {ingredients}";
            Console.WriteLine("Mezclado de ingredientes");

        }

        public void Reset()
        {
            _preparedDrink = new PreparedDrink();
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Ready for drink");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _preparedDrink.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _preparedDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparedDrink.Water = water;
        }

        public PreparedDrink Get() => _preparedDrink;
    }
}
