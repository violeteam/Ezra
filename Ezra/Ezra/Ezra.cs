using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ezra
{
    public partial class Ezra : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private Configurations.Configurations.Configuration profile = new Configurations.Configurations.Configuration();

        public Ezra()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Region = Region.FromHrgn(Manager.Ui.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            worker.DoWork += new DoWorkEventHandler(apply);
            profile.modules = new List<Modules.Tweaks.Module>()
            {
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "SOFTWARE",
                        "Policies",
                        "Microsoft",
                        "Windows Defender"
                    },
                    "DisableAntiSpyware",
                    0x00000001,
                    Registry.LocalMachine,
                    button_remove_defender
                ),
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "SOFTWARE",
                        "Policies",
                        "Microsoft",
                        "Windows Defender"
                    },
                    "DisableAntiVirus",
                    0x00000001,
                    Registry.LocalMachine,
                    button_remove_defender
                ),
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "SOFTWARE",
                        "Policies",
                        "Microsoft",
                        "Windows",
                        "Windows Search"
                    },
                    "AllowCortana",
                    0x00000000,
                    Registry.LocalMachine,
                    button_remove_cortana
                ),
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "Control Panel",
                        "Mouse"
                    },
                    "MouseSpeed",
                    "0",
                    Registry.CurrentUser,
                    button_remove_mouse_acceleration
                ),
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "Control Panel",
                        "Mouse"
                    },
                    "MouseThreshold1",
                    "0",
                    Registry.CurrentUser,
                    button_remove_mouse_acceleration
                ),
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "Control Panel",
                        "Mouse"
                    },
                    "MouseThreshold2",
                    "0",
                    Registry.CurrentUser,
                    button_remove_mouse_acceleration
                )
                ,
                new Modules.Tweaks.Module(
                    new List<string>()
                    {
                        "SOFTWARE",
                        "Policies",
                        "Microsoft",
                        "Windows"
                    },
                    "DisableFileSyncNGSC",
                    0x00000001,
                    Registry.LocalMachine,
                    button_remove_onedrive
                )
            };
        }

        private void apply(object sender, EventArgs e)
        {
            RegistryKey key = null;

            foreach (Modules.Tweaks.Module module in profile.modules)
            {
                if (module.button.Checked == true)
                {
                    key = Modules.Tools.create_registry((RegistryKey)module.registry, module.requirements);
                    Console.WriteLine($"{key} {module.key} {module.value}");
                    key.SetValue(module.key, module.value);
                }
            }
            key.Close();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            Manager.Threads.worker(worker);
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
