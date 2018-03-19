/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2018-03-10
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public abstract class Bird : Animal
    {
        private int flyingSpeed;
        protected BirdSpecies birdSpecies;
        
        /// <summary>
        /// Constructor that will set the category to bird.
        /// </summary>
        public Bird() : base()
        {
            this.Category = Category.Bird;
        }

        /// <summary>
        /// Constructor that will set the properties to specefied values.
        /// </summary>
        /// <param name="id">int Id of the animal</param>
        /// <param name="name">string name of the animal</param>
        /// <param name="age">int age of the animal</param>
        /// <param name="category">Category of the animal</param>
        /// <param name="gender">Gender of the animal</param>
        /// <param name="flyingSpeed">int flying speed of the animal</param>
        public Bird(int id, string name, int age, Category category, Gender gender, int flyingSpeed) : base(id, name, age, category, gender)
        {
            this.FlyingSpeed = flyingSpeed;
            this.Category = Category.Bird;
        }

        /// <summary>
        /// Return or set the flying speed of the animal
        /// </summary>
        public int FlyingSpeed { get => flyingSpeed; set => flyingSpeed = value; }
        
        /// <summary>
        /// Overrides the add category information.
        /// </summary>
        /// <param name="categoryInformation"></param>
        public override void AddCategoryInformation(string categoryInformation)
        {
            int.TryParse(categoryInformation, out flyingSpeed);
        }

        /// <summary>
        /// Returns a formatted version of the category information.
        /// </summary>
        public override string CategoryInformation => "Fying speed: " + FlyingSpeed.ToString();
    }
}
