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
        /// <summary>
        /// Return the number of items 
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add an object to the collection
        /// </summary>
        /// <param name="aType"></param>
        /// <returns>True if sucessful</returns>
        bool Add(T aType);

        /// <summary>
        /// Change an object in the collection
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="anIndex"></param>
        /// <returns>True if sucessful</returns>
        bool ChangeAt(T aType, int anIndex);
        bool CheckIndex(int index);
        void DeleteAll();
        bool DeleteAt(int anIndex);
        T GetAt(int anIndex);
        string[] ToStringArray();
        List<string> ToStringList();
    }
}
