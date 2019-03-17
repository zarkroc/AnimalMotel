/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-03-15
/// </summary>
namespace AnimalMotel
{
    public class Recepie 
    {
        public string Name { get; set; }
        internal ListManager<string> Ingredients { get; set; }

        /// <summary>
        /// Create s new list of ingriedients using the listmanager
        /// </summary>
        public Recepie()
        {
            Ingredients = new ListManager<string>();
        }

        /// <summary>
        /// Returns everyting as a list.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = Name + ": ";
            for (var i=0; i < Ingredients.Count; i++)
            {
                output += Ingredients.GetAt(i) + " ";
            }
            return output;
        }
    }
}
