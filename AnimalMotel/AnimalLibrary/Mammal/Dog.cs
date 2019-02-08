/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public class Dog : Mammal
    {
        public string FavouriteFood { get; set; }

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Dog() : base()
        {
            mammalSpecies = MammalSpecies.Dog;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">int Id of the animal</param>
        /// <param name="name">string name of the animal</param>
        /// <param name="age">int age of the animal</param>
        /// <param name="category">Category of the animal</param>
        /// <param name="gender">Gender of the animal</param>
        /// <param name="numOfTeeth">int number of teeth of the animal</param>
        /// <param name="favouriteFood"></param>
        public Dog(int id, string name, int age, Category category, Gender gender, int numOfTeeth, string favouriteFood) : base (id, name, age, category, gender, numOfTeeth)
        {
            this.FavouriteFood = favouriteFood;
            mammalSpecies = MammalSpecies.Dog;
        }

        /// <summary>
        /// Overrides the add species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        internal void AddSpeciesInformation(string speciesInformation)
        {
            FavouriteFood = speciesInformation;
        }

        /// <summary>
        /// Returns the extra species inforamation.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + " Favourite food: " + FavouriteFood;
        }
    }
}
