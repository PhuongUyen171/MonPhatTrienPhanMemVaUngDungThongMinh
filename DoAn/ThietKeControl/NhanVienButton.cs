using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ThietKeControl
{
    public partial class NhanVienButton : ButtonX
    {
        
        public NhanVienButton()
        {
            InitializeComponent();
            this.Text = "Nhân viên";
            this.Size = new Size(150,180);
            //this.ImagePosition=
            this.ForeColor = Color.Red;
            this.ColorTable = eButtonColor.Orange;
            
            this.Image= Image.FromFile(Application.StartupPath+"\\Resource\\personal.png");
            this.ImagePosition = eImagePosition.Top;
            this.Shape = new RoundRectangleShapeDescriptor(10);
        }

    }
}
