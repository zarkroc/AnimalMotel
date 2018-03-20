using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public interface IAnimal
    {
        
        int ID { get; set; }
        Gender Gender { get; set; }
        string Name { get; set; }

        EaterType GetEaterType();
        FoodSchedule GetFoodSchedule();
        string GetSpecies();
    }
}
