using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThietKeControl
{
    public partial class NumbericTextbox : TextBox
    {
        public NumbericTextbox()
        {
            //InitializeComponent();
            this.Size = new Size(150, 24);
            this.KeyPress += NumbericTextbox_KeyPress;
        }

        private void NumbericTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
