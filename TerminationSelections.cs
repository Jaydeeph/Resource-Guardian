using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGuardian
{
    public class TerminationSelections
    {
        public List<string> Processes { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
    }
}
