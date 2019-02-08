/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public abstract class Animal
    {
        private string name;
        private int id;
        private int age;
        private Gender gender;
        private Category category;
        
        /// <summary>
        /// Set and get the name of the animal
        /// </summary>
        public virtual string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// set and get the id of an animal.
        /// </summary>
        public virtual int Id
        {
            get => id;
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Set and get the age of the animal.
        /// </summary>
        public virtual int Age
        {
            get => age;
            set => age = value;
        }

        /// <summary>
        /// Set and get the Gender of the animal
        /// </summary>
        public virtual Gender Gender
        {
            get => gender;
            set => gender = value;
        }

        /// <summary>
        /// Set and get the category of the animal
        /// </summary>
        public virtual Category Category
        {
            get => category;
            set => category = value;
        }


        /// <summary>
        /// Constructor to create an animal, set the properties to default values.
        /// </summary>
        public Animal()
        {
            this.age = 0;
            this.category = 0;
            this.gender = 0;
            this.id = -1;
            this.name = null;
        }

        /// <summary>
        /// Constructur to create an animal with set properties.
        /// </summary>
        /// <param name="id">int Id of animal</param>
        /// <param name="name">sting name of animal</param>
        /// <param name="age">int age of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="gender">Gender of animal</param>
        public Animal(int id, string name, int age, Category category, Gender gender)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.category = category;
            this.gender = gender;
        }

        /// <summary>
        /// ToString method
        /// Returns a formatted string with id, name, age, category, gender, CategoryInformation and SpeciesInformation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,-3} {1,-17} {2,-8} {3,-11} {4,-11}", id, name, age, category, gender);
        }
    }
}
