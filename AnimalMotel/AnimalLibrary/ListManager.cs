using System;
using System.Collections.Generic;
/// <summary>
/// Author: Tomas Perers ai2891
/// Date: 2019-03-11
/// /// Project Animal motel v3
/// </summary>
namespace AnimalMotel
{
    [Serializable]
    class ListManager<T> : IListManager<T>
    {
        private List<T> m_list;

        public int Count => m_list.Count;

        /// <summary>
        /// Constructro creates a new list
        /// </summary>
        public ListManager()
        {
            m_list = new List<T>();
        }

        /// <summary>
        /// Add an object to the list
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        public bool Add(T aType)
        {
            if (m_list == null)
                return false;
            else if (aType == null)
                return false;
            else
            {
                m_list.Add(aType);
                return true;
            }
        }

        /// <summary>
        /// Reset the list
        /// </summary>
        public void Reset()
        {
            m_list = new List<T>();
        }

        /// <summary>
        /// Change object at index.
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="anIndex"></param>
        /// <returns></returns>
        public bool ChangeAt(T aType, int anIndex)
        {
            if (CheckIndex(anIndex))
            {
                if (m_list != null)
                {
                    if (aType != null)
                    {
                        m_list[anIndex] = aType;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Check that the index is valid for the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool CheckIndex(int index)
        {
            if (index > -1 && index < Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete everything in the list
        /// </summary>
        public void DeleteAll()
        {
            m_list.Clear();
        }

        /// <summary>
        /// Remove the object at specefied index
        /// </summary>
        /// <param name="anIndex"></param>
        /// <returns></returns>
        public bool DeleteAt(int anIndex)
        {
            if (CheckIndex(anIndex))
            {
                m_list.RemoveAt(anIndex);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Return the object at the index
        /// </summary>
        /// <param name="anIndex"></param>
        /// <returns></returns>
        public T GetAt(int anIndex)
        {
            if (CheckIndex(anIndex))
                return m_list[anIndex];
            else
                return default(T);
        }

        /// <summary>
        /// Convert list to a stringarray
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
            string[] output = new string[Count];
            int i = 0;
            foreach (T aType in m_list)
            {
                output[i] = aType.ToString();
                i++;
            }
            return output;
        }

        /// <summary>
        /// Convert the list to a list of strings.
        /// </summary>
        /// <returns></returns>
        public List<string> ToStringList()
        {
            List<string> output = new List<string>();
            foreach (T aType in m_list)
            {
                output.Add(aType.ToString());
            }
            return output;
        }

        public bool BinarySerialize(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public bool BinaryDeSerialize(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public bool XMLSerialize(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
