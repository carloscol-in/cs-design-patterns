using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;

        public BarmanDirector(IBuilder builder)
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
            _builder.AddIngredients("Limones");
            _builder.AddIngredients("Sal");
            _builder.AddIngredients("Sal");
            _builder.AddIngredients("Tequila");
            _builder.AddIngredients("Licor de naranja");
            _builder.AddIngredients("Cubos de hielo");
            _builder.Mix();
            _builder.Rest(1000);
        }

        public void PreparePinaColada()
        {
            _builder.Reset();
            _builder.SetAlcohol(20);
            _builder.SetWater(10);
            _builder.SetMilk(500);
            _builder.AddIngredients("Ron");
            _builder.AddIngredients("Crema de Coco");
            _builder.AddIngredients("Jugo de Pina");
            _builder.Mix();
            _builder.Rest(2000);
        }
    }
}
