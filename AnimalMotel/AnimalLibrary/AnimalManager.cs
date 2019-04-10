using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Project Animal motel v1
/// </summary>

namespace AnimalMotel
{
    [Serializable]
    class AnimalManager : ListManager<Animal>
    {
        /// <summary>
        /// Constructor that creates a new list of animals.
        /// </summary>
        public AnimalManager()
        {
       
        }
        /// <summary>
        /// Add an animal
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            int id = CreateNewID();
            animal.Id = id;
            base.Add(animal);
        }

        /// <summary>
        /// Creates a new ID for the animal
        /// </summary>
        /// <returns></returns>
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
