namespace AnimalMotel
{
    public class Recepie 
    {
        public string Name { get; set; }
        internal ListManager<string> Ingredients { get; set; }

        public Recepie()
        {
            Ingredients = new ListManager<string>();
        }

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
