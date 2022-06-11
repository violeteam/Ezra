using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezra.Configurations
{
    public class Configurations
    {
        public class Configuration
        {
            public string version { get; set; }
            public List<Modules.Tweaks.Module> modules { get; set; }
        }
    }
}
