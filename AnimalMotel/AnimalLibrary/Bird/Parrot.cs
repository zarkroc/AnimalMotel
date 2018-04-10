/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2018-03-10
/// Project Animal motel v1
/// Updated 2018-04-10
/// </summary>
namespace AnimalMotel
{
    public class Parrot : Bird
    {
        private string talkingDialect;
        private EaterType eaterType = EaterType.Herbivore;
        private FoodSchedule foodSchedule;

        public string TalkingDialect { get => talkingDialect; set => talkingDialect = value; }

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Parrot() : base()
        {
            birdSpecies = BirdSpecies.Parrot;
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
        /// <param name="flyingSpeed">int flying speed of animal</param>
        /// <param name="talkingDialect">string talking dialect of animal</param>
        public Parrot(int id, string name, int age, Category category, Gender gender, int flyingSpeed, string talkingDialect) : base(id, name, age, category, gender, flyingSpeed)
        {
            this.talkingDialect = talkingDialect;
            foodSchedule = new FoodSchedule();
        }
        
        /// <summary>
        /// Adds species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        public override void AddSpeciesInformation(string speciesInformation)
        {
            talkingDialect = speciesInformation;
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
            return "Parrot";
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
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat seeds");
        }

        /// <summary>
        /// Returns the speciesinformation.
        /// </summary>
        public override string SpeciesInformation => "Talking dialect: " + talkingDialect;
    }
}
