using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.Geometry;
using AutoCad_ARX;

namespace Utility_funcs
{
    public class CreateTriangulations
    {
        [CommandMethod("TRIANGULATE")]
        public void BeginTriangulate()
        {
            buildTriangulations buildT = new buildTriangulations();
            AC_Transactions tr = new AC_Transactions();
            PromptEntityOptions options = new PromptEntityOptions("Pick a Line to Triangulate");
            options.SetRejectMessage("not valid Object \n");
            options.AddAllowedClass(typeof(Line), true);
            PromptEntityResult sel = tr.AC_Doc.Editor.GetEntity(options);
            if (sel.Status == PromptStatus.OK)
            {
                tr.AC_Doc.Editor.WriteMessage("Line " + sel.ObjectId.ToString() + " Selected \n");
                buildT.Create((AC_Line)tr.openObjectErased(sel.ObjectId));
            }
        }

        [CommandMethod("HIDETRIANGULATE")]
        public void HideTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            PromptEntityOptions options = new PromptEntityOptions("Pick a Line to Hide Triangulations");
            options.SetRejectMessage("not valid Object \n");
            options.AddAllowedClass(typeof(Line), true);
            PromptEntityResult sel = tr.AC_Doc.Editor.GetEntity(options);
            if (sel.Status == PromptStatus.OK)
            {
                triangulation.Hide((AC_Line)tr.openObjectErased(sel.ObjectId));
            }

        }

