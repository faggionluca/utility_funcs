# autocad-arx
managed classes for simplify (dot)net programming for autocad
autocad-arx provides some classes and a intermediate class called **AC_Transactions**
the concept behind this is a *write less do more* because the traditional way for (dot)net programming on autocad is very tedious
with these classes you should also keep more organized the code

Here a short example:

**Using the AC_Transactions Class**
```c#
//Init the class only do this one time
AC_Transactions tr = new AC_Transactions();
Entity ent = tr.openObject(myid,OpenMode.ForRead) as Entity;
```

**Autocad Standard way of open an object**
```c#
// Start a transaction 
using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction()) { 
	// Open the Block table for read 
	BlockTable acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,OpenMode.ForRead)as BlockTable;  
	// Open the Block table record Model space for read 
	BlockTableRecord acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],OpenMode.ForRead) as BlockTableRecord;  
	// Step through the Block table record 
	foreach (ObjectId asObjId in acBlkTblRec) 
	{
	//IF the id that we have is equal to and id in the BlockTableRecord acBlkTblRec open the object
	  if(myid == asObjId)
	  {
	    Entity ent = acTrans.GetObject(asObjId,Openmode.ForRead) as Entity;
	  }
	}  
// Dispose of the transaction
}
```

**And if you want to have more control with AC_Transactions**
```c#
//Init the class only do this one time
AC_Transactions tr = new AC_Transactions();
// Start a transaction
tr.start_Transaction();
// Open the Block tables for read
openBlockTables(OpenMode.ForRead, OpenMode.ForRead);
foreach(Object id in AC_blockTableRecord)
{
  if(myid == id)
  {
    Entity ent = AC_Tr.GetObject(id,mode) as Entity;
  }
}
// Dispose of the transaction
tr.Dispose();
```

# How to integrate this in your project
for using these classes in your project you need to make sure to have the following dependencies:

1. Object ARX for Autocad 2014 (minimum other version up are ok)  [Object ARX Download](http://usa.autodesk.com/adsk/servlet/item?siteID=123112&id=785550)
2. Reference the Object ARX dlls in your project, their are found in **ObjectArxPath\inc\**
  * AcCoreMgd
  * AcCui
  * AcDbMgd
  * acdbmgdbrep
  * AcDx
  * AcMgd
  * AcMr
  * AcTcMgd
  * AcWindows
  * AdWindows
3. Add the reference path to the project
  * ObjectArxPath\inc\
  * ObjectArxPath\inc-x64\ or ObjectArxPath\inc-x32\ (**Depend on the platform**)
4. In the files u want to use these classes add:
  * ```c# using AutoCad_ARX; ```

