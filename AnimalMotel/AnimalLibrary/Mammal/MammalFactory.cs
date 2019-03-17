using System;
using System.Diagnostics;
/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// </summary>
namespace AnimalMotel
{
    public class MammalFactory
    {
        public static Mammal CreateMammal(MammalSpecies species)
        {
            Mammal animalObject = null; 

            try
            {
                switch(species)
                {
                    case MammalSpecies.Cat:
                        animalObject = new Cat();
                        break;
                    case MammalSpecies.Dog:
                        animalObject = new Dog();
                        break;
                    default:
                        Debug.Assert(false, "Not implemented yet");
                        break;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                animalObject.Category = Category.Mammal;
            }
            return animalObject;
        }
    }
}
