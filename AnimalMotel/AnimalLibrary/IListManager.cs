using System.Collections.Generic;

/// <summary>
/// Author: Tomas Perers ai2891
/// Date: 2018-04-16
/// Project Animal motel v1
/// An interface for a ListManager
/// </summary>
namespace AnimalMotel
{
    public interface IListManager<T>
    {
        int Count { get; }

        bool Add(T aType);
        bool ChangeAt(T aType, int anIndex);
        bool CheckIndex(int index);
        void DeleteAll();
        bool DeleteAt(int anIndex);
        T GetAt(int anIndex);
        string[] ToStringArray();
        List<string> ToStringList();
    }
}
