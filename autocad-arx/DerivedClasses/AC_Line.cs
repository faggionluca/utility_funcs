using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        protected internal Line line
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
            this.line = new Line();
        }

        public AC_Line(Point3d pointer1, Point3d pointer2) : base()
        {
            this.line = new Line(pointer1, pointer2);
        }

        public AC_Line(Line inLine) : base()
        {
            base.ObjectId = inLine.ObjectId;
            this.line = inLine;
        }

        //PROPRIETIES LINE//////////////////

        public double Angle 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return line.Angle;
                }
                else
                {
                    return line.Angle;
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
                    return line.Delta;
                }
                else
                {
                    return line.Delta;
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
                    return line.Length;
                }
                else
                {
                    return line.Length;
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
                    return line.Normal;
                }
                else
                {
                    return line.Normal;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    line.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    line.Normal = value;
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
                    return line.Thickness;
                }
                else
                {
                    return line.Thickness;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    line.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    line.Thickness = value;
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