        [CommandMethod("REMOVETRIANGULATE")]
        public void RemoveTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            PromptEntityOptions options = new PromptEntityOptions("Pick a Line to remove Triangulations");
            options.SetRejectMessage("not valid Object \n");
            options.AddAllowedClass(typeof(Line), true);
            PromptEntityResult sel = tr.AC_Doc.Editor.GetEntity(options);
            if (sel.Status == PromptStatus.OK)
            {
                triangulation.Remove((AC_Line)tr.openObjectErased(sel.ObjectId));
            }

        }

        [CommandMethod("SHOWTRIANGULATE")]
        public void ShowTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            PromptEntityOptions options = new PromptEntityOptions("Pick a Line to show Triangulations");
            options.SetRejectMessage("not valid Object \n");
            options.AddAllowedClass(typeof(Line), true);
            PromptEntityResult sel = tr.AC_Doc.Editor.GetEntity(options);
            if (sel.Status == PromptStatus.OK)
            {
                triangulation.Show((AC_Line)tr.openObjectErased(sel.ObjectId));
            }
        }

        [CommandMethod("MODIFYTRIANGULATE")]
        public void ModifyTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            PromptEntityOptions options = new PromptEntityOptions("Pick a Line to modify Triangulations");
            options.SetRejectMessage("not valid Object \n");
            options.AddAllowedClass(typeof(Line), true);
            PromptEntityResult sel = tr.AC_Doc.Editor.GetEntity(options);
            if (sel.Status == PromptStatus.OK)
            {
                triangulation.Modify((AC_Line)tr.openObjectErased(sel.ObjectId));
            }
        }

        [CommandMethod("SHOWALLTRIANGULATE")]
        public void ShowAllTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            Transaction trans = tr.start_Transaction();
            tr.openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
            foreach (ObjectId id in tr.AC_blockTableRecord)
            {
                try
                {
                    AC_Entity ent = (AC_Entity)tr.openObjectErased(id);
                    if (ent.BaseEntity is Line)
                    {
                        AC_Line line = (AC_Line)ent;
                        ResultBuffer rb = line.XData;
                        if (rb != null)
                        {
                            //FIND XDATA GUID
                            int index = 0;
                            string guid = null;
                            foreach (TypedValue tv in rb)
                            {
                                if (index == 3)
                                {
                                    guid = tv.Value.ToString();
                                }
                                index++;
                            }

                            if (guid != null)
                            {
                                triangulation.Show(line);
                            }
                        }
                    }
                    tr.Dispose(trans);
                }
                catch
                {
                    tr.AC_Doc.Editor.WriteMessage("Skipped a not Entity Object");
                }
            }
        }

        [CommandMethod("HIDEALLTRIANGULATE")]
        public void HideAllTriangulate()
        {
            Triangulations triangulation = new Triangulations();
            AC_Transactions tr = new AC_Transactions();
            Transaction trans = tr.start_Transaction();
            tr.openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
            foreach (ObjectId id in tr.AC_blockTableRecord)
            {
                try{
                    AC_Entity ent = (AC_Entity)tr.openObjectErased(id);
                    if (ent.BaseEntity is Line)
                    {
                        AC_Line line = (AC_Line)ent;
                        ResultBuffer rb = line.XData;
                        if (rb != null)
                        {
                            //FIND XDATA GUID
                            int index = 0;
                            string guid = null;
                            foreach (TypedValue tv in rb)
                            {
                                if (index == 3)
                                {
                                    guid = tv.Value.ToString();
                                }
                                index++;
                            }

                            if (guid != null)
                            {
                                triangulation.Hide(line);
                            }
                        }
                    }
                    tr.Dispose(trans);
                }
                catch
                {
                    tr.AC_Doc.Editor.WriteMessage("Skipped a not Entity Object");
                }
            }
        }

        private class buildTriangulations
        {
            bool drawPreviewCircle;
            Point3d circleCenter;
            AC_Transactions tr;
            AC_Circle previewCircle;
            public List<double> radius;

            public buildTriangulations()
            {
                //INIT
                tr = new AC_Transactions();
                radius = new List<double>();

                //EVENT
                tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;
            }

            public void Create(AC_Line line)
            {
                if (line.XData == null)
                {
                    if (askForDistances(line))
                    {
                        tr.start_Transaction();
                        RegAppTable rat = (RegAppTable)tr.AC_Tr.GetObject(tr.AC_Db.RegAppTableId,OpenMode.ForRead,false);
                        if (!rat.Has("TRIANGULATE"))
                        {
                            rat.UpgradeOpen();
                            RegAppTableRecord ratr = new RegAppTableRecord();
                            ratr.Name = "TRIANGULATE";
                            rat.Add(ratr);
                            tr.AC_Tr.AddNewlyCreatedDBObject(ratr, true);
                        }
                        tr.AC_Tr.Commit();
                        tr.AC_Tr.Dispose();

                        ResultBuffer rb = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataRegAppName, "TRIANGULATE"), new TypedValue((int)DxfCode.ExtendedDataAsciiString, radius[0].ToString()), new TypedValue((int)DxfCode.ExtendedDataAsciiString, radius[1].ToString()), new TypedValue((int)DxfCode.ExtendedDataAsciiString, Guid.NewGuid().ToString()));
                        line.XData = rb;

                        Triangulations triang = new Triangulations();
                        triang.Show(line);
                    }
                }
                else
                {
                    tr.AC_Doc.Editor.WriteMessage("This line is alredy triangulated \n");
                }
            }

            public bool askForDistances(AC_Line acline)
            {
                circleCenter = acline.StartPoint;
                previewCircle = new AC_Circle();
                previewCircle.addToDrawing();
                removeSnap noSnap = new removeSnap(previewCircle.ObjectId);
                ObjectOverrule.AddOverrule(RXObject.GetClass(typeof(Entity)), noSnap, true);

                drawPreviewCircle = true;
                PromptDistanceOptions DistOption = new PromptDistanceOptions("Triangulation Distance");
                DistOption.BasePoint = circleCenter;
                DistOption.UseBasePoint = true;

                PromptDoubleResult triang1 = tr.AC_Doc.Editor.GetDistance(DistOption);
                if (triang1.Status == PromptStatus.OK)
                {
                    if (triang1.Value != 0)
                    {
                        tr.AC_Doc.Editor.WriteMessage(triang1.Value.ToString() + "\n");
                        circleCenter = acline.EndPoint;
                        DistOption.BasePoint = circleCenter;
                        radius.Add(triang1.Value);
                        PromptDoubleResult triang2 = tr.AC_Doc.Editor.GetDistance(DistOption);
                        if (triang2.Status == PromptStatus.OK)
                        {
                            tr.AC_Doc.Editor.WriteMessage(triang2.Value.ToString() + "\n");
                            radius.Add(triang2.Value);
                            previewCircle.Visible = false;
                            drawPreviewCircle = false;
                            return true;
                        }
                        else
                        {
                            tr.AC_Doc.Editor.PointMonitor -= Editor_PointMonitor;
                            ObjectOverrule.RemoveOverrule(RXObject.GetClass(typeof(Entity)), noSnap);
                            previewCircle.Erase(true);
                            return false;
                        }
                    }
                    else
                    {
                        tr.AC_Doc.Editor.PointMonitor -= Editor_PointMonitor;
                        tr.AC_Doc.Editor.WriteMessage("Cannot Calculate Triangulation \n");
                        ObjectOverrule.RemoveOverrule(RXObject.GetClass(typeof(Entity)), noSnap);
                        previewCircle.Erase(true);
                        return false;
                    }
                }
                else
                {
                    tr.AC_Doc.Editor.PointMonitor -= Editor_PointMonitor;
                    ObjectOverrule.RemoveOverrule(RXObject.GetClass(typeof(Entity)), noSnap);
                    previewCircle.Visible = false;
                    drawPreviewCircle = false;
                    return false;
                }


            }

            void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
            {
                if (drawPreviewCircle)
                {
                    previewCircle.Center = circleCenter;
                    if (circleCenter.DistanceTo(e.Context.ComputedPoint) != 0)
                    {
                        previewCircle.Visible = true;
                        previewCircle.Radius = circleCenter.DistanceTo(e.Context.ComputedPoint);
                    }
                    else
                    {
                        previewCircle.Visible = false;
                    }
                }
            }

            public class removeSnap : OsnapOverrule
            {
                public removeSnap(ObjectId Id)
                {
                    ObjectId[] ids = { Id };
                    SetIdFilter(ids);
                }

                public override void GetObjectSnapPoints(Entity ent, ObjectSnapModes mode, IntPtr gsm, Point3d pick, Point3d last, Matrix3d view, Point3dCollection snap, IntegerCollection geomIds)
                {
                }

                public override void GetObjectSnapPoints(Entity ent, ObjectSnapModes mode, IntPtr gsm, Point3d pick, Point3d last, Matrix3d view, Point3dCollection snaps, IntegerCollection geomIds, Matrix3d insertion)
                {
                }

                public override bool IsContentSnappable(Entity entity)
                {
                    return false;
                }
            }
        }

        private class Triangulations
        {
            AC_Transactions tr;
            List<double> BaseRadius;

            public Triangulations()
            {
                //INIT ADD EVENTS
                tr = new AC_Transactions();
            }

            public void Show(AC_Line line)
            {
                ResultBuffer rb = line.XData;
                if (rb == null)
                {
                    tr.AC_Doc.Editor.WriteMessage("This Line doesn't have triangulations \n");
                }
                else
                {
                    GetRadiusList(rb);
                    if (BaseRadius != null)
                    {
                        createObjects(line);
                    }
                }
            }

            public bool Hide(AC_Line line)
            {
                ResultBuffer rb = line.XData;
                if (rb == null)
                {
                    tr.AC_Doc.Editor.WriteMessage("This Line doesn't have triangulations \n");
                    return false;
                }
                else
                {
                    //FIND XDATA GUID
                    int index = 0;
                    string guid = "";
                    foreach (TypedValue tv in rb)
                    {
                        if (index == 3)
                        {
                            guid = tv.Value.ToString();
                        }
                        index++;
                    }
                    removeObjects(guid);
                    return true;
                }
            }

            public bool Remove(AC_Line line)
            {
                if (Hide(line))
                {
                    line.XData = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataRegAppName, "TRIANGULATE"));
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public void Modify(AC_Line line)
            {
                if (Remove(line))
                {
                    buildTriangulations build = new buildTriangulations();
                    if (build.askForDistances(line))
                    {
                        ResultBuffer rb = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataRegAppName, "TRIANGULATE"), new TypedValue((int)DxfCode.ExtendedDataAsciiString, build.radius[0].ToString()), new TypedValue((int)DxfCode.ExtendedDataAsciiString, build.radius[1].ToString()), new TypedValue((int)DxfCode.ExtendedDataAsciiString, Guid.NewGuid().ToString()));
                        line.XData = rb;
                        Show(line);
                    }
                }
            }

            private void GetRadiusList(ResultBuffer rb)
            {
                BaseRadius = new List<double>();
                int n = 0;
                foreach (TypedValue tv in rb)
                {
                    if (tv.Value.ToString() == "TRIANGULATE")
                    {
                        foreach (TypedValue intv in rb)
                        {
                            if (n == 0)
                            {
                                n++;
                                continue;
                            }
                            else if(n <= 2)
                            {
                                BaseRadius.Add(Convert.ToDouble(intv.Value));
                                n++;
                            }
                        }
                        break;
                    }
                    else
                    {
                        tr.AC_Doc.Editor.WriteMessage("This Line doesn't have triangulations \n");
                    }
                    break;
                }
            }

            private void createObjects(AC_Line line)
            {
                AC_Circle t1 = new AC_Circle();
                AC_Circle t2 = new AC_Circle();
                AC_Polyline p = new AC_Polyline();
                t1.Center = line.StartPoint;
                t2.Center = line.EndPoint;
                t1.Radius = BaseRadius[0];
                t2.Radius = BaseRadius[1];
                t1.addToDrawing();
                t2.addToDrawing();
                p.addToDrawing();

                //APPLY COLORS
                applyLineStyle((AC_Entity)p, Color.FromRgb(255, 51, 51), "ACAD_ISO02W100",3);
                applyLineStyle((AC_Entity)t1, Color.FromRgb(255, 135, 51), "ACAD_ISO03W100",1);
                applyLineStyle((AC_Entity)t2, Color.FromRgb(255, 135, 51), "ACAD_ISO03W100",1);

                //COPY XDATA GUID
                int index = 0;
                string guid = "";
                foreach (TypedValue tv in line.XData as ResultBuffer)
                {
                    if(index == 3){
                        guid = tv.Value.ToString();
                    }
                    index++;
                }

                ResultBuffer rb = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataRegAppName, "TRIANGULATE"), new TypedValue((int)DxfCode.ExtendedDataAsciiString, guid));
                t1.XData = rb;
                t2.XData = rb;
                p.XData = rb;

                Point3dCollection pts = new Point3dCollection();
                t1.IntersectWith((Circle)t2, Intersect.OnBothOperands, pts, IntPtr.Zero, IntPtr.Zero);

                if (pts.Count == 0)
                {
                    tr.AC_Doc.Editor.WriteMessage("Cannot Calculate Triangulation \n");
                    t1.Erase(true);
                    t2.Erase(true);
                    p.Erase(true);
                }
                else if (pts.Count == 1)
                {
                    p.AddVertexAt(0, new Point2d(line.StartPoint.X, line.StartPoint.Y), 0, 0, 0);
                    p.AddVertexAt(1, new Point2d(pts[0].X, pts[0].Y), 0, 0, 0);
                    p.AddVertexAt(2, new Point2d(line.EndPoint.X, line.EndPoint.Y), 0, 0, 0);
                }
                else if (pts.Count == 2)
                {
                    p.AddVertexAt(0, new Point2d(line.StartPoint.X, line.StartPoint.Y), 0, 0, 0);
                    p.AddVertexAt(1, new Point2d(pts[0].X, pts[0].Y), 0, 0, 0);
                    p.AddVertexAt(2, new Point2d(line.EndPoint.X, line.EndPoint.Y), 0, 0, 0);
                    p.AddVertexAt(3, new Point2d(pts[1].X, pts[1].Y), 0, 0, 0);
                    p.Closed = true;
                }
            }

            private void removeObjects(string guid)
            {
                List<Entity> entity_list = new List<Entity>();
                tr.start_Transaction();
                tr.openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
                foreach(ObjectId id in tr.AC_blockTableRecord){
                    Entity ent = tr.AC_Tr.GetObject(id, OpenMode.ForWrite) as Entity;
                    if (ent.GetType() != typeof(Line))
                    {
                        if (ent.XData != null)
                        {
                            entity_list.Add(ent);
                        }
                    }
                }
                tr.Dispose();

                foreach (Entity ent in entity_list)
                {
                    string entID = "";
                    int index = 0;
                    foreach (TypedValue tv in ent.XData)
                    {
                        if (index == 1)
                        {
                            entID = tv.Value.ToString();
                        }
                        index++;
                    }
                    if (entID == guid)
                    {
                        Entity eraseEnt = tr.openObject(ent.ObjectId, OpenMode.ForWrite);
                        eraseEnt.Erase(true);
                        tr.closeObject();
                    }

                }
            }

            private void applyLineStyle(AC_Entity ent,Color lineColor,string LineStyle, double scale)
            {
                ent.Color = lineColor;
                tr.start_Transaction();
                LinetypeTable lintable = tr.AC_Tr.GetObject(tr.AC_Db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;
                if (!lintable.Has(LineStyle))
                {
                    tr.AC_Db.LoadLineTypeFile(LineStyle, "acad.lin");
                }
                tr.AC_Tr.Commit();
                tr.AC_Tr.Dispose();
                ent.Linetype = LineStyle;
                ent.LinetypeScale = scale;
            }
        }
    }
}
