using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    class Recepie 
    {
        public string Name { get; set; }
        internal ListManager<string> Ingredients { get; set; }

        public Recepie()
        {
            Ingredients = new ListManager<string>();
        }

        public override string ToString()
        {
            string output ="";
            for (var i=0; i < Ingredients.Count; i++)
            {
                output += Ingredients.GetAt(i) + " ";
            }
            return output;
        }
    }
}
