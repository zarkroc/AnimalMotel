﻿using System;
using System.Collections.Generic;
/// <summary>
/// Author: Tomas Perers ai2891
/// Date: 2019-03-11
/// /// Project Animal motel v3
/// </summary>
namespace AnimalMotel
{
    [Serializable]
    public class ListManager<T> : IListManager<T>
    {
        public int Count => List.Count;

        public List<T> List { get; set; }

        /// <summary>
        /// Constructro creates a new list
        /// </summary>
        public ListManager()
        {
            List = new List<T>();
        }

        /// <summary>
        /// Add an object to the list
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        public bool Add(T aType)
        {
            if (List == null)
                return false;
            else if (aType == null)
                return false;
            else
            {
                List.Add(aType);
                return true;
            }
        }

        /// <summary>
        /// Reset the list
        /// </summary>
        public void Reset()
        {
            List = new List<T>();
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
                if (List != null)
                {
                    if (aType != null)
                    {
                        List[anIndex] = aType;
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
            List.Clear();
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
                List.RemoveAt(anIndex);
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
                return List[anIndex];
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
            foreach (T aType in List)
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
            foreach (T aType in List)
            {
                output.Add(aType.ToString());
            }
            return output;
        }

        public void BinarySerialize(string fileName)
        {
            BinSerializerUtility.Serialize(List, fileName);
        }

        public void BinaryDeSerialize(string fileName)
        {
            List = BinSerializerUtility.Deserialize<List<T>>(fileName);
        }

        public void XMLSerialize(string fileName)
        {
            XMLSerializerUtility.Serialize(List, fileName);
        }

        public void XMLDeSerialize(string fileName)
        {
            List = XMLSerializerUtility.Deserialize<List<T>>(fileName);
        }
    }
}
