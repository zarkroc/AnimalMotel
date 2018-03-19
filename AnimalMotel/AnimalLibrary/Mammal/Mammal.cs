/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2018-02-25
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public abstract class Mammal : Animal
    {
        private int numOfTeeth;
        protected MammalSpecies mammalSpecies;

        /// <summary>
        /// Constructor that will set the category.
        /// </summary>
        public Mammal() : base()
        {
            this.Category = Category.Mammal;
        }

        /// <summary>
        /// Constructor that will set the properties.
        /// </summary>
        /// <param name="id">int Id of the animal</param>
        /// <param name="name">string name of the animal</param>
        /// <param name="age">int age of the animal</param>
        /// <param name="category">Category of the animal</param>
        /// <param name="gender">Gender of the animal</param>
        /// <param name="numOfTeeth">int number of teeth of the animal</param>
        public Mammal(int id, string name, int age, Category category, Gender gender, int numOfTeeth) : base(id, name, age, category, gender)
        {
            this.NumOfTeeth = numOfTeeth;
            this.Category = Category.Mammal;
        }


        /// <summary>
        /// Set or return the number of teeth the animal has.
        /// </summary>
        public int NumOfTeeth { get => numOfTeeth; set => numOfTeeth = value; }

        /// <summary>
        /// Overrides the add category information.
        /// </summary>
        /// <param name="categoryInformation"></param>
        public override void AddCategoryInformation(string categoryInformation)
        {
            int.TryParse(categoryInformation, out numOfTeeth);
        }

        /// <summary>
        /// Returns a formatted version of the category information.
        /// </summary>
        public override string CategoryInformation => "Num of teeth: " + NumOfTeeth.ToString();
    }
}
