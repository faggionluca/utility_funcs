using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.GraphicsInterface;

namespace AutoCad_ARX
{
    public abstract class AC_RXObject : AC_DisposableWrapper, ICloneable
    {
        protected internal RXObject BaseRXObject
        {
            get
            {
                return base.BaseDisposableWrapper as RXObject;
            }
            set
            {
                base.BaseDisposableWrapper = value;
            }
        }

        protected internal AC_RXObject() : base() {}

        //METHODS
        public virtual object Clone()
        {
            createInstance();
            object Clone = BaseRXObject.Clone();
            tr.Dispose();
            return Clone;
        }
        public int CompareTo(object obj)
        {
            createInstance();
            int CompareT = BaseRXObject.CompareTo(obj);
            tr.Dispose();
            return CompareT;
        }
        public virtual void CopyFrom(RXObject source)
        {
            createInstance();
            BaseRXObject.CopyFrom(source);
            tr.Dispose();
        }
        public static RXObject Create(IntPtr unmanagedPointer, bool autoDelete)
        {
            return Drawable.Create(unmanagedPointer, autoDelete);
        }
        //protected override void DeleteUnmanagedObject();
        public static RXClass GetClass(Type type)
        {
            return Drawable.GetClass(type);
        }
        public RXClass GetRXClass()
        {
            createInstance();
            RXClass GetRX = BaseRXObject.GetRXClass();
            tr.Dispose();
            return GetRX;
        }
        public IntPtr QueryX(RXClass protocolClass)
        {
            createInstance();
            IntPtr QueryX = BaseRXObject.QueryX(protocolClass);
            tr.Dispose();
            return QueryX;
        }
        public IntPtr X(RXClass protocolClass)
        {
            createInstance();
            IntPtr X = BaseRXObject.X(protocolClass);
            tr.Dispose();
            return X;
        }
    }
}
