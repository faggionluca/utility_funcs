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
        public Line line
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

        public AC_Line() : base(Marshal.StringToHGlobalUni(Guid.NewGuid().ToString()), true)
        {
            this.line = new Line();
        }

        public AC_Line(IntPtr ptrLine,Line inLine) : base(ptrLine, true)
        {

            base.ObjectId = inLine.ObjectId;
            this.line = inLine;
        }

        public AC_Line(Point3d pointer1, Point3d pointer2): base(Marshal.StringToHGlobalUni(Guid.NewGuid().ToString()), true)
        {
            this.line = new Line(pointer1, pointer2);
        }

        public static new AC_Line fromOpenObject(Entity ent)
        {
            AC_Line line = new AC_Line(ent.UnmanagedObject, ent as Line);
            return line;
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

        static public explicit operator Line(AC_Line ln)
        {
            return ln.line;
        }
    }
}
