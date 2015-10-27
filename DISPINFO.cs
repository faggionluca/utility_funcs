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
            ObjectId id = ln.addToDrawing();
            //ObjectId id = tr.addObject(ln.toLine());
            id1 = ln.ObjectId;
            tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;
        }

        private void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
        {
            ln.EndPoint = e.Context.ComputedPoint;
            //ln.Extend(20);
            tr.AC_Doc.Editor.WriteMessage("\n" + ln.Area.ToString());
        }

    }
}
