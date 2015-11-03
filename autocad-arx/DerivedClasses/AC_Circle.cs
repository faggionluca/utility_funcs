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
    public class AC_Circle : AC_Curve
    {
        protected internal Circle BaseCircle
        {
            get
            {
                return base.BaseCurve as Circle;
            }
            set
            {
                base.BaseCurve = value;
            }
        }

        public AC_Circle()
            : base()
        {
            this.BaseCircle = new Circle();
        }

        public AC_Circle(Point3d center, Vector3d normal, double radius)
            : base()
        {
            this.BaseCircle = new Circle(center, normal, radius);
        }

        public AC_Circle(Circle Circle)
        {
            this.ObjectId = Circle.Id;
            this.BaseCircle = Circle;
        }

        [Category("Geometry")]
        public Point3d Center 
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseCircle.Center;
                }
                else
                {
                    return BaseCircle.Center;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Center = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Center = value;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double Circumference
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseCircle.Circumference;
                }
                else
                {
                    return BaseCircle.Circumference;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Circumference = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Circumference = value;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double Diameter
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseCircle.Diameter;
                }
                else
                {
                    return BaseCircle.Diameter;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Diameter = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Diameter = value;
                }
            }
        }
        [Category("Geometry")]
        public Vector3d Normal
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseCircle.Normal;
                }
                else
                {
                    return BaseCircle.Normal;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Normal = value;
                }
            }
        }
        [Category("Geometry")]
        [UnitType(UnitType.Distance)]
        public double Radius
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseCircle.Radius;
                }
                else
                {
                    return BaseCircle.Radius;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Radius = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Radius = value;
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
                    return BaseCircle.Thickness;
                }
                else
                {
                    return BaseCircle.Thickness;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseCircle.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    BaseCircle.Thickness = value;
                }
            }
        }

        public static explicit operator AC_Circle(Circle circle)
        {
            AC_Transactions tr = new AC_Transactions();
            AC_Circle cr = new AC_Circle(circle);
            return cr;
        }

        public static explicit operator AC_Circle(Entity circle)
        {
            AC_Transactions tr = new AC_Transactions();
            AC_Circle cr = new AC_Circle(circle as Circle);
            return cr;
        }

    }
}
