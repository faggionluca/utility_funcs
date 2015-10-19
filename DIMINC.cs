using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using reg = System.Text.RegularExpressions;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using AutoCad_ARX;

namespace Utility_funcs
{
    public class IncrementalQuotes
    {
        public class DimInc_Init : Autodesk.AutoCAD.Runtime.IExtensionApplication
        {
            private DocumentCollection DocColl;
            private AC_Transactions tr;
            private DimInc_Modified DimMod;

            public void Initialize()
            {
                tr = new AC_Transactions();
                DocColl = Application.DocumentManager;
                DocColl.DocumentCreated += DocColl_DocumentCreated;

                if (tr.AC_Doc != null){ findandLink(); }
            }

            void DocColl_DocumentCreated(object sender, DocumentCollectionEventArgs e)
            {
                tr.AC_Doc = Application.DocumentManager.MdiActiveDocument;
                findandLink();
            }

            public void findandLink()
            {
                ObjectIdCollection Lines = getAllObjectsWithDic("DIMINC_LINE");

                foreach (ObjectId id in Lines)
                {
                    DimMod = new DimInc_Modified();
                    Transaction trans = tr.start_Transaction();
                    DBObject dbObj = trans.GetObject(id, OpenMode.ForRead) as DBObject;
                    ObjectId dic = dbObj.ExtensionDictionary;
                    DBDictionary dbDic = (DBDictionary)trans.GetObject(dic, OpenMode.ForRead);
                    string tag = "";
                    Xrecord xRec = (Xrecord)tr.AC_Tr.GetObject(dbDic.GetAt("DIMINC_LINE"), OpenMode.ForRead, false);
                    foreach (TypedValue tv in xRec)
                    {
                        tag = tv.Value.ToString();
                    }
                    ObjectId texts = getGroupWithTag(tag);

                    //LINK WITH THE MOD CLASS
                    DimMod.Add_Events(id, texts);
                    trans.Commit();
                    trans.Dispose();
                }


            }

            public ObjectId getGroupWithTag(string tag)
            {
                Transaction trans = tr.start_Transaction();
                DBDictionary gd = tr.openGroupDictionary(OpenMode.ForRead);
                if(gd.Contains(tag))
                {
                    trans.Commit();
                    trans.Dispose();
                    return gd.GetAt(tag);
                }
                else
                {
                    trans.Commit();
                    trans.Dispose();
                    return ObjectId.Null;
                }
            }

            public ObjectIdCollection getAllObjectsWithDic(string searchPath)
            {
                ObjectIdCollection objs = new ObjectIdCollection(); 
                Transaction trans = tr.start_Transaction();
                tr.AC_Db = tr.AC_Doc.Database;
                tr.openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
                foreach (ObjectId id in tr.AC_blockTableRecord)
                {
                    DBObject dbObj = trans.GetObject(id, OpenMode.ForRead) as DBObject;
                    ObjectId dic = dbObj.ExtensionDictionary;
                    if (dic != ObjectId.Null)
                    {
                        DBDictionary dbDic = (DBDictionary)trans.GetObject(dic, OpenMode.ForRead);
                        if (dbDic.Contains(searchPath))
                        {
                            objs.Add(id);
                        }
                    }
                }
                tr.Dispose();
                return objs;
            }

            public void Terminate()
            {
            }
        }

        [CommandMethod("DIMINC")]
        public void incremental_quotes()
        {
            DimInc_Create DimInc = new DimInc_Create();
            DimInc.newDIMinc();
        }

        private class DimInc_Create
        {
            public AC_Transactions tr;
            public DimInc_Preview preview;
            public AC_Math acMath;
            public DIM_Settings DIMset;
            public List<Point3d> Points;
            public DimInc_Modified DimIncMod;

            public ObjectId DIMline;
            public ObjectIdCollection DIMtexts;
            public PromptPointResult CurrPoint;
            public int index;
            public string GUID;

            public DimInc_Create()
            {
                //INIT TRANSACTION CLASS
                tr = new AC_Transactions();
                //INIT SETTINGS
                DIMset = new DIM_Settings();
                //INIT PREVIEW CLASS
                preview = new DimInc_Preview(tr, DIMset);
                //INIT MOD CLASS
                DimIncMod = new DimInc_Modified();
                //INIT UTILITY_MATH
                acMath = new AC_Math();
                //INIT POINTS AND TEXT ARRAY
                Points = new List<Point3d>();
                DIMtexts = new ObjectIdCollection();
                GUID = Guid.NewGuid().ToString();
            }

