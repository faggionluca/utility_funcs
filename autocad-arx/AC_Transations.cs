using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace AutoCad_ARX
{
    public class AC_Transactions
    {
        public Document AC_Doc { get; set; }
        public Database AC_Db { get; set; }
        public Transaction AC_Tr { get; set; }
        public DocumentCollection AC_DocCol { get; set; }

        public BlockTable AC_blockTable { get; set; }
        public BlockTableRecord AC_blockTableRecord { get; set; }
        public DBDictionary AC_GroupDictionary { get; set; }

        public AC_Transactions(Document acDoc, Database acCurDb)
        {
            AC_Doc = acDoc;
            AC_Db = acCurDb;
            AC_DocCol = Application.DocumentManager;
        }

        public AC_Transactions()
        {
            AC_Doc = Application.DocumentManager.MdiActiveDocument;
            AC_Db = AC_Doc.Database;
            AC_DocCol = Application.DocumentManager;
        }

        public Transaction start_Transaction()
        {
            AC_Tr = AC_Doc.TransactionManager.StartTransaction();
            return AC_Tr;
        }

        public void end_Transaction()
        {
            AC_Tr.Commit();
            AC_Tr.Dispose();
        }

        public void openBlockTables(OpenMode TableMode, OpenMode RecordMode)
        {
            AC_blockTable = AC_Db.BlockTableId.GetObject(TableMode) as BlockTable;

            AC_blockTableRecord = AC_blockTable[BlockTableRecord.ModelSpace].GetObject(RecordMode) as BlockTableRecord;
        }

        public DBDictionary openGroupDictionary(OpenMode mode)
        {
           return AC_GroupDictionary = (DBDictionary)AC_Tr.GetObject(AC_Db.GroupDictionaryId,mode);
        }

        public ObjectId Commit(Entity Object)
        {
            ObjectId id = AC_blockTableRecord.AppendEntity(Object);
            AC_Tr.AddNewlyCreatedDBObject(Object, true);
            return id;
        }

        public void Dispose()
        {
            AC_Tr.Commit();
            AC_blockTable.Dispose();
            AC_blockTableRecord.Dispose();
            AC_Tr.Dispose();
        }

        //FUNCTIONS//////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// <para>add an Object to the current autocad document</para>
        /// <para>Return:</para> <para>ObjectId (of the newly created Object)</para>
        /// </summary>
        /// <param name="Object">An Autodesk.AutoCAD.DatabaseServices type</param>
        /// <returns></returns>
        public ObjectId addObject(Entity Object)
        {
            start_Transaction();
            openBlockTables(OpenMode.ForRead, OpenMode.ForWrite);
            ObjectId id = Commit(Object);
            Object.Dispose();
            Dispose();
            return id;
        }

        public ObjectId addAC_Line(AC_Line line)
        {
            ObjectId id = addObject(line);
            line.ObjectId = id;
            return id;
        }

        /// <summary>
        /// <para>This Function let you open a object with the mode u specify.</para>
        /// <para>Return:</para><para> Null (if nothing was found)</para> <para>Entity (if there is a successful found)</para>
        /// <para>Warning: Remember to dispose the transaction with AC_Transaction.Dispose()</para>
        /// </summary>
        /// <param name="ObjId">The id of the object to open</param>
        /// <param name="mode"> specify the openmode of the object</param>
        /// <returns>null if no object was found, Entity for a succefull found</returns>
        public Entity openObject(ObjectId ObjId,OpenMode mode)
        {
            start_Transaction();
            openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
            foreach(ObjectId id in AC_blockTableRecord)
            {
                if (ObjId == id)
                {
                    Entity ent = AC_Tr.GetObject(id,mode) as Entity;
                    return ent;
                }
            }
            Dispose();
            return null;
        }

        /// <summary>
        /// <para>Let you open a object already disposed and erased only for read</para>
        /// <para>Return:</para>
        /// <para>Entity (if found an object)</para>
        /// <para>null (if nothing found)</para>
        /// </summary>
        /// <param name="ObjId">object id for opening</param>
        /// <returns></returns>
        public Entity openObjectErased(ObjectId ObjId)
        {
            Entity ent = openObject(ObjId, OpenMode.ForRead) as Entity;
            if (ent != null)
            {
                Dispose();
                return ent;
            }
            else
            {
                return null;
            }
        }

        public void closeObject()
        {
            Dispose();
        }

        public void closeObject(Entity Obj)
        {
            Obj.Dispose();
            AC_Tr.Commit();
            AC_blockTable.Dispose();
            AC_blockTableRecord.Dispose();
            AC_Tr.Dispose();
        }

        /// <summary>
        /// <para>Add a group to the current autocad document</para>
        /// <para>Return: Group</para>
        /// </summary>
        /// <param name="name">Group name</param>
        /// <param name="DbObjs">Object Collection to associate with group</param>
        /// <param name="autorename"><para>if a group has already the specified name</para>
        /// <para>This let the function assign an unique generated name</para></param>
        /// <returns></returns>
        public ObjectId addGroup(string name, DBObjectCollection DbObjs, bool autorename)
        {
            Group grp = new Group(name, true);
            ObjectIdCollection ids = new ObjectIdCollection();

            start_Transaction();
            DBDictionary gd = openGroupDictionary(OpenMode.ForWrite);
            if (gd.Contains(name))
            {
                if (autorename)
                {
                    name = name + "_" + Guid.NewGuid().ToString();
                }
                else
                {
                    return ObjectId.Null;
                }
            }
            gd.SetAt(name, grp);
            AC_Tr.AddNewlyCreatedDBObject(grp, true);

            openBlockTables(OpenMode.ForRead, OpenMode.ForWrite);
            foreach (Entity ent in DbObjs)
            {
                ObjectId id = Commit(ent);
                ids.Add(id);
            }
            grp.InsertAt(0, ids);
            gd.Dispose();
            Dispose();

            return grp.ObjectId;
        }

        /// <summary>
        /// <para>open a Group in the current Autocad Document</para>
        /// <para>Warning: Remember to dispose the Trasanction with AC_Transaction.end_Transaction</para>
        /// <para>Return:</para> <para>Null (if nothing found)</para> <para>Group (if the group name was found)</para>
        /// </summary>
        /// <param name="groupId">Name of the group to search</param>
        /// <param name="mode"> Specific mode for open the group</param>
        /// <returns></returns>
        public Group openGroup(ObjectId groupId,OpenMode mode)
        {
            start_Transaction();
            DBDictionary gd = openGroupDictionary(OpenMode.ForWrite);
            if (gd.Contains(groupId))
            {
                return AC_Tr.GetObject(groupId, mode) as Group;
            }
            else
            {
                return null;
            }
        }

        public void closeGroup()
        {
            end_Transaction();
        }

        public void closeGroup(Entity group)
        {
            group.Dispose();
            end_Transaction();
        }


        //GET FUNCTIONS/////////////////////////////////////////////////////////////////////////////////

        public ObjectId getGroupWithTag(string tag)
        {
            start_Transaction();
            DBDictionary gd = openGroupDictionary(OpenMode.ForRead);
            if (gd.Contains(tag))
            {
                AC_Tr.Commit();
                AC_Tr.Dispose();
                return gd.GetAt(tag);
            }
            else
            {
                AC_Tr.Commit();
                AC_Tr.Dispose();
                return ObjectId.Null;
            }
        }

        public ObjectIdCollection getAllObjectsWithDic(string searchPath)
        {
            ObjectIdCollection objs = new ObjectIdCollection();
            start_Transaction();
            AC_Db = AC_Doc.Database;
            openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
            foreach (ObjectId id in AC_blockTableRecord)
            {
                DBObject dbObj = AC_Tr.GetObject(id, OpenMode.ForRead) as DBObject;
                ObjectId dic = dbObj.ExtensionDictionary;
                if (dic != ObjectId.Null)
                {
                    DBDictionary dbDic = (DBDictionary)AC_Tr.GetObject(dic, OpenMode.ForRead);
                    if (dbDic.Contains(searchPath))
                    {
                        objs.Add(id);
                    }
                }
            }
            AC_Tr.Dispose();
            return objs;
        }

    }
}
