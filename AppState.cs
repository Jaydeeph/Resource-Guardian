using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGuardian
{
    class AppState
    {
        public List<ProcessModel> Processes { get; set; } = new List<ProcessModel>();
        public List<ServiceModel> Services { get; set; } = new List<ServiceModel>();
    }
}
