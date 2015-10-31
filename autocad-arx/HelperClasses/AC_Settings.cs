using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using AutoCad_ARX;

namespace AutoCad_ARX
{
    public class AC_Settings
    {
        //PRICATES
        private AC_Transactions tr;

        public AC_Settings()
        {
            tr = new AC_Transactions();
        }

        public void Dispose()
        {
            tr.AC_Tr.Commit();
            tr.AC_Tr.Dispose();
        }

        public DimStyleTableRecord get_DimStyle(OpenMode mode)
        {
            tr.start_Transaction();
            return (DimStyleTableRecord)tr.AC_Tr.GetObject(tr.AC_Db.Dimstyle, mode);
        }
    }
}
