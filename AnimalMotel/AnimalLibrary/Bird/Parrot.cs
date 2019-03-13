/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// Updated 2018-04-10
/// </summary>
namespace AnimalMotel
{
    public class Parrot : Bird
    {
        private EaterType eaterType = EaterType.Herbivore;
        private FoodSchedule foodSchedule;

        public string TalkingDialect { get; set; }

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
        public Parrot(string name, int age, Category category, Gender gender, int flyingSpeed, string talkingDialect) : base(name, age, category, gender, flyingSpeed)
        {
            this.TalkingDialect = talkingDialect;
            foodSchedule = new FoodSchedule();
        }
        
        /// <summary>
        /// Adds species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        public override void AddSpeciesInformation(string speciesInformation)
        {
            TalkingDialect = speciesInformation;
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
            foodSchedule.AddFoodScheduleItem("Morning water and some seeds");
        }

        /// <summary>
        /// Returns the speciesinformation.
        /// </summary>
        public override string SpeciesInformation => TalkingDialect;

        /// <summary>
        /// Returns the speciesinformation.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + " Talking dialect: " + TalkingDialect;
        }
    }
}
