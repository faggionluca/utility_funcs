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
        AC_DBText text;
        [CommandMethod("DISPINFO")]
        public void DispInformations()
        {
            i = 0;
            tr = new AC_Transactions();

            ln = new AC_Line(new Point3d(0, 0, 0), new Point3d(10, 10, 0));
            ln.Thickness = 10;
            ObjectId id = ln.addToDrawing();

            DBObject line1 = (DBObject)ln;
        }

        [CommandMethod("DISPINFO_1")]
        public void DispInformations1()
        {
            tr = new AC_Transactions();
            Line line = new Line(new Point3d(20, 0, 0), new Point3d(10, 10, 0));
            AC_Line ln = (AC_Line)line;
            ln.addToDrawing();
        }

        [CommandMethod("DISPINFO_2")]
        public void DispInformations2()
        {
            tr = new AC_Transactions();
            AC_Polyline poly = new AC_Polyline();
            poly.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
            poly.AddVertexAt(1, new Point2d(20, 20), 0, 0, 0);
            poly.AddVertexAt(2, new Point2d(0, 30), 0, 0, 0);
            poly.addToDrawing();

            text = new AC_DBText();
            text.TextString = "Ciao";
            text.Position = new Point3d(0, 0, 0);
            text.addToDrawing();

            tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;
        }

        void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
        {
            text.Position = e.Context.ComputedPoint;
        }
    }
}
