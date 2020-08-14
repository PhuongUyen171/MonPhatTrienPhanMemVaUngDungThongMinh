using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace DoAn
{
    public partial class frm_DanhSachTraHangBan : DevExpress.XtraEditors.XtraForm
    {
        BLL_DAL_ThongKe a = new BLL_DAL_ThongKe();
        public frm_DanhSachTraHangBan()
        {
            InitializeComponent();
        }

        private void frm_DanhSachTraHangBan_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = a.loadPhieuTra();
            DateTime now = DateTime.Now;
            dateEdit2.EditValue = now.ToShortDateString();
            dateEdit1.EditValue = layNgayDauThang();
        }
        public DateTime layNgayDauThang()
        {
            string text = DateTime.Now.ToString("dd/MM/yyyy");
            string str = text.Substring(3, 2);
            return DateTime.ParseExact("01/" + str + "/" + DateTime.Now.Year.ToString(), "dd/MM/yyyy", null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = a.timKiemPhieutraHangTheoKhoan(Convert.ToDateTime(dateEdit1.EditValue.ToString()), Convert.ToDateTime(dateEdit2.EditValue.ToString()));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            rptThongKeTraHang aa = new rptThongKeTraHang();
            aa.DataSource = gridControl1.DataSource;
            ReportPrintTool tool = new ReportPrintTool(aa);
            tool.ShowPreview();
        }

        private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
           // GridView view = sender as GridView;
           //// var value = view.GetRowCellValue(e.RowHandle, colMaPTB);
           // var value2 = a.xemThongPhieuTra((string)value);

          //  if (value2 != null)
           // {
             //   e.ChildList = value2;
           // }
        }

        private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            //e.RelationCount = 1;
        }

        private void gridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            //e.RelationName = "Chi tiết";
        }
    }
}