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
    public class AC_Curve : Curve
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

        public void createInstance()
        {
            tr.AC_Doc.LockDocument();
            this.BaseCurve = tr.openObject(this.ObjectId, OpenMode.ForWrite) as Curve;
        }

        public bool isInstanced()
        {
            if (this.ObjectId != ObjectId.Null)
            {
                this.tr.AC_Doc.LockDocument();
                this.BaseCurve = this.tr.openObject(base.ObjectId, OpenMode.ForWrite) as Line;
                if (this.BaseCurve != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public ObjectId addToDrawing()
        {
            this.ObjectId = tr.addObject(BaseCurve);
            return this.ObjectId;
        }

        //CURVE PROPRIETIES
        public new double Area
        {
            get 
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Area;
            } 
        }

        public new bool Closed 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Closed;
            } 
        }

        public new double EndParam 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.EndParam;
            } 
        }

        public override Point3d EndPoint 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.EndPoint;
            }
            set
            {       
                createInstance();
                BaseCurve.EndPoint = value;
                tr.Dispose();
            }
        }

        public new bool IsPeriodic 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.IsPeriodic;
            }
        }

        public new Spline Spline 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Spline;
            }
        }

        public new double StartParam 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.StartParam;
            }
        }

        public override Point3d StartPoint 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.StartPoint;
            }
            set
            {
                createInstance();
                BaseCurve.StartPoint = value;
                tr.Dispose();
            }
        }

        public override void Extend(double newParameter)
        {
            createInstance();
            BaseCurve.Extend(newParameter);
            tr.Dispose();
        }

        public override void Extend(bool extendStart, Point3d toPoint)
        {
            createInstance();
            BaseCurve.Extend(extendStart, toPoint);
            tr.Dispose();
        }

        public override Point3d GetClosestPointTo(Point3d givenPoint, bool extend)
        {
            createInstance();
            Point3d GetClosestPoint = BaseCurve.GetClosestPointTo(givenPoint, extend);
            tr.Dispose();
            return GetClosestPoint;
        }

        public override Point3d GetClosestPointTo(Point3d givenPoint, Vector3d direction, bool extend)
        {
            createInstance();
            Point3d GetClosestPoint = BaseCurve.GetClosestPointTo(givenPoint, direction, extend);
            tr.Dispose();
            return GetClosestPoint;
        }

        public override double GetDistanceAtParameter(double value)
        {
            createInstance();
            double GetDistanceAtPar = BaseCurve.GetDistanceAtParameter(value);
            tr.Dispose();
            return GetDistanceAtPar;
        }

        public override double GetDistAtPoint(Point3d point)
        {
            createInstance();
            double DistAtPoint = BaseCurve.GetDistAtPoint(point);
            tr.Dispose();
            return DistAtPoint;
        }

        public override Vector3d GetFirstDerivative(double value)
        {
            createInstance();
            Vector3d GetFirstDer = BaseCurve.GetFirstDerivative(value);
            tr.Dispose();
            return GetFirstDer;
        }

        public override Vector3d GetFirstDerivative(Point3d point)
        {
            createInstance();
            Vector3d GetFirstDer = BaseCurve.GetFirstDerivative(point);
            tr.Dispose();
            return GetFirstDer;
        }

        public new Curve3d GetGeCurve()
        {
            createInstance();
            Curve3d GetGeCur = BaseCurve.GetGeCurve();
            tr.Dispose();
            return GetGeCur;
        }

        public new Curve3d GetGeCurve(Tolerance tolerance)
        {
            createInstance();
            Curve3d GetGeCur = BaseCurve.GetGeCurve(tolerance);
            tr.Dispose();
            return GetGeCur;
        }

        public override DBObjectCollection GetOffsetCurves(double offsetDist)
        {
            createInstance();
            DBObjectCollection GetOffset = BaseCurve.GetOffsetCurves(offsetDist);
            tr.Dispose();
            return GetOffset;
        }

        public override DBObjectCollection GetOffsetCurvesGivenPlaneNormal(Vector3d normal, double offsetDist)
        {
            createInstance();
            DBObjectCollection GetOffset = BaseCurve.GetOffsetCurvesGivenPlaneNormal(normal,offsetDist);
            tr.Dispose();
            return GetOffset;
        }



    }

}
