/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public class Parrot : Bird
    {
        public string TalkingDialect { get; set; }
        private EaterType eaterType = EaterType.Carnivore;
        private FoodSchedule foodSchedule;

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Parrot() : base()
        {
            birdSpecies = BirdSpecies.Parrot;
            foodSchedule = new FoodSchedule();
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat seeds");
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
            this.TalkingDialect = talkingDialect;
            foodSchedule = new FoodSchedule();
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat seeds");
        }
        
        /// <summary>
        /// Adds species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        internal void AddSpeciesInformation(string speciesInformation)
        {
            TalkingDialect = speciesInformation;
        }

        /// <summary>
        /// Returns the speciesinformation.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + " Talking dialect: " + TalkingDialect;
        }
    }
}
