using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAn
{
    public partial class rptThongKeBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptThongKeBanHang()
        {
            InitializeComponent();
            xrLabel9.Text = "Ngày lập: "+DateTime.Today.ToShortDateString();
        }

    }
}
