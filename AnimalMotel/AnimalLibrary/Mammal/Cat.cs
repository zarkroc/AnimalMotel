﻿/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public class Cat : Mammal
    {
        public string SocialBehaviour { get; set; }
        private EaterType eaterType = EaterType.Carnivore;
        private FoodSchedule foodSchedule;

        /// <summary>
        /// Constructor that will set the species
        /// </summary>
        public Cat() : base()
        {
            mammalSpecies = MammalSpecies.Cat;
            foodSchedule = new FoodSchedule();
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat mice");
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
            this.SocialBehaviour = socialBehaviour;
            mammalSpecies = MammalSpecies.Cat;
            foodSchedule = new FoodSchedule();
            foodSchedule.AddFoodScheduleItem(Name + " likes to eat mice");
        }

        /// <summary>
        /// Overrides the add species information.
        /// </summary>
        /// <param name="speciesInformation"></param>
        internal void AddSpeciesInformation(string speciesInformation)
        {
            SocialBehaviour = speciesInformation;
        }
        /// <summary>
        /// Returns the species information.
        /// </summary>
        public override string ToString() {
            return base.ToString() +  " Social behavoir: " + SocialBehaviour;
        }
    }
}
