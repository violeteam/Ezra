using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ezra.Popup
{
    public partial class Ok : Form
    {
        public Ok(string title, string subtitle, string message)
        {
            InitializeComponent();
            Initialize(title, subtitle, message);
        }

        public void Initialize(string title, string subtitle, string message)
        {
            Region = Region.FromHrgn(Manager.Ui.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            label_title.Text = title;
            label_subtitle.Text = subtitle;
            label_message.Text = message;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
