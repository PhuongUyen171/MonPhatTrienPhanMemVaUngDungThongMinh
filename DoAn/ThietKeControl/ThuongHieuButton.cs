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
    public partial class ThuongHieuButton : ButtonX
    {
        public ThuongHieuButton()
        {
            InitializeComponent();
            this.Size = new Size(150,180);
            this.ColorTable = eButtonColor.Orange;
            this.Image = Image.FromFile(Application.StartupPath + "\\Resource\\KoXacDinh.jpg");
            this.ImagePosition = eImagePosition.Top;
            this.Shape = new RoundRectangleShapeDescriptor(10);
        }

        public ThuongHieuButton(string hinh)
        {
            InitializeComponent();
            this.Size = new Size(150,180);
            this.ColorTable = eButtonColor.Orange;
            this.Image = Image.FromFile(Application.StartupPath + "\\Resource\\"+hinh);
            this.ImagePosition = eImagePosition.Top;
            this.Shape = new RoundRectangleShapeDescriptor(10);
        }
    }
}
