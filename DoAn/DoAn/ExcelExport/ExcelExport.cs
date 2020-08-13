using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using BLL;
using DoAn;

namespace GUI
{
    public class ExcelExport
    {

        #region ---- Constants ----

        private const int ROW_MAXIMUM = 200;
        private const int COL_MAXIMUM = 256;

        private const string FONT_NAME = "Arial";
        private const int HEADER_FONT_SIZE = 16;
        private const int SUBHEADER_FONT_SIZE = 13;
        private const int CAPTION_FONT_SIZE = 10;
        private const int CONTENT_FONT_SIZE = 10;

        #endregion

        #region ---- Member variables ----

        private IWorkbook _workBook;

        #endregion

        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelExport"/> class.
        /// </summary>
        public ExcelExport()
        {

        }

        #endregion

        #region ---- Private methods ----

        private void WriteColumHeader(IWorksheet xlsSheet, int startRow, int startCol, string[] arrColName, int[] arrColWidth, int rowHeight)
        {
            for (int i = 0; i < arrColName.Length; i++)
            {
                xlsSheet.Range[startRow, startCol + i].Text = arrColName[i];
                xlsSheet.Range[startRow, startCol + i].ColumnWidth = arrColWidth[i];
            }

            xlsSheet.Range[startRow, 1].RowHeight = rowHeight;
            CellStyle(xlsSheet, startRow, startCol, startRow, startCol + arrColName.Length, FONT_NAME, CAPTION_FONT_SIZE, true, false);
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].VerticalAlignment = ExcelVAlign.VAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].WrapText = true;
        }

        /// <summary>
        /// Draws the table border.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="lineStyle">The line style.</param>
        /// <Author>LONG LY</Author>
        /// <Date>25/07/2011</Date>
        private void DrawTableBorder(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelLineStyle lineStyle)
        {
            xlsSheet.IsGridLinesVisible = false;

            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.LineStyle = lineStyle;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.ColorRGB = Color.Black;

            xlsSheet.Range[startRow, startCol, endRow, endCol].WrapText = true;
        }

        #region ---- Format -----

        /// <summary>
        /// Colses the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="HAlight">The H alight.</param>
        private void ColsAlighment(IWorksheet xlsSheet, int[] cols, ExcelHAlign HAlight)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                ColAlighment(xlsSheet, cols[i], HAlight);
            }
        }

        /// <summary>
        /// Cols the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="col">The start col.</param>
        /// <param name="HAlight">The H alight.</param>
        private void ColAlighment(IWorksheet xlsSheet, int col, ExcelHAlign HAlight)
        {
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
        }

        /// <summary>
        /// Cells the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="HAlight">The H alight.</param>
        /// <param name="VAlight">The V alight.</param>
        private void CellAlighment(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelHAlign HAlight, ExcelVAlign VAlight)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.VerticalAlignment = VAlight;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Bold = isBold;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Italic = isItalic;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelKnownColors color)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Color = color;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, string fontName, int fontSize, bool isBold, bool isItalic)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.FontName = fontName;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Size = fontSize;
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
        }

        /// <summary>
        /// Cells the style back ground.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        private void CellStyleBackGround(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.ColorIndex = ExcelKnownColors.Grey_25_percent;
        }

        #endregion ---- Format -----

        /// <summary>
        /// Pages the setup.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="PageOrientation">The page orientation.</param>
        /// <param name="isSmall">if set to <c>true</c> [is small].</param>
        private void PageSetup(IWorksheet xlsSheet, ExcelPageOrientation PageOrientation, bool isSmall)
        {
            // Setting the file name in the Footer
            xlsSheet.PageSetup.RightFooter = "&P";
            // Setting Page Number
            xlsSheet.PageSetup.AutoFirstPageNumber = false;
            xlsSheet.PageSetup.FirstPageNumber = 1;
            // Setting Page Margins
            xlsSheet.PageSetup.TopMargin = 0.35;
            xlsSheet.PageSetup.BottomMargin = 0.5;
            xlsSheet.PageSetup.LeftMargin = 0.35;
            xlsSheet.PageSetup.RightMargin = 0.2;

            xlsSheet.PageSetup.HeaderMargin = 0.3;
            xlsSheet.PageSetup.FooterMargin = 0.5;
            // Setting the Paper Type
            if (isSmall)
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA5;
            }
            else
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA4;
            }

            // Setting the Page Orientation as Portrait or Landscape
            xlsSheet.PageSetup.Orientation = PageOrientation;
        }

        /// <summary>
        /// Saves the excel.
        /// </summary>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        /// <returns></returns>
        private string SaveExcel(ExcelEngine xslEngine, bool isPrint, string defaultName = "", bool usingStyle = false)
        {
            string result = string.Empty;

            try
            {
                if (isPrint)
                {
                    result = Path.GetTempFileName() + ".xls";
                    _workBook.SaveAs(result);
                }
                else
                {
                    string extension = "xsl";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Files(*.xls)|*.xls";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.DefaultExt = "." + extension;
                    saveFileDialog.FileName = defaultName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
                    {
                        _workBook.Version = (ExcelVersion.Excel97to2003);
                        _workBook.SaveAs(saveFileDialog.FileName);
                        if (MessageBox.Show("Mở file vừa xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = saveFileDialog.FileName;

                            result = saveFileDialog.FileName;

                            proc.Start();
                        }
                    }
                }

                _workBook.Close();
            }
            catch
            { }
            finally
            {
                xslEngine.Dispose();
            }

            return result;
        }

        #endregion

        #region ---- Export Excel Template ----

        #region ---- Constants ----

        #region ---- Name Template ----

        // Tuyển dụng
        public const string T_KeHoachTuyenDung = "KeHoachTD";
        // Khai báo trùng với tên đặt trong file cần điền dữ liệu ra
        public const string T_BieuMau = "BieuMau";
        public const string T_DanhSachNCC = "DanhSachNCC";
        public const string T_DanhSachThuongHieu = "DanhSachThuongHieu";
        public const string T_DanhSachNhomKH = "DSNhomKH";
        public const string T_DSChucVu = "DSNhomCV";
        public const string T_DSNhanVien = "DanhSachNhanVien";
        public const string T_DSSanPham = "DSSanPham";
        public const string T_PhieuNhap = "PhieuNhapHang";
        public const string T_DSNhomHH = "DSNhomHH";
        public const string T_DSKhachHang = "KhachHang";
        #endregion

        #region ---- Variables ----

        // Utility                        
        private const string TMP_SHEET = "TMP";
        private const string TMP_ROW = "[TMP]";

        private const string V_PHONGBAN = "%PhongBan";
        private const string V_QUY = "%Quy";
        private const string V_NAM = "%Nam";

        private const string V_TONGSO = "%TongSo";
        private const string V_NGAYTHANGANAM = "%NgayThangNam";
        private const string V_NGAY = "%Ngay";
        private const string V_THANG = "%Thang";
        //private const string V_NAM = "%Nam";

        // ke Hoach thu viec
        private const string V_HOTEN = "%HoTen";
        private const string V_CHUCVU = "%ChucVu";
        private const string V_NGAYTHUVIEC = "%NgayThuViec";
        private const string V_NGUOIQUANLY = "%NguoiQuanLy";
        private const string V_QUANLYCV = "%QuanLyCV";
        private const string V_THUVIECDENNGAY = "%ThuViecDenNgay";


        // Phieu yeu cau
        private const string V_NOIDUNGYEUCAU = "%NoiDungYeuCau";
        private const string V_TENCHUCDANH = "%TenChucDanh";
        private const string V_SOLUONG = "%SoLuong";
        private const string V_TRINHDO = "%TenTrinhDo";
        private const string V_SOLUONGNAM = "%SoLuongNam";
        private const string V_TUOITU = "%TuoiTu";
        private const string V_CHUYENNGANH = "%TenChuyenNganh";
        private const string V_KINHNGHIEMLAMVIEC = "%SoNamKinhNghiem";
        private const string V_NGAYCANNHANSU = "%NgayCanNhanSu";
        private const string V_LYDO = "%TenLyDo";
        private const string V_NGOAINGU = "%TenNgoaiNgu";
        private const string V_TINHOC = "%TenTrinhDoTinHoc";
        private const string V_YEUCAUCANTHIET = "%YeuCauCanThiet";
        private const string V_YEUCAUSUCKHOE = "%YeuCauSucKhoe";
        private const string V_TINHTRANGHONNHAN = "%TenTinhTrangHonNhan";
        private const string V_YEUCAUKHAC = "%YeuCauKhac";
        private const string V_GHICHU = "%GhiChu";

        //Danh sách sinh viên
        private const string V_TENSV = "%TenSV";
        private const string V_NGAYSINH = "%NgaySinh";
        private const string V_MALOP = "%MaLop";



        #endregion

        #endregion

        #region ---- Private methods ----

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="pIsPrint">if set to <c>true</c> [p is print].</param>
        /// <returns></returns>
        private string SaveFile(bool pIsPrint = true)
        {
            string result = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Constants.FILTER_EXCEL;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

            if (!pIsPrint && saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                result = saveFileDialog.FileName;
            }

            return result;
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="pPathFile">The p path file.</param>
        public void OpenFile(string pPathFile)
        {
            if (string.IsNullOrEmpty(pPathFile))
            {
                return;
            }

            if (MessageBox.Show("Bạn muốn mở file", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = pPathFile;
                proc.Start();
            }
        }

        /// <summary>
        /// Replace the specified value in work sheet.
        /// </summary>
        /// <param name="workSheet">The work sheet.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="replaceValue">The replace value.</param>
        private static void Replace(IWorksheet workSheet, string findValue, string replaceValue)
        {
            // Find and replace
            if (workSheet != null && !string.IsNullOrEmpty(findValue))
            {
                // Get current cells
                IRange[] cells = workSheet.Range.Cells;
                IRange range = null;

                // Loop cells to replace
                for (int i = 0; i < cells.Count(); i++)
                {
                    // Current cell
                    range = cells[i];

                    // Find and replace values
                    if (range != null && range.DisplayText.Contains(findValue))
                    {
                        range.Text = range.Text.Replace(findValue, replaceValue);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the excel.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void PrintExcel(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            try
            {
                wb = excelApp.Workbooks.Open(fileName);

                if (wb != null)
                {
                    // Show print preview
                    excelApp.Visible = true;
                    wb.PrintPreview(true);
                }
            }
            catch (Exception ex)
            {
                //ShowMessage
            }
            finally
            {
                // Cleanup:
                GC.Collect();
                GC.WaitForPendingFinalizers();

                wb.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(wb);

                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
            }
        }

        /// <summary>
        /// Builds the replacer current date.
        /// </summary>
        /// <param name="pReplacer">The p replacer.</param>
        private void BuildReplacerCurrentDate_Khoa(ref Dictionary<string, string> pReplacer)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;

                pReplacer.Add("%NgayThangNam", ngay);
                pReplacer.Add("%TongSo", "100");
            }
        }

        private void BuildReplacerCurrentDate(ref Dictionary<string, string> pReplacer)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = DateTime.Now;
                pReplacer.Add("%Ngay", currentDate.Day.ToString());
                pReplacer.Add("%Thang", currentDate.Month.ToString());
                pReplacer.Add("%Nam", currentDate.Year.ToString());
            }
        }

        /// <summary>
        /// Outs the simple report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool OutSimpleReport<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Fill variables
            markProcessor.AddVariable(viewName, dataSource);



            // End template
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            // Delete temporary row
            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            // Delete
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            fileName = file;

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        /// <summary>
        /// Outs the group report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="groupData">The group data.</param>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="groupBox">The group box.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        private bool OutGroupReport<T>(List<IGrouping<int, T>> groupData, Dictionary<string, string> replaceValues,
                                        string groupBox, string viewName, bool isPrintPreview, ref string fileName, string groupName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<int, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                    //markProcess.AddVariable(groupName,CacheData.GetTenChucDanh(group.Key));
                    //  Replace(workSheet, groupName, CacheData.GetTenChucDanh(group.Key));
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
                }
                else
                {
                    markProcess.AddVariable(groupName, string.Empty);
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            //// Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }


            fileName = Path.GetTempFileName() + Constants.FILE_EXT_XLS;


            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(fileName))
            {
                workBook.SaveAs(fileName);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
                File.Delete(fileName);
            }

            return result;
        }

        /// <summary>
        /// Export the List of Type
        /// </summary>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool OutReport<T>(List<IGrouping<string, T>> groupData, Dictionary<string, string> replaceValues,
                                    string groupBox, string viewName, bool isPrintPreview, string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<string, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers();
                }
                else
                {
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            // Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }

            // Get file name
            if (isPrintPreview)
            {
                file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;
            }
            else
            {
                file = fileName;
            }

            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        /// <summary>
        /// Gets the template stream.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns></returns>
        private MemoryStream GetTemplateStream(string viewName)
        {
            MemoryStream stream = null;
            byte[] arrByte = new byte[0];

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMPLATES))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMPLATES);
            }
            //Declare path App/Templates/Excels
            //   string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH; //+ Constants.FOLDER_EXCELS + Constants.CHAR_FLASH;
            // Get template by view name
            switch (viewName)
            {
                #region ---- Lấy file report----
                case T_BieuMau:
                    arrByte = File.ReadAllBytes("BieuMau.xls").ToArray();
                    break;
                case T_DanhSachThuongHieu:
                    arrByte = File.ReadAllBytes("DanhSachThuongHieu.xls").ToArray();
                    break;
                case T_DanhSachNCC:
                    arrByte = File.ReadAllBytes("DanhSachNCC.xls").ToArray();
                    break;
                case T_DSChucVu:
                    arrByte = File.ReadAllBytes("DSNhomCV.xls").ToArray();
                    break;
                case T_DanhSachNhomKH:
                    arrByte = File.ReadAllBytes("DSNhomKH.xls").ToArray();
                    break;
                case T_DSNhanVien:
                    arrByte = File.ReadAllBytes("DanhSachNhanVien.xls").ToArray();
                    break;
                case T_DSSanPham:
                    arrByte = File.ReadAllBytes("DSSanPham.xls").ToArray();
                    break;
                case T_PhieuNhap:
                    arrByte = File.ReadAllBytes("PhieuNhapHang.xls").ToArray();
                    break;
                case T_DSNhomHH:
                    arrByte = File.ReadAllBytes("DSNhomHH.xls").ToArray();
                    break;
                case T_DSKhachHang:
                    arrByte = File.ReadAllBytes("KhachHang.xls").ToArray();
                    break;
                    #endregion
            }
            // Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }

            return stream;
        }

        /// <summary>
        /// Replaces the data work sheet.
        /// </summary>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool ReplaceDataWorkSheet(Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }


            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            fileName = file;

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }
        #endregion


        public bool ExportNhaCungCap(List<NHA_CUNG_CAP> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DanhSachNCC", isPrintPreview, ref fileName);
        }

        public bool ExportThuongHieu(List<THUONG_HIEU> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DanhSachThuongHieu", isPrintPreview, ref fileName);
        }

        public bool ExportNhomKH(List<NhomKhachHang> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DSNhomKH", isPrintPreview, ref fileName);
        }

        public bool ExportChucVu(List<BLL_DAL.CHUC_VU> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
                //List<NHAN_VIEN> list = new List<NHAN_VIEN>();
                //foreach (NHAN_VIEN item in new NhanVienBLL().GetNhanVienTheoChucVu(dataSource[i - 1].MaCV))
                //{
                //    NHAN_VIEN nv = new NHAN_VIEN();
                //    nv.TenNV = item.TenNV;
                //    list.Add(nv);
                //}
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DSNhomCV", isPrintPreview, ref fileName);
        }

        public bool ExportNhanVien(List<NHAN_VIEN> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DanhSachNhanVien", isPrintPreview, ref fileName);
        }

        public bool ExportSanPham(List<SAN_PHAM> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            string tongSL = dataSource.Sum(t => t.SoLuong).Value.ToString();
            string tongGV = dataSource.Sum(t => t.SoLuong * t.GiaVon).Value.ToString();
            string tongGB = dataSource.Sum(t => t.SoLuong * t.GiaBan).Value.ToString();

            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add("%TongSL", tongSL);
            replacer.Add("%TongGiaVon", string.Format("{0:0,0} VNĐ", tongGV));
            replacer.Add("%TongGiaBan", string.Format("{0:0,0} VNĐ", tongGB));
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DSSanPham", isPrintPreview, ref fileName);
        }

        public bool ExportPhieuNhap(List<CHI_TIET_PHIEU_NHAP> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            string tongSL = dataSource.Sum(t => t.SoLuong).Value.ToString();
            string tongTien = dataSource.Sum(t => t.SoLuong * t.GiaNhap).Value.ToString();
            //string tongGB = dataSource.Sum(t => t.SoLuong * t.GiaBan).Value.ToString();

            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add("%TongSL", tongSL);
            replacer.Add("%TongThanhToan", tongTien);
            //replacer.Add("%TongGiaBan", string.Format("{0:0,0} VNĐ", tongGB));
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "PhieuNhapHang", isPrintPreview, ref fileName);
        }

        public bool ExportNhomHangHoa(List<THE_LOAI_SAN_PHAM> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "DSNhomHH", isPrintPreview, ref fileName);
        }

        public bool ExportKhachHang(List<KHACH_HANG> dataSource, ref string fileName, bool isPrintPreview)
        {
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            BuildReplacerCurrentDate(ref replacer);
            return OutSimpleReport(dataSource, replacer, "KhachHang", isPrintPreview, ref fileName);
        }
        #endregion
    }
}
