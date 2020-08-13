using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Global
    {

        #region ---- Member variables ----
        private static string _AppPath = string.Empty;


        #endregion
        #region ---- Properties ----

        
        public static string AppPath
        {
            get
            {
                if (string.IsNullOrEmpty(_AppPath))
                {
                    _AppPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                return _AppPath;
            }
        }

        public static bool IsLoginBySupperAdmin
        {
            get;
            set;
        }
        #endregion
    }
}