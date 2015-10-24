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
    public class DisplayInformations
    {
        AC_Line ln;
        AC_Transactions tr;
        [CommandMethod("DISPINFO")]
        public void DispInformations()
        {
            ln = new AC_Line(new Point3d(0, 10, 0), new Point3d(10, 10, 0));
            ln.Thickness = 10;
            ObjectId id1 = ln.ObjectId;
            tr = new AC_Transactions();
            ObjectId id = tr.addAC_Line(ln);

            tr.AC_Doc.Editor.PointMonitor +=Editor_PointMonitor;
            //ln.EndPoint = new Point3d(0,0,0);

            AC_Line ln2 = AC_Line.fromOpenObject((Line)tr.openObjectErased(id));
            //////ObjectId id2 = ln2.ObjectId;
            double test = ln2.Thickness;
        }

        private void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
        {
            ln.EndPoint = e.Context.ComputedPoint;
            tr.AC_Doc.Editor.WriteMessage("\n" + ln.GetDistAtPoint(e.Context.ComputedPoint).ToString());
        }

    }
}
