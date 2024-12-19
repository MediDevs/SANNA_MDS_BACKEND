using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.Events
{
    public class EntityEventArgs : EventArgs
    {
        public Type[] Types { get; }

        public EntityEventArgs(Type[] types)
        {
            Types = types;
        }
    }
}
