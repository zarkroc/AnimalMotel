/// <summary>
/// Interface for animals.
/// This needs to be implemted by all animals.
/// Author: Tomas Perers
/// Date: 2019-02-08
/// </summary>
namespace AnimalMotel
{
    public interface IAnimal
    {

        int Id { get; set; }
        Gender Gender { get; set; }
        string Name { get; set; }

        EaterType GetEaterType();
        FoodSchedule GetFoodSchedule();
        string GetSpecies();
    }
}