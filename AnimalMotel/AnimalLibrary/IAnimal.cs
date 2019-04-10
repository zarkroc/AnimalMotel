using System.Runtime.Serialization;
/// <summary>
/// Interface for animals.
/// This needs to be implemted by all animals.
/// Author: Tomas Perers
/// Date: 2019-03-10
/// </summary>
namespace AnimalMotel
{
    public interface IAnimal : ISerializable
    {
        
        int Id { get; set; }
        Gender Gender { get; set; }
        string Name { get; set; }

        EaterType GetEaterType();
        FoodSchedule GetFoodSchedule();
        string GetSpecies();
    }
}
