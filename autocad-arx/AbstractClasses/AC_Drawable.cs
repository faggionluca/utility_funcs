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
    public abstract class AC_Drawable : AC_RXObject
    {
        protected internal Drawable BaseDrawable
        {
            get
            {
                return base.BaseRXObject as Drawable;
            }
            set
            {
                base.BaseRXObject = value;
            }
        }

        protected internal AC_Drawable() : base() { }

        //PROPRIETIES
        public virtual Extents3d? Bounds 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDrawable.Bounds;
            }
        }
        public DrawableType DrawableType 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDrawable.DrawableType;
            }
        }
        public virtual DrawStream DrawStream 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDrawable.DrawStream;
            }
            set
            {
                createInstance();
                BaseDrawable.DrawStream = value;
                tr.Dispose();
            }
        }
        public virtual ObjectId Id 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDrawable.Id;
            }
        }
        public virtual bool IsPersistent 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDrawable.IsPersistent;
            }
        }

        //METHODS
        public int SetAttributes(DrawableTraits traits)
        {
            createInstance();
            int SetAttrib = BaseDrawable.SetAttributes(traits);
            tr.Dispose();
            return SetAttrib;
        }
        public void ViewportDraw(ViewportDraw vd)
        {
            createInstance();
            BaseDrawable.ViewportDraw(vd);
            tr.Dispose();
        }
        public int ViewportDrawLogicalFlags(ViewportDraw vd)
        {
            createInstance();
            int ViewportDrawL = BaseDrawable.ViewportDrawLogicalFlags(vd);
            tr.Dispose();
            return ViewportDrawL;
        }
        public bool WorldDraw(WorldDraw wd)
        {
            createInstance();
            bool WorldD = BaseDrawable.WorldDraw(wd);
            tr.Dispose();
            return WorldD;
        }
    }
}
