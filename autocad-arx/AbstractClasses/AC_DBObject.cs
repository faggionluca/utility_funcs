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
    public abstract class AC_DBObject : AC_Drawable
    {
        protected internal DBObject BaseDBObject
        {
            get
            {
                return base.BaseDrawable as DBObject;
            }
            set
            {
                base.BaseDrawable = value;
            }
        }

        protected internal AC_DBObject() : base() { }

        public ObjectId addToDrawing()
        {
            this.ObjectId = tr.addObject(BaseDBObject as Entity);
            return base.ObjectId;
        }

        //PROPRIETIES
        [Category("Misc")]
        public object AcadObject 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.AcadObject;
            }
        }
        public AnnotativeStates Annotative 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.Annotative;
            }
            set
            {
                createInstance();
                BaseDBObject.Annotative = value;
                tr.Dispose();
            } 
        }
        [Category("Misc")]
        public Guid ClassID 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.ClassID;
            } 
        }
        public Database Database 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.Database;
            } 
        }
        [XmlIgnore]
        public virtual Drawable Drawable 
        { 
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.Drawable;
            } 
        }
        [Category("Misc")]
        public ObjectId ExtensionDictionary 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.ExtensionDictionary;
            } 
        }
        [Category("Misc")]
        public Handle Handle 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.Handle;
            } 
        }
        [Category("Misc")]
        public bool HasFields 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.HasFields;
            } 
        }
        public bool HasSaveVersionOverride 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.HasSaveVersionOverride;
            } 
            set
            {
                createInstance();
                BaseDBObject.HasSaveVersionOverride = value;
                tr.Dispose();
            } 
        }
        public override ObjectId Id 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.Id;
            } 
        }
        [Category("Misc")]
        public bool IsAProxy 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsAProxy;
            } 
        }
        public bool IsCancelling 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsCancelling;
            } 
        }
        public bool IsErased 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsCancelling;
            } 
        }
        public bool IsEraseStatusToggled 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsEraseStatusToggled;
            } 
        }
        public bool IsModified 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsModified;
            } 
        }
        public bool IsModifiedGraphics 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsModifiedGraphics;
            } 
        }
        public bool IsModifiedXData 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsModifiedXData;
            } 
        }
        public bool IsNewObject 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsNewObject;
            } 
        }
        public bool IsNotifyEnabled 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsNotifyEnabled;
            } 
        }
        public bool IsNotifying 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsNotifying;
            } 
        }
        public bool IsObjectIdsInFlux 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsObjectIdsInFlux;
            } 
        }
        public override bool IsPersistent 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsPersistent;
            } 
        }
        public bool IsReadEnabled 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsReadEnabled;
            } 
        }
        public bool IsReallyClosing 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsReallyClosing;
            } 
        }
        public bool IsTransactionResident 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsTransactionResident;
            } 
        }
        public bool IsUndoing 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsUndoing;
            } 
        }
        public bool IsWriteEnabled 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.IsWriteEnabled;
            } 
        }
        [Category("Misc")]
        public virtual DuplicateRecordCloning MergeStyle 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.MergeStyle;
            } 
            set
            {
                createInstance();
                BaseDBObject.MergeStyle = value;
                tr.Dispose();
            } 
        }
        [Category("Misc")]
        public virtual FullDwgVersion ObjectBirthVersion 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.ObjectBirthVersion;
            }
        }
        [Category("Misc")]
        public virtual ObjectId OwnerId 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.OwnerId;
            }
            set
            {
                createInstance();
                BaseDBObject.OwnerId = value;
                tr.Dispose();
            } 
        }
        public PaperOrientationStates PaperOrientation 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.PaperOrientation;
            }
        }
        public DwgFiler UndoFiler 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.UndoFiler;
            }
        }
        public virtual ResultBuffer XData 
        {
            get
            {
                createInstance();
                tr.Dispose();
                return BaseDBObject.XData;
            }
            set
            {
                createInstance();
                BaseDBObject.XData = value;
                tr.Dispose();
            } 
        }

        //METHODS
        public void AddContext(ObjectContext context)
        {
            createInstance();
            BaseDBObject.AddContext(context);
            tr.Dispose();
        }
        public void ApplyPaperOrientationTransform(Autodesk.AutoCAD.DatabaseServices.Viewport viewport)
        {
            createInstance();
            BaseDBObject.ApplyPaperOrientationTransform(viewport);
            tr.Dispose();
        }
        public virtual void ApplyPartialUndo(DwgFiler undoFiler, RXClass classObj)
        {
            createInstance();
            BaseDBObject.ApplyPartialUndo(undoFiler, classObj);
            tr.Dispose();
        }
        public virtual void Audit(AuditInfo auditInfo)
        {
            createInstance();
            BaseDBObject.Audit(auditInfo);
            tr.Dispose();
        }
        [Obsolete("Use Transaction instead")]
        public void Cancel()
        {
            createInstance();
            BaseDBObject.Cancel();
            tr.Dispose();
        }
        [Obsolete("Use Transaction instead")]
        public void Close()
        {
            createInstance();
            BaseDBObject.Close();
            tr.Dispose();
        }
        [Obsolete("Use Transaction instead")]
        public void CloseAndPage(bool onlyWhenClean)
        {
            createInstance();
            BaseDBObject.CloseAndPage(onlyWhenClean);
            tr.Dispose();
        }
        public void CreateExtensionDictionary()
        {
            createInstance();
            BaseDBObject.CreateExtensionDictionary();
            tr.Dispose();
        }
        public virtual DecomposeForSaveReplacementRecord DecomposeForSave(DwgVersion version)
        {
            createInstance();
            DecomposeForSaveReplacementRecord DecomposeForS = BaseDBObject.DecomposeForSave(version);
            tr.Dispose();
            return DecomposeForS;
        }
        public DBObject DeepClone(DBObject ownerPointer, IdMapping idMap, bool isPrimary)
        {
            createInstance();
            DBObject DeepC = BaseDBObject.DeepClone(ownerPointer, idMap, isPrimary);
            tr.Dispose();
            return DeepC;
        }
        public void DisableUndoRecording(bool disable)
        {
            createInstance();
            BaseDBObject.DisableUndoRecording(disable);
            tr.Dispose();
        }
        public void DowngradeOpen()
        {
            createInstance();
            BaseDBObject.DowngradeOpen();
            tr.Dispose();
        }
        public void DowngradeToNotify(bool wasWritable)
        {
            createInstance();
            BaseDBObject.DowngradeToNotify(wasWritable);
            tr.Dispose();
        }
        public void DwgIn(DwgFiler filer)
        {
            createInstance();
            BaseDBObject.DwgIn(filer);
            tr.Dispose();
        }
        public void DwgOut(DwgFiler filer)
        {
            createInstance();
            BaseDBObject.DwgOut(filer);
            tr.Dispose();
        }
        public void DxfIn(DxfFiler filer)
        {
            createInstance();
            BaseDBObject.DxfIn(filer);
            tr.Dispose();
        }
        public void DxfOut(DxfFiler filer)
        {
            createInstance();
            BaseDBObject.DxfOut(filer);
            tr.Dispose();
        }
        public void Erase()
        {
            createInstance();
            BaseDBObject.Erase();
            tr.Dispose();
        }
        public void Erase(bool erasing)
        {
            createInstance();
            BaseDBObject.Erase(erasing);
            tr.Dispose();
        }
        public static ObjectId FromAcadObject(object acadObj)
        {
            return DBObject.FromAcadObject(acadObj);
        }
        public ObjectId GetField()
        {
            createInstance();
            ObjectId GetF = BaseDBObject.GetField();
            tr.Dispose();
            return GetF;
        }
        public ObjectId GetField(string propertyName)
        {
            createInstance();
            ObjectId GetF = BaseDBObject.GetField(propertyName);
            tr.Dispose();
            return GetF;
        }
        public virtual FullDwgVersion GetObjectSaveVersion(DwgFiler filer)
        {
            createInstance();
            FullDwgVersion GetObjectSave = BaseDBObject.GetObjectSaveVersion(filer);
            tr.Dispose();
            return GetObjectSave;
        }
        public virtual FullDwgVersion GetObjectSaveVersion(DxfFiler filer)
        {
            createInstance();
            FullDwgVersion GetObjectSave = BaseDBObject.GetObjectSaveVersion(filer);
            tr.Dispose();
            return GetObjectSave;
        }
        public IParameter GetParameterInterface(string name, bool runtimeInterface)
        {
            createInstance();
            IParameter GetParameterI = BaseDBObject.GetParameterInterface(name, runtimeInterface);
            tr.Dispose();
            return GetParameterI;
        }
        public ObjectIdCollection GetPersistentReactorIds()
        {
            createInstance();
            ObjectIdCollection GetPersistentR = BaseDBObject.GetPersistentReactorIds();
            tr.Dispose();
            return GetPersistentR;
        }
        [Obsolete("Use GetTransientReactors() instead.")]
        public List<RXObject> GetReactors()
        {
            createInstance();
            List<RXObject> GetReac = BaseDBObject.GetReactors();
            tr.Dispose();
            return GetReac;
        }
        public List<RXObject> GetTransientReactors()
        {
            createInstance();
            List<RXObject> GetTransientR = BaseDBObject.GetTransientReactors();
            tr.Dispose();
            return GetTransientR;
        }
        public ResultBuffer GetXDataForApplication(string applicationName)
        {
            createInstance();
            ResultBuffer GetXDataForA = BaseDBObject.GetXDataForApplication(applicationName);
            tr.Dispose();
            return GetXDataForA;
        }
        public void HandOverTo(DBObject newPointer, bool keepXData, bool keepExtensionDictionary)
        {
            createInstance();
            BaseDBObject.HandOverTo(newPointer,keepXData,keepExtensionDictionary);
            tr.Dispose();
        }
        public bool HasContext(ObjectContext context)
        {
            createInstance();
            bool HasCont = BaseDBObject.HasContext(context);
            tr.Dispose();
            return HasCont;
        }
        public bool HasPersistentReactor(ObjectId objId)
        {
            createInstance();
            bool HasPersistentR = BaseDBObject.HasPersistentReactor(objId);
            tr.Dispose();
            return HasPersistentR;
        }
        public static bool IsCustomObject(ObjectId id)
        {
            return DBObject.IsCustomObject(id);
        }
        public void ReleaseExtensionDictionary()
        {
            createInstance();
            BaseDBObject.ReleaseExtensionDictionary();
            tr.Dispose();
        }
        public void RemoveContext(ObjectContext context)
        {
            createInstance();
            BaseDBObject.RemoveContext(context);
            tr.Dispose();
        }
        public ObjectId RemoveField()
        {
            createInstance();
            ObjectId RemoveF = BaseDBObject.RemoveField();
            tr.Dispose();
            return RemoveF;
        }
        public void RemoveField(ObjectId id)
        {
            createInstance();
            BaseDBObject.RemoveField(id);
            tr.Dispose();
        }
        public ObjectId RemoveField(string propertyName)
        {
            createInstance();
            ObjectId RemoveF = BaseDBObject.RemoveField(propertyName);
            tr.Dispose();
            return RemoveF;
        }
        public void ResetScaleDependentProperties()
        {
            createInstance();
            BaseDBObject.ResetScaleDependentProperties();
            tr.Dispose();
        }
        public ObjectId SetField(Field field)
        {
            createInstance();
            ObjectId SetF = BaseDBObject.SetField(field);
            tr.Dispose();
            return SetF;
        }
        public ObjectId SetField(string propertyName, Field field)
        {
            createInstance();
            ObjectId SetF = BaseDBObject.SetField(propertyName,field);
            tr.Dispose();
            return SetF;
        }
        public bool SetFromStyle()
        {
            createInstance();
            bool SetFromS = BaseDBObject.SetFromStyle();
            tr.Dispose();
            return SetFromS;
        }
        public void SetObjectIdsInFlux()
        {
            createInstance();
            BaseDBObject.SetObjectIdsInFlux();
            tr.Dispose();
        }
        public void SetPaperOrientation(bool bPaperOrientation)
        {
            createInstance();
            BaseDBObject.SetPaperOrientation(bPaperOrientation);
            tr.Dispose();
        }
        public bool SupportsCollection(string collectionName)
        {
            createInstance();
            bool SupportsC = BaseDBObject.SupportsCollection(collectionName);
            tr.Dispose();
            return SupportsC;
        }
        public void SwapIdWith(ObjectId otherId, bool swapExtendedData, bool swapExtensionDictionary)
        {
            createInstance();
            BaseDBObject.SwapIdWith(otherId, swapExtendedData, swapExtensionDictionary);
            this.ObjectId = otherId;
            tr.Dispose();
        }
        public virtual void SwapReferences(IdMapping idMap)
        {
            createInstance();
            BaseDBObject.SwapReferences(idMap);
            tr.Dispose();
        }
        public bool UpgradeFromNotify()
        {
            createInstance();
            bool UpgradeFromN = BaseDBObject.UpgradeFromNotify();
            tr.Dispose();
            return UpgradeFromN;
        }
        public void UpgradeOpen()
        {
            createInstance();
            BaseDBObject.UpgradeOpen();
            tr.Dispose();
        }
        public DBObject WblockClone(RXObject ownerPointer, IdMapping idMap, bool isPrimary)
        {
            createInstance();
            DBObject WblockC = BaseDBObject.WblockClone(ownerPointer,idMap,isPrimary);
            tr.Dispose();
            return WblockC;
        }
        public void XDataTransformBy(Matrix3d transform)
        {
            createInstance();
            BaseDBObject.XDataTransformBy(transform);
            tr.Dispose();
        }


        //EVENTS
        protected internal void addEvents()
        {
            createInstance();
            this.BaseDBObject.Cancelled += BaseDBObject_Cancelled;
            this.BaseDBObject.Copied += BaseDBObject_Copied;
            this.BaseDBObject.Modified += BaseDBObject_Modified;
            this.BaseDBObject.Erased += BaseDBObject_Erased;
            this.BaseDBObject.Goodbye += BaseDBObject_Goodbye;
            this.BaseDBObject.ModifiedXData += BaseDBObject_ModifiedXData;
            this.BaseDBObject.ModifyUndone += BaseDBObject_ModifyUndone;
            this.BaseDBObject.ObjectClosed += BaseDBObject_ObjectClosed;
            this.BaseDBObject.OpenedForModify += BaseDBObject_OpenedForModify;
            this.BaseDBObject.Reappended += BaseDBObject_Reappended;
            this.BaseDBObject.SubObjectModified += BaseDBObject_SubObjectModified;
            this.BaseDBObject.Unappended += BaseDBObject_Unappended;
            tr.Dispose();
        }

        public event EventHandler Cancelled;
        private void BaseDBObject_Cancelled(object sender, EventArgs e)
        {
            Cancelled(sender, e);
        }

        public event ObjectEventHandler Copied;
        void BaseDBObject_Copied(object sender, ObjectEventArgs e)
        {
            Copied(sender, e);
        }

        public event ObjectErasedEventHandler Erased;
        void BaseDBObject_Erased(object sender, ObjectErasedEventArgs e)
        {
            Erased(sender, e);
        }

        public event EventHandler Goodbye;
        void BaseDBObject_Goodbye(object sender, EventArgs e)
        {
            Goodbye(sender, e);
        }

        public event EventHandler Modified;
        void BaseDBObject_Modified(object sender, EventArgs e)
        {
            Modified(sender, e);
        }

        public event EventHandler ModifiedXData;
        void BaseDBObject_ModifiedXData(object sender, EventArgs e)
        {
            ModifiedXData(sender, e);
        }

        public event EventHandler ModifyUndone;
        void BaseDBObject_ModifyUndone(object sender, EventArgs e)
        {
            ModifyUndone(sender, e);
        }

        public event ObjectClosedEventHandler ObjectClosed;
        void BaseDBObject_ObjectClosed(object sender, ObjectClosedEventArgs e)
        {
            ObjectClosed(sender, e);
        }

        public event EventHandler OpenedForModify;
        void BaseDBObject_OpenedForModify(object sender, EventArgs e)
        {
            OpenedForModify(sender, e);
        }

        public event EventHandler Reappended;
        void BaseDBObject_Reappended(object sender, EventArgs e)
        {
            Reappended(sender, e);
        }

        public event ObjectEventHandler SubObjectModified;
        void BaseDBObject_SubObjectModified(object sender, ObjectEventArgs e)
        {
            SubObjectModified(sender, e);
        }

        public event EventHandler Unappended;
        void BaseDBObject_Unappended(object sender, EventArgs e)
        {
            Unappended(sender, e);
        }
    }
}
