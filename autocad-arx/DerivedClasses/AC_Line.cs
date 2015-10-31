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
    public class AC_Line : AC_Curve
    {
        protected internal Line BaseLine
        {
            get
            {
                return base.BaseCurve as Line;
            }
            set
            {
                base.BaseCurve = value;
            }
        }

        public AC_Line() : base()
        {
            this.BaseLine = new Line();
        }

        public AC_Line(Point3d pointer1, Point3d pointer2) : base()
        {
            this.BaseLine = new Line(pointer1, pointer2);
        }

        public AC_Line(Line inLine) : base()
        {
            base.ObjectId = inLine.ObjectId;
            this.BaseLine = inLine;
        }

        //PROPRIETIES LINE//////////////////

        public double Angle 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.Angle;
                }
                else
                {
                    return BaseLine.Angle;
                }
            }
        }

        public Vector3d Delta 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.Delta;
                }
                else
                {
                    return BaseLine.Delta;
                }
            }
        }

        public double Length
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.Length;
                }
                else
                {
                    return BaseLine.Length;
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
                    return BaseLine.Normal;
                }
                else
                {
                    return BaseLine.Normal;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseLine.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    BaseLine.Normal = value;
                }
            }
        }

        public double Thickness
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.Thickness;
                }
                else
                {
                    return BaseLine.Thickness;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseLine.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    BaseLine.Thickness = value;
                }
            }
        }

        public override Point3d StartPoint
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.StartPoint;
                }
                else
                {
                    return BaseLine.StartPoint;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseLine.StartPoint = value;
                    tr.Dispose();
                }
                else
                {
                    BaseLine.StartPoint = value;
                }
            }
        }

        public override Point3d EndPoint
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseLine.EndPoint;
                }
                else
                {
                    return BaseLine.EndPoint;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseLine.EndPoint = value;
                    tr.Dispose();
                }
                else
                {
                    BaseLine.EndPoint = value;
                }
            }
        }

        public static explicit operator AC_Line(Line line)
        {
            AC_Transactions tr = new AC_Transactions();
            AC_Line ln = new AC_Line(line);
            return ln;
        }
    }
}
