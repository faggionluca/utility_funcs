using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;

namespace AutoCad_ARX
{
    public class AC_Polyline : AC_Curve
    {
        protected internal Polyline BasePolyline
        {
            get
            {
                return base.BaseCurve as Polyline;
            }
            set
            {
                base.BaseCurve = value;
            }
        }

        public AC_Polyline() : base()
        {
            this.BasePolyline = new Polyline();
        }
        public AC_Polyline(Polyline polyline) : base()
        {
            this.ObjectId = polyline.ObjectId;
            this.BasePolyline = polyline;
        }
        public AC_Polyline(int vertices) : base()
        {
            this.BasePolyline = new Polyline(vertices);
        }

        public bool Closed
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Closed;
                }
                else
                {
                    return BasePolyline.Closed;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.Closed = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.Closed = value;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double ConstantWidth
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.ConstantWidth;
                }
                else
                {
                    return BasePolyline.ConstantWidth;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.ConstantWidth = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.ConstantWidth = value;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double Elevation 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Elevation;
                }
                else
                {
                    return BasePolyline.Elevation;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.Elevation = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.Elevation = value;
                }
            }
        }
        public bool HasBulges 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.HasBulges;
                }
                else
                {
                    return BasePolyline.HasBulges;
                }
            }
        }
        public bool HasWidth 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.HasWidth;
                }
                else
                {
                    return BasePolyline.HasWidth;
                }
            }
        }
        public bool IsOnlyLines 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.IsOnlyLines;
                }
                else
                {
                    return BasePolyline.IsOnlyLines;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double Length
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Length;
                }
                else
                {
                    return BasePolyline.Length;
                }
            }
        }
        public Vector3d Normal 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Normal;
                }
                else
                {
                    return BasePolyline.Normal;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.Normal = value;
                }
            }
        }
        public int NumberOfVertices 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.NumberOfVertices;
                }
                else
                {
                    return BasePolyline.NumberOfVertices;
                }
            }
        }
        public bool Plinegen 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Plinegen;
                }
                else
                {
                    return BasePolyline.Plinegen;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.Plinegen = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.Plinegen = value;
                }
            }
        }
        [Category("General")]
        [UnitType(UnitType.Distance)]
        public double Thickness 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BasePolyline.Thickness;
                }
                else
                {
                    return BasePolyline.Thickness;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BasePolyline.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    BasePolyline.Thickness = value;
                }
            }
        }

        public void AddVertexAt(int index, Point2d pt, double bulge, double startWidth, double endWidth)
        {
            if (base.isInstanced())
            {
                BasePolyline.AddVertexAt(index, pt, bulge, startWidth, endWidth);
                tr.Dispose();
            }
            else
            {
                BasePolyline.AddVertexAt(index, pt, bulge, startWidth, endWidth);
            }
        }
        public void ConvertFrom(Entity entity, bool transferId)
        {
            if (base.isInstanced())
            {
                BasePolyline.ConvertFrom(entity, transferId);
                tr.Dispose();
            }
            else
            {
                BasePolyline.ConvertFrom(entity, transferId);
            }
        }
        public Polyline2d ConvertTo(bool transferId)
        {
            if (base.isInstanced())
            {
                Polyline2d ConvertTo = BasePolyline.ConvertTo(transferId);
                tr.Dispose();
                return ConvertTo;
            }
            else
            {
                return BasePolyline.ConvertTo(transferId);
            }
        }
        public CircularArc2d GetArcSegment2dAt(int index)
        {
            if (base.isInstanced())
            {
                CircularArc2d GetArcSegment2dAt = BasePolyline.GetArcSegment2dAt(index);
                tr.Dispose();
                return GetArcSegment2dAt;
            }
            else
            {
                return BasePolyline.GetArcSegment2dAt(index);
            }
        }
        public CircularArc3d GetArcSegmentAt(int index)
        {
            if (base.isInstanced())
            {
                CircularArc3d GetArcSegmentAt = BasePolyline.GetArcSegmentAt(index);
                tr.Dispose();
                return GetArcSegmentAt;
            }
            else
            {
                return BasePolyline.GetArcSegmentAt(index);
            }
        }
        public double GetBulgeAt(int index)
        {
            if (base.isInstanced())
            {
                double GetBulgeAt = BasePolyline.GetBulgeAt(index);
                tr.Dispose();
                return GetBulgeAt;
            }
            else
            {
                return BasePolyline.GetBulgeAt(index);
            }
        }
        public double GetEndWidthAt(int index)
        {
            if (base.isInstanced())
            {
                double GetEndWidthAt = BasePolyline.GetEndWidthAt(index);
                tr.Dispose();
                return GetEndWidthAt;
            }
            else
            {
                return BasePolyline.GetEndWidthAt(index);
            }
        }
        public LineSegment2d GetLineSegment2dAt(int index)
        {
            if (base.isInstanced())
            {
                LineSegment2d GetLineSegment2dAt = BasePolyline.GetLineSegment2dAt(index);
                tr.Dispose();
                return GetLineSegment2dAt;
            }
            else
            {
                return BasePolyline.GetLineSegment2dAt(index);
            }
        }
        public LineSegment3d GetLineSegmentAt(int index)
        {
            if (base.isInstanced())
            {
                LineSegment3d GetLineSegmentAt = BasePolyline.GetLineSegmentAt(index);
                tr.Dispose();
                return GetLineSegmentAt;
            }
            else
            {
                return BasePolyline.GetLineSegmentAt(index);
            }
        }
        public Point2d GetPoint2dAt(int index)
        {
            if (base.isInstanced())
            {
                Point2d GetPoint2dAt = BasePolyline.GetPoint2dAt(index);
                tr.Dispose();
                return GetPoint2dAt;
            }
            else
            {
                return BasePolyline.GetPoint2dAt(index);
            }
        }
        public Point3d GetPoint3dAt(int value)
        {
            if (base.isInstanced())
            {
                Point3d GetPoint3dAt = BasePolyline.GetPoint3dAt(value);
                tr.Dispose();
                return GetPoint3dAt;
            }
            else
            {
                return BasePolyline.GetPoint3dAt(value);
            }
        }
        public SegmentType GetSegmentType(int index)
        {
            if (base.isInstanced())
            {
                SegmentType GetSegmentType = BasePolyline.GetSegmentType(index);
                tr.Dispose();
                return GetSegmentType;
            }
            else
            {
                return BasePolyline.GetSegmentType(index);
            }
        }
        public double GetStartWidthAt(int index)
        {
            if (base.isInstanced())
            {
                double GetStartWidthAt = BasePolyline.GetStartWidthAt(index);
                tr.Dispose();
                return GetStartWidthAt;
            }
            else
            {
                return BasePolyline.GetStartWidthAt(index);
            }
        }
        public void MaximizeMemory()
        {
            if (base.isInstanced())
            {
                BasePolyline.MaximizeMemory();
                tr.Dispose();
            }
            else
            {
                BasePolyline.MaximizeMemory();
            }
        }
        public void MinimizeMemory()
        {
            if (base.isInstanced())
            {
                BasePolyline.MinimizeMemory();
                tr.Dispose();
            }
            else
            {
                BasePolyline.MinimizeMemory();
            }
        }
        public virtual bool OnSegmentAt(int index, Point2d pt2d, double value)
        {
            if (base.isInstanced())
            {
                bool OnSegmentAt = BasePolyline.OnSegmentAt(index, pt2d, value);
                tr.Dispose();
                return OnSegmentAt;
            }
            else
            {

                return BasePolyline.OnSegmentAt(index, pt2d, value);
            }
        }
        public void RemoveVertexAt(int index)
        {
            if (base.isInstanced())
            {
                BasePolyline.RemoveVertexAt(index);
                tr.Dispose();
            }
            else
            {
                BasePolyline.RemoveVertexAt(index);
            }
        }
        public void Reset(bool reuse, int vertices)
        {
            if (base.isInstanced())
            {
                BasePolyline.Reset(reuse, vertices);
                tr.Dispose();
            }
            else
            {
                BasePolyline.Reset(reuse, vertices);
            }
        }
        public void SetBulgeAt(int index, double bulge)
        {
            if (base.isInstanced())
            {
                BasePolyline.SetBulgeAt(index, bulge);
                tr.Dispose();
            }
            else
            {
                BasePolyline.SetBulgeAt(index, bulge);
            }
        }
        public void SetEndWidthAt(int index, double endWidth)
        {
            if (base.isInstanced())
            {
                BasePolyline.SetEndWidthAt(index, endWidth);
                tr.Dispose();
            }
            else
            {
                BasePolyline.SetBulgeAt(index, endWidth);
            }
        }
        public void SetPointAt(int index, Point2d pt)
        {
            if (base.isInstanced())
            {
                BasePolyline.SetPointAt(index, pt);
                tr.Dispose();
            }
            else
            {
                BasePolyline.SetPointAt(index, pt);
            }
        }
        public void SetStartWidthAt(int index, double startWidth)
        {
            if (base.isInstanced())
            {
                BasePolyline.SetStartWidthAt(index, startWidth);
                tr.Dispose();
            }
            else
            {
                BasePolyline.SetStartWidthAt(index, startWidth);
            }
        }

        public static explicit operator AC_Polyline(Polyline polyline)
        {
            AC_Transactions tr = new AC_Transactions();
            AC_Polyline pln = new AC_Polyline(polyline);
            return pln;
        }

    }
}
