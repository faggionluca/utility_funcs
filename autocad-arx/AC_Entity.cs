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
     public class AC_Entity : Entity
    {
        public new ObjectId ObjectId { get; protected internal set; }
        public AC_Transactions tr;
        public Entity BaseEntity;

        protected internal AC_Entity(IntPtr unmanagedObjPtr, bool autoDelete) : base(unmanagedObjPtr,autoDelete)
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
            this.BaseEntity = tr.openObject(this.ObjectId, OpenMode.ForWrite) as Entity;
        }

        public bool isInstanced()
        {
            if (this.ObjectId != ObjectId.Null)
            {
                this.tr.AC_Doc.LockDocument();
                this.BaseEntity = this.tr.openObject(base.ObjectId, OpenMode.ForWrite) as Line;
                if (this.BaseEntity != null)
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

    }
}
