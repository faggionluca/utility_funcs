using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using AutoCad_ARX;

namespace Utility_funcs
{
    public class DIM_Settings
    {
        private AC_Transactions tr;
        private AC_Settings Settings;
        public DimStyleTableRecord Dimstyle { get; set; }

        //TABLE RECORDS
        //TEXT
        public double Dimtxt_Offset
        {
            get
            {
                refresh_DimStyle();
                return Dimstyle.Dimgap;
            }
            set
            {
                Dimstyle = Settings.get_DimStyle(OpenMode.ForWrite);
                Dimstyle.Dimgap = value;
                Settings.Dispose();
            }
        }

        public double Dimtxt_Height
        {
            get
            {
                refresh_DimStyle();
                return Dimstyle.Dimtxt;
            }
            set
            {
                Dimstyle = Settings.get_DimStyle(OpenMode.ForWrite);
                Dimstyle.Dimtxt = value;
                Settings.Dispose();
            }
        }

        //UNIT
        public int DimUnit_Precision
        {
            get
            {
                refresh_DimStyle();
                return Dimstyle.Dimdec;
            }
            set
            {
                Dimstyle = Settings.get_DimStyle(OpenMode.ForWrite);
                Dimstyle.Dimdec = value;
                Settings.Dispose();
            }
        }

        public DIM_Settings()
        {
            tr = new AC_Transactions();
            Settings = new AC_Settings();
            Dimstyle = Settings.get_DimStyle(OpenMode.ForRead);
            Settings.Dispose();
        }

        private void refresh_DimStyle()
        {
            Dimstyle = Settings.get_DimStyle(OpenMode.ForRead);
            Settings.Dispose();
        }
    }
}
