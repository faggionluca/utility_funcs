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

namespace AutoCad_ARX
{
    public class AC_Line : Line,ICurve
    {
        private AC_Transactions tr;
        private AC_Curve ac_curve;

        private Line line;
        public Line subLine
        {
            get
            {
                return line;
            }
        }

        private ObjectId id;
        public new ObjectId ObjectId
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                ac_curve.ObjectId = value;
            }
        }

        public AC_Line() : base()
        {
            tr = new AC_Transactions();
            ac_curve = new AC_Curve(this.UnmanagedObject, this.AutoDelete);
            ac_curve.ObjectId = this.ObjectId;
            line = null;
        }

        public AC_Line(Line inLine)
        {
            tr = new AC_Transactions();
            ac_curve = new AC_Curve(inLine.UnmanagedObject, inLine.AutoDelete);
            ac_curve.ObjectId = inLine.ObjectId;
            this.id = inLine.ObjectId;
            line = inLine;
        }

        public AC_Line(Point3d pointer1, Point3d pointer2) : base(pointer1, pointer2)
        {
            tr = new AC_Transactions();
            ac_curve = new AC_Curve(this.UnmanagedObject, this.AutoDelete);
            ac_curve.ObjectId = this.ObjectId;
            line = null;
        }

        public static AC_Line fromOpenObject(Entity ent)
        {
            AC_Line line = new AC_Line(ent as Line);
            return line;
        }

        public bool isInstanced()
        {
            tr.AC_Doc.LockDocument();
            this.line = tr.openObject(this.id, OpenMode.ForWrite) as Line;
            if (this.line != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //PROPRIETIES LINE//////////////////

        public new double Angle 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return line.Angle;
                }
                else
                {
                    return base.Angle;
                }
            }
        }

        public new Vector3d Delta 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return line.Delta;
                }
                else
                {
                    return base.Delta;
                }
            }
        }

        public new double Length
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return line.Length;
                }
                else
                {
                    return base.Length;
                }
            }
        }

        public new Vector3d Normal
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return line.Normal;
                }
                else
                {
                    return base.Normal;
                }
            }
            set
            {
                if (isInstanced())
                {
                    line.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    base.Normal = value;
                }
            }
        }

        public new double Thickness
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return line.Thickness;
                }
                else
                {
                    return base.Thickness;
                }
            }
            set
            {
                if (isInstanced())
                {
                    line.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    base.Thickness = value;
                }
            }
        }

        //PROPRIETIES CURVE//////////////////
        public override Point3d StartPoint
        {
            get
            {
                return ac_curve.StartPoint;
            }
            set
            {
                ac_curve.StartPoint = value;
            }
        }
        public new Point3d EndPoint 
        {
            get
            {
                return ac_curve.EndPoint;
            }
            set
            {
                ac_curve.EndPoint = value;
            }
        }
        public new double Area { get { return ac_curve.Area; } }
        public new bool Closed { get { return ac_curve.Closed; } }
        public new double EndParam { get { return ac_curve.EndParam; } }
        public new bool IsPeriodic { get { return ac_curve.IsPeriodic; } }
        public new Spline Spline { get { return ac_curve.Spline; } }
        public new double StartParam { get { return ac_curve.StartParam; } }

        //METHODS CURVE//////////////////////
        public new double GetDistAtPoint(Point3d point)
        {
            return ac_curve.GetDistAtPoint(point);
        }
    }
}
