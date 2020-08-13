using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Constants
    {
        public const string DATE_PATTERN = "dd/MM/yyyy";

        public const string CHAR_DATE_SEPARATOR = "/";
        public const string CHAR_FLASH = @"\";
        public const string CHAR_COMMA = ",";
        public const string CHAR_STAR = "*";

        public const string FILE_OFFICE_97_2003 = "Office Word 97-2003";
        public const string FILE_Excel_97_2003 = "Office Excel 97-2003";
        public const string FILE_OFFICE_2007 = "Office Word 2007";
        public const string FILE_Excel_2007 = "Office _Excel 2007";
        public const string FILE_HELP = "TaiLieuHuongDan.pdf";

        public const string COLUMN_TRACKINGSTATE = "TrackingState";

        public const string administrator = "administrator";

        #region ---- Format ----

        public const string FORMAT_NUMBER = "{0:0,0.0}";
        public const string VN_UNIT = "đồng";

        #endregion

        #region ---- Template Files ----




        public const string FILE_NORMAL_DOT = "Template.dot";
        public const string FILE_GBTT_DOC = "GBTT.doc";
        public const string FILE_GCNTN_DOC = "GCNTN.doc";
        public const string FILE_TEMPLATE_STUDENT_CARD = "StudentCard.png";

        #region ---- Excel Files ----

        public const string FILE_KEHOACHTD = "BM01";
        public const string FILE_PHIEUYEUCAU = "BM02";
        public const string FILE_THONGBAOTUYENDUNG = "BM03";
        public const string FILE_DANHSACHUNGVIENDAU = "BM05";
        public const string FILE_DANHSACHNHANVIEN = "BM06";
        public const string FILE_CHUONGTRINHTHUVIEC = "BM04";


        public const string FILE_BANGLUONG = "BM17";
        public const string FILE_PHIEULUONG = "BM18";


        #endregion



        public const string FILE_HinhAnh = "FileHinhAnh.doc";

        #endregion

        #region ---- Folder name ----

        public const string FOLDER_TEMP = "Temp";
        public const string FOLDER_TEMPLATES = "Templates";
        public const string FOLDER_SQL_UPDATEDB = "SqlUpdateDB";
        public const string FOLDER_EXCELS = "Excels";

        #endregion

        #region ---- File Extendtion ----

        public const string FILE_EXT_DOC = ".doc";
        public const string FILE_EXT_DOCS = ".docx";
        public const string FILE_EXT_XLS = ".xls";
        public const string FILE_EXT_XLSs = ".xlsx";

        #endregion

        #region ---- File Fillter ----

        public const string FILLTER_WORD_FILE = ".Doc|*.doc|.Docx|*.docx";
        public const string FILLTER_WORD_2003_FILE = ".Doc|*.doc";
        public const string FILLTER_WORD_2007_FILE = ".Docx|*.docx";
        public const string FILLTER_WORD_EXCEL = ".Doc|*.doc|.Docx|*.docx|.xls|*.xls|.xlsx|*.xlsx";
        public const string FILTER_EXCEL = "Files(*.xls)|*.xls";
        public const string FILTER_EXCEL2007 = "Files(*.xlsx)|*.xlsx";

        #endregion
    }
}