            public DimInc_Create(bool softInit)
            {
                if (softInit)
                {
                    //INIT TRANSACTION CLASS
                    tr = new AC_Transactions();
                    //INIT SETTINGS
                    DIMset = new DIM_Settings();
                    //INIT UTILITY_MATH
                    acMath = new AC_Math();
                }
                else
                {
                    //INIT TRANSACTION CLASS
                    tr = new AC_Transactions();
                    //INIT SETTINGS
                    DIMset = new DIM_Settings();
                    //INIT PREVIEW CLASS
                    preview = new DimInc_Preview(tr, DIMset);
                    //INIT MOD CLASS
                    DimIncMod = new DimInc_Modified();
                    //INIT UTILITY_MATH
                    acMath = new AC_Math();
                    //INIT POINTS AND TEXT ARRAY
                    Points = new List<Point3d>();
                    DIMtexts = new ObjectIdCollection();
                    GUID = Guid.NewGuid().ToString();
                }
            }

            public void newDIMinc()
            {
                start_DIMline();
                index = 1;
                while (true)
                {
                    if (!askforPoint()) { break; }
                    update_DIMline(index);
                    if (!create_DIMtxt(index)) { break; };
                    index++;
                }
                ObjectOverrule.RemoveOverrule(RXObject.GetClass(typeof(Entity)), preview._osOverrule);
                ObjectId textsGroup = createTextGroup(DIMtexts);

                AddExtensionDictionary(DIMline);

                DimIncMod.Add_Events(DIMline, textsGroup);
            }

            public bool askforPoint()
            {
                CurrPoint = tr.AC_Doc.Editor.GetPoint("Pick a Point");
                Points.Add(CurrPoint.Value);
                preview.update_PreviewLine(CurrPoint.Value, acMath.totalDistance(Points, DIMset.DimUnit_Precision));

                if (CurrPoint.Status == PromptStatus.Cancel)
                {
                    preview.endDraw_PreviewLine();
                    return false;
                }

                return true;
            }

            public void start_DIMline()
            {
                CurrPoint = tr.AC_Doc.Editor.GetPoint("Pick a Point");
                preview.beginDraw_PreviewLine(CurrPoint.Value);

                Points.Add(CurrPoint.Value);

                Polyline PLine = new Polyline();
                PLine.AddVertexAt(0, new Point2d(CurrPoint.Value.X, CurrPoint.Value.Y), 0, 0, 0);
                DIMline = tr.addObject(PLine);
            }

            public void update_DIMline(int i)
            {
                Polyline pLine = tr.openObject(DIMline, OpenMode.ForWrite) as Polyline;
                if (CurrPoint.Value == pLine.GetPoint3dAt(0))
                {
                    pLine.Closed = true;
                }
                else
                {
                    pLine.AddVertexAt(i, new Point2d(CurrPoint.Value.X, CurrPoint.Value.Y), 0, 0, 0);
                }
                tr.closeObject();
            }

            public bool create_DIMtxt(int i)
            {
                //GET POLYLINE
                Polyline pline = tr.openObject(DIMline, OpenMode.ForRead) as Polyline;
                tr.closeObject();

                ////QUOTE TEXT
                ObjectId tId; // TEXT ID
                DBText acText = new DBText();
                acText.Justify = AttachmentPoint.BaseCenter;
                acText.Height = DIMset.Dimtxt_Height;
                acText.TextString = acMath.totalDistance(Points, DIMset.DimUnit_Precision).ToString();
                acText.Rotation = acMath.RetriveRot(Points[Points.Count - 2], Points[Points.Count - 1]);


                double dist = CurrPoint.Value.DistanceTo(pline.GetPoint3dAt(0));
                if (dist < 0.001)
                {
                    acText.AlignmentPoint = acMath.pointOffset(pline.GetPoint3dAt(i - 1), pline.GetPoint3dAt(0), DIMset.Dimtxt_Offset)[1];
                    preview.endDraw_PreviewLine();
                    tId = tr.addObject(acText);
                    DIMtexts.Add(tId);
                    return false;
                }
                else
                {
                    acText.AlignmentPoint = acMath.pointOffset(pline.GetPoint3dAt(i), pline.GetPoint3dAt(i - 1), -DIMset.Dimtxt_Offset)[1];
                }
                tId = tr.addObject(acText);
                DIMtexts.Add(tId);
                return true;
            }

