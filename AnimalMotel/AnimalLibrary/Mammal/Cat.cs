/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// Updated 2018-04-10
/// </summary>
namespace AnimalMotel
{
    public class Cat : Mammal
    {
        private string socialBehaviour;
        private EaterType eaterType = EaterType.Carnivore;
        private FoodSchedule foodSchedule;

        public string SocialBehaviour { get => socialBehaviour; set => socialBehaviour = value; }

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Cat() : base()
        {
            mammalSpecies = MammalSpecies.Cat;
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
        /// <param name="socialBehaviour">string social behavoir</param>
        public Cat(int id, string name, int age, Category category, Gender gender, int numOfTeeth, string socialBehaviour) : base(id, name, age, category, gender, numOfTeeth)
        {
            this.socialBehaviour = socialBehaviour;
            mammalSpecies = MammalSpecies.Cat;
            foodSchedule = new FoodSchedule();
        }

        /// <summary>
        /// Overrides the add species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        public override void AddSpeciesInformation(string speciesInformation)
        {
            socialBehaviour = speciesInformation;
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
        /// Return the specie
        /// </summary>
        /// <returns>string</returns>
        public override string GetSpecies()
        {
            return "Cat";
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
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat mice");
        }

        /// <summary>
        /// Returns the species information.
        /// </summary>
        public override string SpeciesInformation => "Social behavoir: " + socialBehaviour;
    }
}
