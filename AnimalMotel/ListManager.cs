using System.Collections.Generic;
/// <summary>
/// Author: Tomas Perers ai2891
/// Date: 2018-04-16
/// /// Project Animal motel v3
/// </summary>
namespace AnimalMotel
{
    class ListManager<T> : IListManager<T>
    {
        private List<T> m_list;

        public int Count => m_list.Count;

        public ListManager()
        {
            m_list = new List<T>();
        }

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

        public void Reset()
        {
            m_list = new List<T>();
        }

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

        public bool CheckIndex(int index)
        {
            if (index > -1 && index > Count)
                return true;
            else
                return false;
        }

        public void DeleteAll()
        {
            m_list.Clear();
        }

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

        public T GetAt(int anIndex)
        {
            if (CheckIndex(anIndex))
                return m_list[anIndex];
            else
                return default(T);
        }

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

        public List<string> ToStringList()
        {
            List<string> output = new List<string>();
            foreach (T aType in m_list)
            {
                output.Add(aType.ToString());
            }
            return output;
        }
    }
}
