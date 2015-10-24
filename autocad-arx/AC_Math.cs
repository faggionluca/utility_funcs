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
    class AC_Math
    {
        public AC_Math()
        {


        }

        public double RetriveRot(Point3d point1, Point3d point2)
        {
            return new Point2d(point1.X, point1.Y).GetVectorTo(new Point2d(point2.X, point2.Y)).Angle;
        }

        public double totalDistance(List<Point3d> PointList,int floatRound)
        {
            int i = 0;
            double Distance = 0;
            foreach (Point3d p in PointList)
            {
                if (i + 1 > PointList.Count - 1) { break; }
                Distance += PointList[i].DistanceTo(PointList[i + 1]);
                i++;
            }
            return Math.Round(Distance, floatRound);
        }

        public double totalDistance(Point3dCollection PointList, int floatRound, int index)
        {
            int i = 0;
            double Distance = 0;
            foreach (Point3d p in PointList)
            {
                if (i + 1 > PointList.Count - 1) { break; }
                Distance += PointList[i].DistanceTo(PointList[i + 1]);
                if (i == index){break;}
                i++;
            }
            return Math.Round(Distance, floatRound);
        }

        public List<Point3d> pointOffset(Point3d point1, Point3d point2,double offset)
        {
            Line line = new Line(point1,point2);
            List<Point3d> returnList = new List<Point3d>();
            DBObjectCollection offsetLine = new DBObjectCollection();
            try
            {
                offsetLine = line.GetOffsetCurves(offset);
            }
            catch
            {
                offsetLine.Add(new Line(point1, point2));
            }
            if(offsetLine.Count == 1)
            {
                Line oLine = offsetLine[0] as Line;
                returnList.Add(oLine.StartPoint);
                returnList.Add(new LineSegment3d(oLine.StartPoint, oLine.EndPoint).MidPoint);
                returnList.Add(oLine.EndPoint);
                line.Dispose();
                oLine.Dispose();
                return returnList;
            }
            else
            {
                line.Dispose();
                return null;
            }
        }

        public Point3d getPointAtVector(Point3d startpoint,Vector3d offset)
        {
            Point3d calculatedPoint = new Point3d();
            DBPoint point = new DBPoint(startpoint);
            point.TransformBy(Matrix3d.Displacement(offset));
            calculatedPoint = point.Position;
            point.Dispose();
            return calculatedPoint;
        }

    }
}
