using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Remoting;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.GraphicsInterface;

namespace AutoCad_ARX
{
    public abstract class AC_MarshalByRefObject : MarshalByRefObject
    {
        public AC_Transactions tr;
        [Category("Misc")]
        public ObjectId ObjectId
        {
            get;
            protected internal set;
        }
        protected internal MarshalByRefObject BaseMashalByRef;

        protected AC_MarshalByRefObject()
        {
            tr = new AC_Transactions();
        }

        public void createInstance()
        {
            tr.AC_Doc.LockDocument();
            this.BaseMashalByRef = tr.openObject(this.ObjectId, OpenMode.ForWrite) as MarshalByRefObject;
            if (this.BaseMashalByRef == null)
            {
                throw new System.InvalidOperationException("You cannot modify the object because it is Erased");
            }
        }

        public bool isInstanced()
        {
            if (this.ObjectId != ObjectId.Null)
            {
                this.tr.AC_Doc.LockDocument();
                this.BaseMashalByRef = this.tr.openObject(this.ObjectId, OpenMode.ForWrite) as MarshalByRefObject;
                if (this.BaseMashalByRef != null)
                {
                    return true;
                }
                else
                {
                    tr.Dispose();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public new virtual ObjRef CreateObjRef(Type requestedType)
        {
            createInstance();
            ObjRef CreateObjRef = BaseMashalByRef.CreateObjRef(requestedType);
            tr.Dispose();
            return CreateObjRef;
        }
        public new object GetLifetimeService()
        {
            createInstance();
            object GetLifetimeService = BaseMashalByRef.GetLifetimeService();
            tr.Dispose();
            return GetLifetimeService;
        }
        public new virtual object InitializeLifetimeService()
        {
            createInstance();
            object InitializeLifetimeService = BaseMashalByRef.InitializeLifetimeService();
            tr.Dispose();
            return InitializeLifetimeService;
        }

        //CAST TYPE CONVERSIONS
        static public explicit operator Autodesk.AutoCAD.DatabaseServices.Polyline(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Autodesk.AutoCAD.DatabaseServices.Polyline ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Autodesk.AutoCAD.DatabaseServices.Polyline;
            tr.closeObject();
            return ln;
        }

        static public explicit operator Line(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Line ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Line;
            tr.closeObject();
            return ln;
        }

        static public explicit operator Curve(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Curve ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Curve;
            tr.closeObject();
            return ln;
        }

        static public explicit operator Entity(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Entity ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Entity;
            tr.closeObject();
            return ln;
        }

        static public explicit operator DBObject(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            DBObject ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as DBObject;
            tr.closeObject();
            return ln;
        }

        static public explicit operator Drawable(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Drawable ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Drawable;
            tr.closeObject();
            return ln;
        }

        static public explicit operator RXObject(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            RXObject ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as RXObject;
            tr.closeObject();
            return ln;
        }

        static public explicit operator DisposableWrapper(AC_MarshalByRefObject ent)
        {
            AC_Transactions tr = new AC_Transactions();
            DisposableWrapper ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as DisposableWrapper;
            tr.closeObject();
            return ln;
        }
    }
}
