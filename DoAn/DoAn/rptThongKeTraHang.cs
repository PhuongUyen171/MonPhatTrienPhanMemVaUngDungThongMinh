using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DoAn
{
    public partial class rptThongKeTraHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptThongKeTraHang()
        {
            InitializeComponent();
            xrLabel9.Text = "Ngày lập: " + DateTime.Today.ToShortDateString();
        }

    }
}
