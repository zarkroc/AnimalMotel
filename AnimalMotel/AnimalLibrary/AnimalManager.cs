using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>

namespace AnimalMotel
{
    class AnimalManager : ListManager<Animal>
    {
        /// <summary>
        /// Constructor that creates a new list of animals.
        /// </summary>
        public AnimalManager()
        {
       
        }

        public void AddAnimal(Animal animal)
        {
            int id = CreateNewID();
            animal.Id = id;
            base.Add(animal);
        }

        private int CreateNewID()
        {


            if (Count > 0)
            {
                
                Animal lastAnimal = base.GetAt(Count -1);
                return lastAnimal.Id + 1;
            }
            else
                return 100 + Count;
        }          
    }
}
