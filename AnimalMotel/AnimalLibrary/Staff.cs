using System;
/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-03-15
/// </summary>
namespace AnimalMotel
{
    [Serializable]
    public class Staff
    {
        private IListManager<string> m_qualifications;

        /// <summary>
        /// Create s new list of qualifications using ListManager
        /// </summary>
        public Staff()
        {
            Qualifications = new ListManager<string>();
        }

        /// <summary>
        /// Get and set the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get and set the list.
        /// </summary>
        public IListManager<string> Qualifications { get => m_qualifications; set => m_qualifications = value; }

        /// <summary>
        /// Returns everyting as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = Name + ": ";
            foreach (var item in Qualifications.ToStringList())
            {
                output += item + " ";
            }
            return output;
        }
    }
}
