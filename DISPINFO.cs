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
        int i;
        AC_Transactions tr;
        [CommandMethod("DISPINFO")]
        public void DispInformations()
        {
            i = 0;
            ln = new AC_Line(new Point3d(0, 10, 0), new Point3d(10, 10, 0));
            ln.Thickness = 10;
            ObjectId id1 = ln.ObjectId;
            tr = new AC_Transactions();
            ObjectId id = ln.addToDrawing();
            //ObjectId id = tr.addObject(ln.toLine());
            id1 = ln.ObjectId;

            Line line1 = (Line)ln;
            tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;
        }

        private void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
        {
            ln.EndPoint = e.Context.ComputedPoint;
            ln.Extend(20+i);
            if (i < 500)
            {
                ln.Visible = false;
            }
            else
            {
                ln.Visible = true;

            }
            //tr.AC_Doc.Editor.WriteMessage("\n" + ln.BlockName.ToString());
            i++;
        }

    }
}
