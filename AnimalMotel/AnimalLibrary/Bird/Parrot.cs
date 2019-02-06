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
        private string talkingDialect;

        public string TalkingDialect { get => talkingDialect; set => talkingDialect = value; }

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Parrot() : base()
        {
            birdSpecies = BirdSpecies.Parrot;
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
        /// Returns the speciesinformation.
        /// </summary>
        public override string SpeciesInformation => "Talking dialect: " + talkingDialect;
    }
}
