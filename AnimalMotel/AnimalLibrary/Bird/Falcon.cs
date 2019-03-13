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
        private EaterType eaterType = EaterType.Carnivore;
        private FoodSchedule foodSchedule;

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Falcon() : base()
        {
            birdSpecies = BirdSpecies.Falcon;
            foodSchedule =  new FoodSchedule();
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
        public Falcon(string name, int age, Category category, Gender gender, int flyingSpeed, string favouriteFood) : base(name, age, category, gender, flyingSpeed)
        {
            this.FavouriteFood1 = favouriteFood;
            birdSpecies = BirdSpecies.Falcon;
            foodSchedule = new FoodSchedule();
        }

        /// <summary>
        /// returns or set the favourite food of the animal.
        /// </summary>
        public string FavouriteFood {
            get => FavouriteFood1;
            set => FavouriteFood1 = value;
        }

        /// <summary>
        /// Add species information.
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
            foodSchedule.AddFoodScheduleItem("Morning one mouse \n" +
                     "Dinner once mouse");
        }

        /// <summary>
        /// Returns the species information.
        /// </summary>
        public override string SpeciesInformation => FavouriteFood1;

        public string FavouriteFood1 { get; set; }

        /// <summary>
        /// Returns the species information.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + " Favourite food: " + FavouriteFood;
        }
    }

}
