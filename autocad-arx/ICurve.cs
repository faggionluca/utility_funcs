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
    public interface ICurve
    {
        //ICURVE
        bool isInstanced();

        //CURVE PROPRIETIES
        double Area { get; }
        bool Closed { get; }
        double EndParam { get; }
        Point3d EndPoint { get; set; }
        bool IsPeriodic { get; }
        Spline Spline { get; }
        double StartParam { get; }
        Point3d StartPoint { get; set; }

        //CURVE METHODS
        double GetDistAtPoint(Point3d point);
    }

    public class AC_Curve : Curve, ICurve
    {
        public AC_Transactions tr;
        public new ObjectId ObjectId { get; set; }
        public Curve BaseCurve;

        public AC_Curve(IntPtr unmanagedObjPtr, bool autoDelete) : base(unmanagedObjPtr, autoDelete)
        {
            tr = new AC_Transactions();
        }

        protected override void Dispose(bool A_1)
        {
            GC.SuppressFinalize(this);
        }

        public static AC_Curve fromOpenObject(Entity ent)
        {
            AC_Curve ac_cv = new AC_Curve(ent.UnmanagedObject,ent.AutoDelete);
            return ac_cv;
        }

        public bool isInstanced()
        {
            tr.AC_Doc.LockDocument();
            this.BaseCurve = tr.openObject(this.ObjectId, OpenMode.ForWrite) as Curve;
            if (this.BaseCurve != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //CURVE PROPRIETIES
        public new double Area
        {
            get 
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.Area;
                }
                else
                {
                    return base.Area;
                }
            } 
        }

        public new bool Closed 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.Closed;
                }
                else
                {
                    return base.Closed;
                }
            } 
        }

        public new double EndParam 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.EndParam;
                }
                else
                {
                    return base.EndParam;
                }
            } 
        }

        public new Point3d EndPoint 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.EndPoint;
                }
                else
                {
                    return base.EndPoint;
                }
            }
            set
            {
                if (isInstanced())
                {
                    BaseCurve.EndPoint = value;
                    tr.Dispose();
                }
                else
                {
                   base.EndPoint = value;
                }
            }
        }

        public new bool IsPeriodic 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.IsPeriodic;
                }
                else
                {
                    return base.IsPeriodic;
                }
            }
        }

        public new Spline Spline 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.Spline;
                }
                else
                {
                    return base.Spline;
                }
            }
        }

        public new double StartParam 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.StartParam;
                }
                else
                {
                    return base.StartParam;
                }
            }
        }

        public new Point3d StartPoint 
        {
            get
            {
                if (isInstanced())
                {
                    tr.Dispose();
                    return BaseCurve.StartPoint;
                }
                else
                {
                    return base.StartPoint;
                }
            }
            set
            {
                if (isInstanced())
                {
                    BaseCurve.StartPoint = value;
                    tr.Dispose();
                }
                else
                {
                    base.StartPoint = value;
                }
            }
        }

        //INTERFACE METHODS
        public new double GetDistAtPoint(Point3d point)
        {
            if (isInstanced())
            {
                double DistAtPoint = base.GetDistAtPoint(point);
                tr.Dispose();
                return DistAtPoint;
            }
            else
            {
                return base.GetDistAtPoint(point);
            }
        }
    }

}
