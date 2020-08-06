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
    public partial class NguoiDungButton : ButtonX
    {
        public NguoiDungButton()
        {
            InitializeComponent();
            this.Text = "Người dùng";
            this.Size = new Size(150, 180);
            this.ForeColor = Color.Red;
            this.ColorTable = eButtonColor.Orange;
            this.Image = Image.FromFile(Application.StartupPath+"\\Resource\\offline_user.ico");
            
            this.ImagePosition = eImagePosition.Top;
            this.Shape = new RoundRectangleShapeDescriptor(10);
        }
        public NguoiDungButton(bool hinh)
        {
            InitializeComponent();
            this.Text = "Người dùng";
            this.Size = new Size(150, 180);
            this.ForeColor = Color.Red;
            this.ColorTable = eButtonColor.Orange;
            if(hinh==false)
                this.Image = Image.FromFile(Application.StartupPath + "\\Resource\\offline_user.ico");
            else
                this.Image = Image.FromFile(Application.StartupPath + "\\Resource\\user.ico");
            this.ImagePosition = eImagePosition.Top;
            this.Shape = new RoundRectangleShapeDescriptor(10);
        }
    }
}
