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
    public class AC_Curve : AC_Entity
    {
        protected internal Curve BaseCurve
        {
            get
            {
                return base.BaseEntity as Curve;
            }
            set
            {
                base.BaseEntity = value;
            }
        }

        public AC_Curve(IntPtr unmanagedObjPtr, bool autoDelete) : base(unmanagedObjPtr, autoDelete) { }

        //CURVE PROPRIETIES
        public double Area
        {
            get 
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Area;
            } 
        }

        public bool Closed 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Closed;
            } 
        }

        public double EndParam 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.EndParam;
            } 
        }

        public Point3d EndPoint 
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

        public bool IsPeriodic 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.IsPeriodic;
            }
        }

        public Spline Spline 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.Spline;
            }
        }

        public double StartParam 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseCurve.StartParam;
            }
        }

        public Point3d StartPoint 
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


        //METHODS
        public virtual void Extend(double newParameter)
        {
            createInstance();
            BaseCurve.Extend(newParameter);
            tr.Dispose();
        }

        public virtual void Extend(bool extendStart, Point3d toPoint)
        {
            createInstance();
            BaseCurve.Extend(extendStart, toPoint);
            tr.Dispose();
        }

        public virtual Point3d GetClosestPointTo(Point3d givenPoint, bool extend)
        {
            createInstance();
            Point3d GetClosestPoint = BaseCurve.GetClosestPointTo(givenPoint, extend);
            tr.Dispose();
            return GetClosestPoint;
        }

        public virtual Point3d GetClosestPointTo(Point3d givenPoint, Vector3d direction, bool extend)
        {
            createInstance();
            Point3d GetClosestPoint = BaseCurve.GetClosestPointTo(givenPoint, direction, extend);
            tr.Dispose();
            return GetClosestPoint;
        }

        public virtual double GetDistanceAtParameter(double value)
        {
            createInstance();
            double GetDistanceAtPar = BaseCurve.GetDistanceAtParameter(value);
            tr.Dispose();
            return GetDistanceAtPar;
        }

        public virtual double GetDistAtPoint(Point3d point)
        {
            createInstance();
            double DistAtPoint = BaseCurve.GetDistAtPoint(point);
            tr.Dispose();
            return DistAtPoint;
        }

        public virtual Vector3d GetFirstDerivative(double value)
        {
            createInstance();
            Vector3d GetFirstDer = BaseCurve.GetFirstDerivative(value);
            tr.Dispose();
            return GetFirstDer;
        }

        public virtual Vector3d GetFirstDerivative(Point3d point)
        {
            createInstance();
            Vector3d GetFirstDer = BaseCurve.GetFirstDerivative(point);
            tr.Dispose();
            return GetFirstDer;
        }

        public Curve3d GetGeCurve()
        {
            createInstance();
            Curve3d GetGeCur = BaseCurve.GetGeCurve();
            tr.Dispose();
            return GetGeCur;
        }

        public Curve3d GetGeCurve(Tolerance tolerance)
        {
            createInstance();
            Curve3d GetGeCur = BaseCurve.GetGeCurve(tolerance);
            tr.Dispose();
            return GetGeCur;
        }

        public virtual DBObjectCollection GetOffsetCurves(double offsetDist)
        {
            createInstance();
            DBObjectCollection GetOffset = BaseCurve.GetOffsetCurves(offsetDist);
            tr.Dispose();
            return GetOffset;
        }

        public virtual DBObjectCollection GetOffsetCurvesGivenPlaneNormal(Vector3d normal, double offsetDist)
        {
            createInstance();
            DBObjectCollection GetOffset = BaseCurve.GetOffsetCurvesGivenPlaneNormal(normal,offsetDist);
            tr.Dispose();
            return GetOffset;
        }

        public virtual Curve GetOrthoProjectedCurve(Plane planeToProjectOn)
        {
            createInstance();
            Curve GetOrthoProj = BaseCurve.GetOrthoProjectedCurve(planeToProjectOn);
            tr.Dispose();
            return GetOrthoProj;
        }

        public virtual double GetParameterAtDistance(double dist)
        {
            createInstance();
            double GetParameterAtDist = BaseCurve.GetParameterAtDistance(dist);
            tr.Dispose();
            return GetParameterAtDist;
        }

        public virtual double GetParameterAtPoint(Point3d point)
        {
            createInstance();
            double GetParameterAtP = BaseCurve.GetParameterAtPoint(point);
            tr.Dispose();
            return GetParameterAtP;
        }

        public virtual Point3d GetPointAtDist(double value)
        {
            createInstance();
            Point3d GetPointAtD = BaseCurve.GetPointAtDist(value);
            tr.Dispose();
            return GetPointAtD;
        }

        public virtual Point3d GetPointAtParameter(double value)
        {
            createInstance();
            Point3d GetPointAtPar = BaseCurve.GetPointAtParameter(value);
            tr.Dispose();
            return GetPointAtPar;
        }

        public virtual Curve GetProjectedCurve(Plane planeToProjectOn, Vector3d projectionDirection)
        {
            createInstance();
            Curve GetProjectedC = BaseCurve.GetProjectedCurve(planeToProjectOn, projectionDirection);
            tr.Dispose();
            return GetProjectedC;
        }

        public virtual Vector3d GetSecondDerivative(double value)
        {
            createInstance();
            Vector3d GetSecondDer = BaseCurve.GetSecondDerivative(value);
            tr.Dispose();
            return GetSecondDer;
        }

        public virtual Vector3d GetSecondDerivative(Point3d point)
        {
            createInstance();
            Vector3d GetSecondDer = BaseCurve.GetSecondDerivative(point);
            tr.Dispose();
            return GetSecondDer;
        }

        public virtual DBObjectCollection GetSplitCurves(DoubleCollection value)
        {
            createInstance();
            DBObjectCollection GetSplitC = BaseCurve.GetSplitCurves(value);
            tr.Dispose();
            return GetSplitC;

        }

        public virtual DBObjectCollection GetSplitCurves(Point3dCollection points)
        {
            createInstance();
            DBObjectCollection GetSplitC = BaseCurve.GetSplitCurves(points);
            tr.Dispose();
            return GetSplitC;
        }

        public virtual void ReverseCurve()
        {
            createInstance();
            BaseCurve.ReverseCurve();
            tr.Dispose();
        }

        public void SetFromGeCurve(Curve3d geCurve)
        {
            createInstance();
            BaseCurve.SetFromGeCurve(geCurve);
            tr.Dispose();
        }

        public void SetFromGeCurve(Curve3d geCurve, Tolerance tolerance)
        {
            createInstance();
            BaseCurve.SetFromGeCurve(geCurve, tolerance);
            tr.Dispose();
        }

        public void SetFromGeCurve(Curve3d geCurve, Vector3d __unnamed001)
        {
            createInstance();
            BaseCurve.SetFromGeCurve(geCurve, __unnamed001);
            tr.Dispose();
        }

        public void SetFromGeCurve(Curve3d geCurve, Vector3d __unnamed001, Tolerance tolerance)
        {
            createInstance();
            BaseCurve.SetFromGeCurve(geCurve, __unnamed001, tolerance);
            tr.Dispose();
        }

    }

}
