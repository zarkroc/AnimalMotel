/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// Updated 2018-04-10
/// </summary>
namespace AnimalMotel
{
    public class Dog : Mammal
    {
        private EaterType eaterType = EaterType.Omnivorous;
        private FoodSchedule foodSchedule;

        public string FavouriteFood { get => FavouriteFood1; set => FavouriteFood1 = value; }

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Dog() : base()
        {
            mammalSpecies = MammalSpecies.Dog;
            foodSchedule = new FoodSchedule();
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
        public Dog(string name, int age, Category category, Gender gender, int numOfTeeth, string favouriteFood) : base (name, age, category, gender, numOfTeeth)
        {
            this.FavouriteFood1 = favouriteFood;
            mammalSpecies = MammalSpecies.Dog;
            foodSchedule = new FoodSchedule();
        }
        
        /// <summary>
        /// Overrides the add species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        public override void AddSpeciesInformation(string speciesInformation)
        {
            FavouriteFood1 = speciesInformation;
        }

        /// <summary>
        /// Returns the food schedule
        /// </summary>
        /// <returns>FoodSchedule</returns>
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }


        /// <summary>
        /// Returns the eatertype
        /// </summary>
        /// <returns>EaterType</returns>
        public override EaterType GetEaterType()
        {
            return eaterType;
        }

        /// <summary>
        /// Creates the food schedule
        /// </summary>
        public override void CreateFoodSchedule()
        {
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat " + FavouriteFood1);
        }

        /// <summary>
        /// Returns the extra species inforamation.
        /// </summary>
        public override string SpeciesInformation => FavouriteFood1;

        public string FavouriteFood1 { get; set; }

        /// <summary>
        /// Returns the extra species inforamation.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + " Favourite food: " + FavouriteFood;
        }
    }
}
