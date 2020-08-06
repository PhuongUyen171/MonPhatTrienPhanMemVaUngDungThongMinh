using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BLL_DAL;

namespace DoAn
{
    public partial class frmPOS : Office2007Form
    {
        public NHAN_VIEN nv;
        public frmPOS()
        {
            InitializeComponent();
            lbThoiGian.Text = "Thời gian: " + DateTime.Now;
        }
    }
}
