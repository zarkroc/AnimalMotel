namespace AnimalMotel
{
    public class Staff
    {
        private IListManager<string> m_qualifications;

        public Staff()
        {
            Qualifications = new ListManager<string>();
        }

        public string Name { get; set; }
        public IListManager<string> Qualifications { get => m_qualifications; set => m_qualifications = value; }

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
