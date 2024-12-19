using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Utility.Attributes
{
    public class EnumDescription : Attribute
    {
        private readonly int _order = 1;
        private readonly string _description;

        public string Description
        {
            get { return _description; }
        }

        public int Order
        {
            get { return _order; }
        }

        public EnumDescription(string description)
        {
            _description = description;
        }

        public EnumDescription(string description, int order)
        {
            _description = description;
            _order = order;
        }
    }
}
