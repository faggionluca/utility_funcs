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
    public abstract class AC_DisposableWrapper : AC_MarshalByRefObject,IDisposable
    {
        protected internal DisposableWrapper BaseDisposableWrapper
        {
            get
            {
                return base.BaseMashalByRef as DisposableWrapper;
            }
            set
            {
                base.BaseMashalByRef = value;
            }
        }

        protected AC_DisposableWrapper() : base() {}

        public void Dispose()
        {
            BaseDisposableWrapper.Dispose();
        }

        public static bool operator !=(AC_DisposableWrapper a, AC_DisposableWrapper b)
        {
            return ((DisposableWrapper)a != (DisposableWrapper)b);
        }
        public static bool operator ==(AC_DisposableWrapper a, AC_DisposableWrapper b)
        {
            return ((DisposableWrapper)a == (DisposableWrapper)b);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [XmlIgnore]
        public bool AutoDelete 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDisposableWrapper.AutoDelete;
            }
        }
        public bool IsDisposed 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDisposableWrapper.IsDisposed;
            }
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [XmlIgnore]
        public IntPtr UnmanagedObject 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDisposableWrapper.UnmanagedObject;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DisposableWrapper Create(Type type, IntPtr unmanagedPointer, bool autoDelete)
        {
            return DisposableWrapper.Create(type, unmanagedPointer, autoDelete);
        }
        public override bool Equals(object obj)
        {
            createInstance();
            bool Equals = BaseDisposableWrapper.Equals(obj);
            tr.Dispose();
            return Equals;
        }
        public override int GetHashCode()
        {
            createInstance();
            int GetHashCode = BaseDisposableWrapper.GetHashCode();
            tr.Dispose();
            return GetHashCode;
        }

    }
}
