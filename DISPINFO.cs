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
using AutoCad_ARX;

namespace Utility_funcs
{
    public class DisplayInformations
    {
        [CommandMethod("DISPINFO")]
        public void DispInformations()
        {

        }

        private class InfoObject
        {
            enum Info
            {
                Vertices,
                Lenght,
                Area,
                Quotes
            }

            enum ObjectType
            {
                Line,
                Polyline
            }

            //public InfoObject(AC_Entity obj, ObjectType objType, params Info[] dispInfo)
            //{

            //}
        }
    }
}
