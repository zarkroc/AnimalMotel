using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2018-02-20
/// Project Animal motel v1
/// </summary>

namespace AnimalMotel
{
    class AnimalManager
    {
        private List<Animal> listOfAnimals;

        /// <summary>
        /// Constructor that creates a new list of animals.
        /// </summary>
        public AnimalManager()
        {
            listOfAnimals = new List<Animal>();
       
        }

        /// <summary>
        /// Get the ammount of animals in the list.
        /// </summary>
        public int Count
        {
            get
            {
                if (listOfAnimals != null)
                    return listOfAnimals.Count;
                else
                    return 0;
            }
        }
        
        /// <summary>
        /// Returns the animal at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Animal GetAnimal(int index)
        {
            if (index > -1)
                return listOfAnimals.ElementAt(index);
            else
                return null;
        }

        /// <summary>
        /// Create a new animal ID, if no animal exist in the list create the id 100 + count
        /// otherwise return id of last animal in the list + 1.
        /// </summary>
        /// <returns></returns>
        private int CreateNewID()
        {

            if (Count > 0)
            {
                Animal lastAnimal = listOfAnimals.Last();
                return lastAnimal.Id + 1;
            }
            else
                return 100 + Count;
        }

        /// <summary>
        /// Adds an animal to the list, but first assigns an Id to the animal.
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            animal.Id = CreateNewID();
            listOfAnimals.Add(animal);
        }


        /// <summary>
        /// Removes an animal at index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAnimal(int index)
        {
            listOfAnimals.Remove(GetAnimal(index));
        }
    }
}
