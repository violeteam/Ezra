using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezra.Modules
{
    public class Tweaks
    {
        [Serializable]
        public class Module
        {
            public List<string> requirements { get; set; }
            public string key { get; set; }
            public object value { get; set; }
            public RegistryKey registry { get; set; }
            public Bunifu.UI.WinForms.BunifuToggleSwitch2 button { get; set; }

            public Module(List<string> irequirements, string ikey, object ivalue, RegistryKey iregistry, Bunifu.UI.WinForms.BunifuToggleSwitch2 ibutton)
            {
                key = ikey;
                value = ivalue;
                button = ibutton;
                registry = iregistry;
                requirements = irequirements;
            }
        }
    }
}
