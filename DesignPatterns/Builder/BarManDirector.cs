using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class BarManDirector
    {
        private IBuilder _builder;
        public BarManDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PrepareMargarita()
        {
            _builder.Reset();
            _builder.SetAlcohol(9);
            _builder.SetWater(30);
            _builder.AddIngredients("2 Limones");
            _builder.AddIngredients("Pizca de Sal");
            _builder.AddIngredients("1/2 Taza de Tequila");
            _builder.AddIngredients("3/4 Tazas de licor de naranja");
            _builder.AddIngredients("4 cubos de hielo");
            _builder.Mix();
            _builder.Rest(1000);
        }

        public void PreparePiñaColada()
        {
            _builder.Reset();
            _builder.SetAlcohol(2);
            _builder.SetWater(10);
            _builder.SetMilk(500);
            _builder.AddIngredients("1/2 Taza de Ron");
            _builder.AddIngredients("1/2 Taza de Crema de Coco");
            _builder.AddIngredients("3/4 Taza de Jugo de Piña");
            _builder.Mix();
            _builder.Rest(2000);
        }
    }
}
