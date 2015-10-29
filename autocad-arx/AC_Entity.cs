using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class AC_Entity : Entity
    {
        public new ObjectId ObjectId
        {
            get;
            protected internal set;
        }
        public AC_Transactions tr;
        protected internal Entity BaseEntity;

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

        public ObjectId addToDrawing()
        {
            this.ObjectId = tr.addObject(BaseEntity);
            return this.ObjectId;
        }

        //PROPRIETIES
        [Category("Misc")]
        public new ObjectId BlockId 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.BlockId;
            }
        }
        [Category("Misc")]
        public new string BlockName 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.BlockName;
            }
        }
        [Category("3D Visualization")]
        public new virtual bool CastShadows 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.CastShadows;
            }
            set
            {
                createInstance();
                BaseEntity.CastShadows = value;
                tr.Dispose();
            }
        }
        public new virtual bool CloneMeForDragging 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.CloneMeForDragging;
            }
        }
        [Category("Geometry")]
        public new virtual CollisionType CollisionType 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.CollisionType;
            }
        }
        [Category("General")]
        public new virtual Color Color
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Color;
            }
            set
            {
                createInstance();
                BaseEntity.Color = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual int ColorIndex
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.ColorIndex;
            }
            set
            {
                createInstance();
                BaseEntity.ColorIndex = value;
                tr.Dispose();
            }
        }
        [Category("Geometry")]
        public new virtual Matrix3d CompoundObjectTransform
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.CompoundObjectTransform;
            }
        }
        public new virtual Matrix3d Ecs
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Ecs;
            }
        }
        [Category("3D Visualization")]
        public new ObjectId EdgeStyleId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.EdgeStyleId;
            }
            set
            {
                createInstance();
                BaseEntity.EdgeStyleId = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new EntityColor EntityColor
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.EntityColor;
            }
        }
        [Category("3D Visualization")]
        public new ObjectId FaceStyleId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.FaceStyleId;
            }
            set
            {
                createInstance();
                BaseEntity.FaceStyleId = value;
                tr.Dispose();
            }
        }
        public new virtual bool ForceAnnoAllVisible
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.ForceAnnoAllVisible;
            }
            set
            {
                createInstance();
                BaseEntity.ForceAnnoAllVisible = value;
                tr.Dispose();
            }
        }
        [Category("Geometry")]
        public new virtual Extents3d GeometricExtents
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.GeometricExtents;
            }
        }
        [Category("General")]
        public new HyperLinkCollection Hyperlinks
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Hyperlinks;
            }
        }
        [Category("Geometry")]
        public new virtual bool IsPlanar
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.IsPlanar;
            }
        }
        [Category("General")]
        public new virtual string Layer
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Layer;
            }
            set
            {
                createInstance();
                BaseEntity.Layer = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual ObjectId LayerId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.LayerId;
            }
            set
            {
                createInstance();
                BaseEntity.LayerId = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual string Linetype
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Linetype;
            }
            set
            {
                createInstance();
                BaseEntity.Linetype = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual ObjectId LinetypeId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.LinetypeId;
            }
            set
            {
                createInstance();
                BaseEntity.LinetypeId = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual double LinetypeScale
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.LinetypeScale;
            }
            set
            {
                createInstance();
                BaseEntity.LinetypeScale = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual LineWeight LineWeight
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.LineWeight;
            }
            set
            {
                createInstance();
                BaseEntity.LineWeight = value;
                tr.Dispose();
            }
        }
        [Category("3D Visualization")]
        public new string Material
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Material;
            }
            set
            {
                createInstance();
                BaseEntity.Material = value;
                tr.Dispose();
            }
        }
        [Category("3D Visualization")]
        public new ObjectId MaterialId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.MaterialId;
            }
            set
            {
                createInstance();
                BaseEntity.MaterialId = value;
                tr.Dispose();
            }
        }
        [Category("3D Visualization")]
        public new Mapper MaterialMapper
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.MaterialMapper;
            }
            set
            {
                createInstance();
                BaseEntity.MaterialMapper = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual string PlotStyleName
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.PlotStyleName;
            }
            set
            {
                createInstance();
                BaseEntity.PlotStyleName = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual PlotStyleDescriptor PlotStyleNameId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.PlotStyleNameId;
            }
            set
            {
                createInstance();
                BaseEntity.PlotStyleNameId = value;
                tr.Dispose();
            }
        }
        [Category("3D Visualization")]
        public new virtual bool ReceiveShadows
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.ReceiveShadows;
            }
            set
            {
                createInstance();
                BaseEntity.ReceiveShadows = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual Transparency Transparency
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Transparency;
            }
            set
            {
                createInstance();
                BaseEntity.Transparency = value;
                tr.Dispose();
            }
        }
        [Category("General")]
        public new virtual bool Visible
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.Visible;
            }
            set
            {
                createInstance();
                BaseEntity.Visible = value;
                tr.Dispose();
            }
        }
        [Category("3D Visualization")]
        public new ObjectId VisualStyleId
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseEntity.VisualStyleId;
            }
            set
            {
                createInstance();
                BaseEntity.VisualStyleId = value;
                tr.Dispose();
            }
        }

        //METHODS

        public new void AddSubentityPaths(FullSubentityPath[] subPaths)
        {
            createInstance();
            BaseEntity.AddSubentityPaths(subPaths);
            tr.Dispose();
        }
        public new void BoundingBoxIntersectWith(Entity entityPointer, Intersect intersectType, Point3dCollection points, IntPtr thisGraphicSystemMarker, IntPtr otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.BoundingBoxIntersectWith(entityPointer, intersectType,points,thisGraphicSystemMarker,otherGraphicSystemMarker);
            tr.Dispose();
        }
        [Obsolete("Use the overload taking IntPtr instead.")]
        public new void BoundingBoxIntersectWith(Entity entityPointer, Intersect intersectType, Point3dCollection points, long thisGraphicSystemMarker, long otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.BoundingBoxIntersectWith(entityPointer, intersectType, points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        public new void BoundingBoxIntersectWith(Entity entityPointer, Intersect intersectType, Plane projectionPlane, Point3dCollection points, IntPtr thisGraphicSystemMarker, IntPtr otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.BoundingBoxIntersectWith(entityPointer, intersectType, projectionPlane,points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        [Obsolete("Use the overload taking IntPtr instead.")]
        public new void BoundingBoxIntersectWith(Entity entityPointer, Intersect intersectType, Plane projectionPlane, Point3dCollection points, long thisGraphicSystemMarker, long otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.BoundingBoxIntersectWith(entityPointer, intersectType,projectionPlane, points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        public new void DeleteSubentityPaths(FullSubentityPath[] subPaths)
        {
            createInstance();
            BaseEntity.DeleteSubentityPaths(subPaths);
            tr.Dispose();
        }
        [OpenMode(OpenMode.ForRead)]
        public new void Draw()
        {
            createInstance();
            BaseEntity.Draw();
            tr.Dispose();
        }
        public new void Explode(DBObjectCollection entitySet)
        {
            createInstance();
            BaseEntity.Explode(entitySet);
            tr.Dispose();
        }
        public new IntPtrCollection GetGraphicsMarkersAtSubentityPathIntPtr(FullSubentityPath subPath)
        {
            createInstance();
            IntPtrCollection GetGraphicsMarkers = BaseEntity.GetGraphicsMarkersAtSubentityPathIntPtr(subPath);
            tr.Dispose();
            return GetGraphicsMarkers;
        }
        public new void GetGripPoints(Point3dCollection gripPoints, IntegerCollection snapModes, IntegerCollection geometryIds)
        {
            createInstance();
            BaseEntity.GetGripPoints(gripPoints, snapModes,geometryIds);
            tr.Dispose();
        }
        public new bool GetGripPoints(GripDataCollection grips, double curViewUnitSize, int gripSize, Vector3d curViewDir, GetGripPointsFlags bitFlags)
        {
            createInstance();
            bool GetGripP = BaseEntity.GetGripPoints(grips, curViewUnitSize, gripSize,curViewDir,bitFlags);
            tr.Dispose();
            return GetGripP;
        }
        public new bool GetGripPointsAtSubentityPath(FullSubentityPath subPath, GripDataCollection grips, double curViewUnitSize, int gripSize, Vector3d curViewDir, GetGripPointsFlags bitFlags)
        {
            createInstance();
            bool GetGripP = BaseEntity.GetGripPointsAtSubentityPath(subPath, grips, curViewUnitSize, gripSize, curViewDir, bitFlags);
            tr.Dispose();
            return GetGripP;
        }
        public new void GetObjectSnapPoints(ObjectSnapModes snapMode, int gsSelectionMark, Point3d pickPoint, Point3d lastPoint, Matrix3d viewTransform, Point3dCollection snapPoints, IntegerCollection geometryIds)
        {
            createInstance();
            BaseEntity.GetObjectSnapPoints(snapMode, gsSelectionMark, pickPoint,lastPoint,viewTransform,snapPoints,geometryIds);
            tr.Dispose();
        }
        public new void GetObjectSnapPoints(ObjectSnapModes snapMode, int gsSelectionMark, Point3d pickPoint, Point3d lastPoint, Matrix3d viewTransform, Point3dCollection snapPoints, IntegerCollection geometryIds, Matrix3d insertionMat)
        {
            createInstance();
            BaseEntity.GetObjectSnapPoints(snapMode, gsSelectionMark, pickPoint, lastPoint, viewTransform, snapPoints, geometryIds, insertionMat);
            tr.Dispose();
        }
        public new virtual Plane GetPlane()
        {
            createInstance();
            Plane GetP = BaseEntity.GetPlane();
            tr.Dispose();
            return GetP;
        }
        public new void GetStretchPoints(Point3dCollection stretchPoints)
        {
            createInstance();
            BaseEntity.GetStretchPoints(stretchPoints);
            tr.Dispose();
        }
        public new Entity GetSubentity(FullSubentityPath id)
        {
            createInstance();
            Entity GetSubentity = BaseEntity.GetSubentity(id);
            tr.Dispose();
            return GetSubentity;
        }
        public new Extents3d GetSubentityGeometricExtents(FullSubentityPath subPath)
        {
            createInstance();
            Extents3d GetSubentityGeo = BaseEntity.GetSubentityGeometricExtents(subPath);
            tr.Dispose();
            return GetSubentityGeo;
        }
        public new FullSubentityPath[] GetSubentityPathsAtGraphicsMarker(SubentityType type, IntPtr gsMark, Point3d pickPoint, Matrix3d viewTransform, ObjectId[] entityAndInsertStack)
        {
            createInstance();
            FullSubentityPath[] GetSubentityPathsAtG = BaseEntity.GetSubentityPathsAtGraphicsMarker(type, gsMark, pickPoint, viewTransform, entityAndInsertStack);
            tr.Dispose();
            return GetSubentityPathsAtG;
        }
        [Obsolete("Use the overload taking IntPtr instead.")]
        public new FullSubentityPath[] GetSubentityPathsAtGraphicsMarker(SubentityType type, long gsMark, Point3d pickPoint, Matrix3d viewTransform, int numInserts, ObjectId[] entityAndInsertStack)
        {
            createInstance();
            FullSubentityPath[] GetSubentityPathsAtG = BaseEntity.GetSubentityPathsAtGraphicsMarker(type, gsMark, pickPoint, viewTransform, numInserts, entityAndInsertStack);
            tr.Dispose();
            return GetSubentityPathsAtG;
        }
        public new Entity GetTransformedCopy(Matrix3d transform)
        {
            createInstance();
            Entity GetTransformedC = BaseEntity.GetTransformedCopy(transform);
            tr.Dispose();
            return GetTransformedC;
        }
        public new void Highlight()
        {
            createInstance();
            BaseEntity.Highlight();
            tr.Dispose();

        }
        public new void Highlight(FullSubentityPath subId, bool highlightAll)
        {
            createInstance();
            BaseEntity.Highlight(subId,highlightAll);
            tr.Dispose();
        }
        public new HighlightStyle HighlightState(FullSubentityPath subId)
        {
            createInstance();
            HighlightStyle HighlightS = BaseEntity.HighlightState(subId);
            tr.Dispose();
            return HighlightS;
        }
        public new void IntersectWith(Entity entityPointer, Intersect intersectType, Point3dCollection points, IntPtr thisGraphicSystemMarker, IntPtr otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.IntersectWith(entityPointer, intersectType,points,thisGraphicSystemMarker,otherGraphicSystemMarker);
            tr.Dispose();
        }
        [Obsolete("Use the overload taking IntPtr instead.")]
        public new void IntersectWith(Entity entityPointer, Intersect intersectType, Point3dCollection points, long thisGraphicSystemMarker, long otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.IntersectWith(entityPointer, intersectType, points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        public new void IntersectWith(Entity entityPointer, Intersect intersectType, Plane projectionPlane, Point3dCollection points, IntPtr thisGraphicSystemMarker, IntPtr otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.IntersectWith(entityPointer, intersectType, projectionPlane, points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        [Obsolete("Use the overload taking IntPtr instead.")]
        public new void IntersectWith(Entity entityPointer, Intersect intersectType, Plane projectionPlane, Point3dCollection points, long thisGraphicSystemMarker, long otherGraphicSystemMarker)
        {
            createInstance();
            BaseEntity.IntersectWith(entityPointer, intersectType, projectionPlane, points, thisGraphicSystemMarker, otherGraphicSystemMarker);
            tr.Dispose();
        }
        public new bool IsContentSnappable()
        {
            createInstance();
            bool IsContentSnap = BaseEntity.IsContentSnappable();
            tr.Dispose();
            return IsContentSnap;
        }
        public new IntegerCollection JoinEntities(Entity[] otherEntities)
        {
            createInstance();
            IntegerCollection JoinEnt = BaseEntity.JoinEntities(otherEntities);
            tr.Dispose();
            return JoinEnt;
        }
        public new void JoinEntity(Entity secondaryEntity)
        {
            createInstance();
            BaseEntity.JoinEntity(secondaryEntity);
            tr.Dispose();
        }
        public new void List()
        {
            createInstance();
            BaseEntity.List();
            tr.Dispose();
        }
        public new void MoveGripPointsAt(IntegerCollection indices, Vector3d offset)
        {
            createInstance();
            BaseEntity.MoveGripPointsAt(indices, offset);
            tr.Dispose();
        }
        public new void MoveGripPointsAt(GripDataCollection grips, Vector3d offset, MoveGripPointsFlags bitFlags)
        {
            createInstance();
            BaseEntity.MoveGripPointsAt(grips, offset,bitFlags);
            tr.Dispose();
        }
        public new void MoveGripPointsAtSubentityPaths(FullSubentityPath[] subPaths, IntPtr[] appData, Vector3d offset, MoveGripPointsFlags bitFlags)
        {
            createInstance();
            BaseEntity.MoveGripPointsAtSubentityPaths(subPaths, appData, offset, bitFlags);
            tr.Dispose();
        }
        public new void MoveStretchPointsAt(IntegerCollection indices, Vector3d offset)
        {
            createInstance();
            BaseEntity.MoveStretchPointsAt(indices,offset);
            tr.Dispose();
        }
        public new void PopHighlight(FullSubentityPath subId)
        {
            createInstance();
            BaseEntity.PopHighlight(subId);
            tr.Dispose();
        }
        public new void PushHighlight(FullSubentityPath subId, HighlightStyle highlightStyle)
        {
            createInstance();
            BaseEntity.PushHighlight(subId,highlightStyle);
            tr.Dispose();
        }
        public new void RecordGraphicsModified(bool setModified)
        {
            createInstance();
            BaseEntity.RecordGraphicsModified(setModified);
            tr.Dispose();
        }
        public new virtual void SaveAs(WorldDraw mode, SaveType st)
        {
            createInstance();
            BaseEntity.SaveAs(mode,st);
            tr.Dispose();
        }
        public new void SetDatabaseDefaults()
        {
            createInstance();
            BaseEntity.SetDatabaseDefaults();
            tr.Dispose();
        }
        public new void SetDatabaseDefaults(Database sourceDatabase)
        {
            createInstance();
            BaseEntity.SetDatabaseDefaults(sourceDatabase);
            tr.Dispose();
        }
        public new virtual void SetDragStatus(DragStatus status)
        {
            createInstance();
            BaseEntity.SetDragStatus(status);
            tr.Dispose();
        }
        public new virtual void SetGripStatus(GripStatus status)
        {
            createInstance();
            BaseEntity.SetGripStatus(status);
            tr.Dispose();
        }
        public new virtual void SetLayerId(ObjectId newValue, bool allowHidden)
        {
            createInstance();
            BaseEntity.SetLayerId(newValue, allowHidden);
            tr.Dispose();
        }
        public new void SetPropertiesFrom(Entity entityPointer)
        {
            createInstance();
            BaseEntity.SetPropertiesFrom(entityPointer);
            tr.Dispose();
        }
        public new void SetSubentityGripStatus(GripStatus status, FullSubentityPath subentity)
        {
            createInstance();
            BaseEntity.SetSubentityGripStatus(status, subentity);
            tr.Dispose();
        }
        public new void TransformBy(Matrix3d transform)
        {
            createInstance();
            BaseEntity.TransformBy(transform);
            tr.Dispose();
        }
        public new void TransformSubentityPathsBy(FullSubentityPath[] subPaths, Matrix3d transform)
        {
            createInstance();
            BaseEntity.TransformSubentityPathsBy(subPaths, transform);
            tr.Dispose();
        }
        public new void Unhighlight()
        {
            createInstance();
            BaseEntity.Unhighlight();
            tr.Dispose();
        }
        public new void Unhighlight(FullSubentityPath subId, bool highlightAll)
        {
            createInstance();
            BaseEntity.Unhighlight(subId,highlightAll);
            tr.Dispose();
        }


        //CAST TYPE CONVERSIONS

        static public explicit operator Line(AC_Entity ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Line ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Line;
            tr.closeObject();
            return ln;
        }

        static public explicit operator Curve(AC_Entity ent)
        {
            AC_Transactions tr = new AC_Transactions();
            Curve ln = tr.openObject(ent.ObjectId, OpenMode.ForWrite) as Curve;
            tr.closeObject();
            return ln;
        }


    }
}
