using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class Operation
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public Operation(string name, int priority)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Priority = priority;
        }
    }
}
