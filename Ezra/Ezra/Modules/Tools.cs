using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezra.Modules
{
    public class Tools
    {
        public static RegistryKey create_registry(RegistryKey root, List<string> path)
        {
            bool first = true;
            string buffer = "";
            RegistryKey key = null;

            foreach (string name in path)
            {
                if (first == true)
                {
                    buffer = name;
                    first = false;
                } else
                {
                    buffer += $"\\{name}";
                }
                key = root.OpenSubKey(buffer, true);
                if (key == null)
                {
                    key = root.CreateSubKey(buffer);
                }
            }

            return (key);
        }
    }
}