            public ObjectId createTextGroup(ObjectIdCollection texts)
            {
                DBObjectCollection DbTexts = new DBObjectCollection();
                foreach (ObjectId txt in texts)
                {
                    DBText text = tr.openObject(txt, OpenMode.ForWrite) as DBText;
                    text.Erase(true);

                    DBText nTxt = new DBText();
                    nTxt.Justify = text.Justify;
                    nTxt.Height = text.Height;
                    nTxt.TextString = text.TextString;
                    nTxt.Rotation = text.Rotation;
                    nTxt.AlignmentPoint = text.AlignmentPoint;
                    tr.closeObject();
                    DbTexts.Add(nTxt);
                }
                return tr.addGroup(GUID, DbTexts,false);
            }

            public void AddExtensionDictionary(ObjectId obj)
            {
                DBObject dbObj = tr.openObject(obj, OpenMode.ForRead) as DBObject;

                ObjectId dicObj = dbObj.ExtensionDictionary;

                if (dicObj == ObjectId.Null)
                {
                    dbObj.UpgradeOpen();
                    dbObj.CreateExtensionDictionary();
                    dicObj = dbObj.ExtensionDictionary;
                }

                tr.closeObject();
                tr.start_Transaction();
                DBDictionary dbDic = tr.AC_Tr.GetObject(dicObj,OpenMode.ForRead) as DBDictionary;

                if (!dbDic.Contains("DIMINC_LINE"))
                {
                    dbDic.UpgradeOpen();
                    Xrecord xr = new Xrecord();
                    ResultBuffer rb = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataAsciiString,GUID));
                    xr.Data = rb;
                    dbDic.SetAt("DIMINC_LINE", xr);
                    tr.AC_Tr.AddNewlyCreatedDBObject(xr, true);
                }
                tr.AC_Tr.Commit();
                tr.AC_Tr.Dispose();
            }
        }

        private class DimInc_Modified
        {
            private ObjectId DimInc_Mod;
            private ObjectId DimInc_Modtexts;
            public AC_Transactions tr;
            private gripPointModified gripMod;
            private bool needOverrule = true;

            public DimInc_Modified()
            {
                tr = new AC_Transactions();
            }

            public void Add_Events(ObjectId DimInc,ObjectId DimTexts)
            {
                DimInc_Mod = DimInc;
                DimInc_Modtexts = DimTexts;
                tr.AC_Doc.Editor.SelectionAdded += Editor_SelectionAdded;
                tr.AC_Doc.Editor.SelectionRemoved += Editor_SelectionRemoved;

                gripMod = new gripPointModified(DimInc, DimTexts);
            }

            private void Editor_SelectionRemoved(object sender, SelectionRemovedEventArgs e)
            {
                foreach (ObjectId id in e.RemovedObjects.GetObjectIds())
                {
                    if (id == DimInc_Mod && needOverrule)
                    {
                        tr.AC_Doc.Editor.PromptedForPoint -= gripMod.Editor_PromptedForPoint;
                        tr.AC_Doc.Editor.DraggingEnded -= gripMod.Editor_DraggingEnded;
                        needOverrule = true;
                        ObjectOverrule.RemoveOverrule(RXClass.GetClass(typeof(Entity)), gripMod);
                    }
                }
            }

            void Editor_SelectionAdded(object sender, SelectionAddedEventArgs e)
            {
                foreach (ObjectId id in e.AddedObjects.GetObjectIds())
                {
                    if (id == DimInc_Mod && needOverrule)
                    {
                        needOverrule = false;
                        ObjectOverrule.AddOverrule(RXClass.GetClass(typeof(Entity)), gripMod, true);
                    }
                }
            }

            public class gripPointModified : GripOverrule
            {
                private ObjectId DimInc_pLine;
                private ObjectId DimInc_texts;
                private AC_Transactions tr;
                private DIM_Settings DIMset;
                private AC_Math acMath;
                private Point3d CurrPoint;
                private int? Gripindex = null;
                private List<int?> GripIndexs;
                List<Point3d> midPoints;
                private bool done;
                private bool needRefresh;

                public gripPointModified(ObjectId DimInc, ObjectId DimTexts)
                {
                    DimInc_pLine = DimInc;
                    DimInc_texts = DimTexts;
                    tr = new AC_Transactions();
                    DIMset = new DIM_Settings();
                    acMath = new AC_Math();

                    GripIndexs = new List<int?>();
                    GripIndexs.Add(null);
                    GripIndexs.Add(null);

                    calculateMidPoints();

                    ObjectId[] ids;
                    ids = new ObjectId[1] { DimInc_pLine };
                    SetIdFilter(ids);
                    tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;
                    Application.DocumentManager.DocumentDestroyed += DocumentManager_DocumentDestroyed;
                }

                void DocumentManager_DocumentDestroyed(object sender, DocumentDestroyedEventArgs e)
                {
                    ObjectOverrule.RemoveOverrule(RXClass.GetClass(typeof(Entity)), this);
                }

                public override void MoveGripPointsAt(Entity entity, IntegerCollection indices, Vector3d offset)
                {
                    base.MoveGripPointsAt(entity, indices, offset);
                    tr.AC_Doc.Editor.PromptedForPoint += Editor_PromptedForPoint;
                    tr.AC_Doc.Editor.DraggingEnded += Editor_DraggingEnded;

                    if (Gripindex != null || GripIndexs[0] != null && GripIndexs[1] != null)
                    {
                        Polyline pLine = tr.openObject(DimInc_pLine, OpenMode.ForWrite) as Polyline;
                        Point3dCollection points = new Point3dCollection();
                        for (int i = 0; i < pLine.NumberOfVertices; i++)
                        {
                            if (i == Gripindex)
                            {
                                points.Add(CurrPoint);
                                continue;
                            }
                            else if (i == GripIndexs[0] || i == GripIndexs[1])
                            {
                                points.Add(acMath.getPointAtVector(pLine.GetPoint3dAt(i),offset));
                                continue;
                            }
                            else
                            {
                                points.Add(pLine.GetPoint3dAt(i));
                            }
                        }
                        tr.closeObject();

                        Group Texts = tr.openGroup(DimInc_texts, OpenMode.ForWrite);
                        ObjectId[] ids = Texts.GetAllEntityIds();
                        tr.closeGroup();

                        int index = 0;
                        foreach (ObjectId id in ids)
                        {

                            DBText txt = tr.openObject(id, OpenMode.ForWrite) as DBText;
                            if (index != points.Count - 1)
                            {
                                txt.TextString = acMath.totalDistance(points, DIMset.DimUnit_Precision, index).ToString();
                                txt.Rotation = acMath.RetriveRot(points[index], points[index + 1]);
                                txt.AlignmentPoint = acMath.pointOffset(points[index],points[index + 1],DIMset.Dimtxt_Offset)[1];
                            }
                            else
                            {
                                txt.TextString = acMath.totalDistance(points, DIMset.DimUnit_Precision, index).ToString();
                                txt.Rotation = acMath.RetriveRot(points[index], points[0]);
                                txt.AlignmentPoint = acMath.pointOffset(points[index], points[0], DIMset.Dimtxt_Offset)[1];
                            }
                            tr.closeObject();
                            index++;
                        }

                        needRefresh = true;
                    }

                }

                public void Editor_DraggingEnded(object sender, DraggingEndedEventArgs e)
                {
                    done = false;
                    GripIndexs[0] = null;
                    GripIndexs[1] = null;
                    Gripindex = null;
                    if (needRefresh) { tr.AC_Doc.Editor.Regen(); }
                    needRefresh = false;
                }

                void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
                {
                    CurrPoint = e.Context.ComputedPoint;
                }

                public void Editor_PromptedForPoint(object sender, PromptPointResultEventArgs e)
                {
                    if (!done)
                    {
                        calculateMidPoints();
                        Polyline pLine = tr.openObject(DimInc_pLine, OpenMode.ForRead) as Polyline;
                        if (pLine != null)
                        {
                            populateGripIndex(pLine);
                            populateGripIndexs(pLine);
                        }
                        tr.closeObject();
                    }
                }

                private void populateGripIndex(Polyline pLine)
                {
                    for (int i = 0; i < pLine.NumberOfVertices; i++)
                    {
                        if (pLine.GetPoint3dAt(i) == CurrPoint)
                        {
                            Gripindex = i;
                            done = true;
                        }
                    }
                }

                private void populateGripIndexs(Polyline pLine)
                {
                    for (int i = 0; i < midPoints.Count; i++)
                    {
                        if (midPoints.ElementAt(i) == CurrPoint)
                        {
                            if (pLine.Closed)
                            {
                                if (midPoints.Count == i)
                                {
                                    GripIndexs[0] = 0;
                                    GripIndexs[1] = i;
                                    done = true;
                                }
                                else
                                {
                                    GripIndexs[0] = i;
                                    GripIndexs[1] = i + 1;
                                    done = true;
                                }
                            }
                            else
                            {
                                GripIndexs[0] = i;
                                GripIndexs[1] = i + 1;
                                done = true;
                            }
                        }
                    }
                }

                private void calculateMidPoints()
                {
                    midPoints = new List<Point3d>();
                    Polyline pLine = tr.openObject(DimInc_pLine, OpenMode.ForRead) as Polyline;
                    if (pLine != null)
                    {
                        for (int i = 0; i < pLine.NumberOfVertices; i++)
                        {
                            if (pLine.Closed)
                            {
                                if (i == pLine.NumberOfVertices - 1)
                                {
                                    midPoints.Add(new LineSegment3d(pLine.GetPoint3dAt(i), pLine.GetPoint3dAt(0)).MidPoint);
                                }
                                else
                                {
                                    midPoints.Add(new LineSegment3d(pLine.GetPoint3dAt(i), pLine.GetPoint3dAt(i + 1)).MidPoint);
                                }
                            }
                            else
                            {
                                if (i != pLine.NumberOfVertices - 1)
                                {
                                    midPoints.Add(new LineSegment3d(pLine.GetPoint3dAt(i), pLine.GetPoint3dAt(i + 1)).MidPoint);
                                }
                            }
                        }
                        tr.closeObject();
                    }
                }

            }
        }

        private class DimInc_Preview
        {
            //PRIVATES
            private AC_Transactions tr;
            private DIM_Settings DIMset;
            private AC_Math acMath;
            public ObjectId PrevLine;
            public ObjectId PrevText;
            private double lenght;
            public OsSnappOver _osOverrule;

            //PUBLIC
            public bool drawline { get; set; }

            public DimInc_Preview(AC_Transactions AC_tr,DIM_Settings set)
            {
                tr = AC_tr;
                DIMset = set;
                acMath = new AC_Math();
                tr.AC_Doc.Editor.PointMonitor += Editor_PointMonitor;

            }

            public void beginDraw_PreviewLine(Point3d point)
            {
                //CREATE LINE
                drawline = true;
                Line line = new Line(point, point);
                PrevLine = tr.addObject(line);

                DBText acText = new DBText();
                PrevText = tr.addObject(acText);

                _osOverrule = new OsSnappOver(PrevLine);
                ObjectOverrule.AddOverrule(RXObject.GetClass(typeof(Entity)), _osOverrule, false);
            }

            public void update_PreviewLine(Point3d Startpoint,double currLenght)
            {
                Line line = tr.openObject(PrevLine, OpenMode.ForWrite) as Line;
                line.StartPoint = Startpoint;
                tr.closeObject();
                lenght = currLenght;
            }

            public void endDraw_PreviewLine()
            {
                drawline = false;
                Line line = tr.openObject(PrevLine, OpenMode.ForWrite) as Line;
                line.Erase(true);
                tr.closeObject();
                DBText text = tr.openObject(PrevText, OpenMode.ForWrite) as DBText;
                text.Erase(true);
                tr.closeObject();
                tr.AC_Doc.Editor.Regen();

            }

            public void reDraw_PreviewLine(Point3d endPoint)
            {
                //LINE
                Line line = tr.openObject(PrevLine, OpenMode.ForWrite) as Line;
                line.EndPoint = endPoint;
                tr.closeObject();

                //TEXT
                DBText text = tr.openObject(PrevText, OpenMode.ForWrite) as DBText;
                text.TextString = Math.Round(lenght + line.Length, DIMset.DimUnit_Precision).ToString();
                text.Rotation = acMath.RetriveRot(line.StartPoint, endPoint);
                text.Justify = AttachmentPoint.BaseCenter;
                text.Height = DIMset.Dimtxt_Height;
                if (line.Length < 1)
                {
                    text.AlignmentPoint = new LineSegment3d(line.StartPoint, endPoint).MidPoint;
                }
                else
                {
                    text.AlignmentPoint = acMath.pointOffset(line.StartPoint,line.EndPoint,DIMset.Dimtxt_Offset)[1];
                }
                tr.closeObject();

            }

            //EVENT HANDLER
            private void Editor_PointMonitor(object sender, PointMonitorEventArgs e)
            {
                Point3d Currpoint = e.Context.ComputedPoint;
                if (drawline)
                {
                    reDraw_PreviewLine(Currpoint);
                }
            }

            public class OsSnappOver : OsnapOverrule
            {
                public OsSnappOver(ObjectId PrevLineID)
                {
                    ObjectId[] ids;
                    ids = new ObjectId[1] { PrevLineID };
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

    }
}
