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
    public class AC_DBText : AC_Entity
    {
        protected internal DBText BaseDBText
        {
            get
            {
                return base.BaseEntity as DBText;
            }
            set
            {
                base.BaseEntity = value;
            }
        }

        public AC_DBText() 
        {
            this.BaseDBText = new DBText();
        }

        public AC_DBText(DBText text)
        {
            this.ObjectId = text.ObjectId;
            this.BaseDBText = text;
        }

        public Point3d AlignmentPoint
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.AlignmentPoint;
                }
                else
                {
                    return BaseDBText.AlignmentPoint;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.AlignmentPoint = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.AlignmentPoint = value;
                }
            }
        }
        [Category("Text")]
        [UnitType(UnitType.Distance)]
        public double Height
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Height;
                }
                else
                {
                    return BaseDBText.Height;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Height = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Height = value;
                }
            }
        }
        public TextHorizontalMode HorizontalMode
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.HorizontalMode;
                }
                else
                {
                    return BaseDBText.HorizontalMode;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.HorizontalMode = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.HorizontalMode = value;
                }
            }
        }
        public bool IsDefaultAlignment
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.IsDefaultAlignment;
                }
                else
                {
                    return BaseDBText.IsDefaultAlignment;
                }
            }
        }
        public bool IsMirroredInX
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.IsMirroredInX;
                }
                else
                {
                    return BaseDBText.IsMirroredInX;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.IsMirroredInX = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.IsMirroredInX = value;
                }
            }
        }
        public bool IsMirroredInY
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.IsMirroredInY;
                }
                else
                {
                    return BaseDBText.IsMirroredInY;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.IsMirroredInY = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.IsMirroredInY = value;
                }
            }
        }
        public AttachmentPoint Justify
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Justify;
                }
                else
                {
                    return BaseDBText.Justify;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Justify = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Justify = value;
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
                    return BaseDBText.Normal;
                }
                else
                {
                    return BaseDBText.Normal;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Normal = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Normal = value;
                }
            }
        }
        [Category("Text")]
        [UnitType(UnitType.AngleNotTransformed)]
        public double Oblique
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Oblique;
                }
                else
                {
                    return BaseDBText.Oblique;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Oblique = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Oblique = value;
                }
            }
        }
        public Point3d Position
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Position;
                }
                else
                {
                    return BaseDBText.Position;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Position = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Position = value;
                }
            }
        }
        [Category("Text")]
        [UnitType(UnitType.Angle)]
        public double Rotation
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Rotation;
                }
                else
                {
                    return BaseDBText.Rotation;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Rotation = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Rotation = value;
                }
            }
        }
        public string TextString
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.TextString;
                }
                else
                {
                    return BaseDBText.TextString;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.TextString = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.TextString = value;
                }
            }
        }
        public ObjectId TextStyleId
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.TextStyleId;
                }
                else
                {
                    return BaseDBText.TextStyleId;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.TextStyleId = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.TextStyleId = value;
                }
            }
        }
        public string TextStyleName
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.TextStyleName;
                }
                else
                {
                    return BaseDBText.TextStyleName;
                }
            }
        }
        [Category("Text")]
        [UnitType(UnitType.Distance)]
        public double Thickness
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.Thickness;
                }
                else
                {
                    return BaseDBText.Thickness;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.Thickness = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.Thickness = value;
                }
            }
        }
        public TextVerticalMode VerticalMode
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.VerticalMode;
                }
                else
                {
                    return BaseDBText.VerticalMode;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.VerticalMode = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.VerticalMode = value;
                }
            }
        }
        [Category("Text")]
        [UnitType(UnitType.Unitless)]
        public double WidthFactor
        {
            get
            {
                if (base.isInstanced())
                {
                    tr.Dispose();
                    return BaseDBText.WidthFactor;
                }
                else
                {
                    return BaseDBText.WidthFactor;
                }
            }
            set
            {
                if (base.isInstanced())
                {
                    BaseDBText.WidthFactor = value;
                    tr.Dispose();
                }
                else
                {
                    BaseDBText.WidthFactor = value;
                }
            }
        }

        public virtual void AdjustAlignment(Database alternateDatabaseToUse)
        {
            if (base.isInstanced())
            {
                BaseDBText.AdjustAlignment(alternateDatabaseToUse);
                tr.Dispose();
            }
            else
            {
                BaseDBText.AdjustAlignment(alternateDatabaseToUse);
            }
        }
        public void ConvertFieldToText()
        {
            if (base.isInstanced())
            {
                BaseDBText.ConvertFieldToText();
                tr.Dispose();
            }
            else
            {
                BaseDBText.ConvertFieldToText();
            }
        }
        public int CorrectSpelling()
        {
            if (base.isInstanced())
            {
                int CorrectSpelling = BaseDBText.CorrectSpelling();
                tr.Dispose();
                return CorrectSpelling;
            }
            else
            {
                return BaseDBText.CorrectSpelling();
            }
        }
        public string getTextWithFieldCodes()
        {
            if (base.isInstanced())
            {
                string getTextWithFieldCodes = BaseDBText.getTextWithFieldCodes();
                tr.Dispose();
                return getTextWithFieldCodes;
            }
            else
            {
                return BaseDBText.getTextWithFieldCodes();
            }
        }

        public static explicit operator AC_DBText(DBText text)
        {
            AC_Transactions tr = new AC_Transactions();
            AC_DBText txt = new AC_DBText(text);
            return txt;
        }

    }
}
