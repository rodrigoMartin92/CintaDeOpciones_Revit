﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace CintaDeOpciones_Revit._1_PanelWPF_1
{
    [Transaction(TransactionMode.Manual)]
    public class WPF_Boton_1 : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                //Construimos el DockablePaneId con el mismo GUID. Considere establecer una const
                DockablePaneId dpid = new DockablePaneId(new Guid("{6f6fe7f8-1f07-4189-8692-7064b5020450}"));

                //Recuperamos el Panel desde la UIApplication
                DockablePane dp = uiapp.GetDockablePane(dpid);

                //Conmutamos su estado
                if (dp.IsShown() == false)
                    dp.Show();

                else

                    dp.Hide();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }



            return Result.Succeeded;
        }
    }
}
