/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public class Falcon : Bird
    {

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Falcon() : base()
        {
            birdSpecies = BirdSpecies.Falcon;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">int Id of the animal</param>
        /// <param name="name">string name of the animal</param>
        /// <param name="age">int age of the animal</param>
        /// <param name="category">Category of the animal</param>
        /// <param name="gender">Gender of the animal</param>
        /// <param name="flyingSpeed">int flying speed of animal</param>
        /// <param name="favouriteFood">string favourite food of animal</param>
        public Falcon(int id, string name, int age, Category category, Gender gender, int flyingSpeed, string favouriteFood) : base(id, name, age, category, gender, flyingSpeed)
        {
            this.FavouriteFood = favouriteFood;
        }

        /// <summary>
        /// returns or set the favourite food of the animal.
        /// </summary>
        public string FavouriteFood { get; set; }

        /// <summary>
        /// Add species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        internal void AddSpeciesInformation(string speciesInformation)
        {
            FavouriteFood = speciesInformation;
        }

        /// <summary>
        /// Returns the species information.
        /// </summary>
        public override string ToString() {
            return base.ToString() + " Favourite food: " + FavouriteFood;
        }
    }
}
