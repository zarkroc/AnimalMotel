using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    class Staff
    {
        private IListManager<string> m_qualifications;

        public Staff()
        {
            m_qualifications = new ListManager<string>();
        }

        public string Name { get; set; }
    }
}
