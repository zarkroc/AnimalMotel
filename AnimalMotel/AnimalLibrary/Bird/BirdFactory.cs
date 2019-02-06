using System;
using System.Diagnostics;
/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// Project Animal motel v1
/// </summary>
namespace AnimalMotel
{
    public class BirdFactory
    {
        public static Bird CreateBird(BirdSpecies species)
        {
            Bird animalObject = null;

            try
            {
                switch (species)
                {
                    case BirdSpecies.Falcon:
                        animalObject = new Falcon();
                        break;
                    case BirdSpecies.Parrot:
                        animalObject = new Parrot();
                        break;
                    default:
                        Debug.Assert(false, "Not implemented yet");
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                animalObject.Category = Category.Bird;
            }
            return animalObject;
        }
    }
}
