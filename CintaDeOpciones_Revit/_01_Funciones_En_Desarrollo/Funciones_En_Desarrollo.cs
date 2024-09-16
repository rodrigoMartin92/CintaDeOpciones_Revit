#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace CintaDeOpciones_Revit._2_Funciones_En_Desarrollo
{
    [Transaction(TransactionMode.Manual)]
    public class Funciones_En_Desarrollo : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            Funcion_A_Definir();

            return Result.Succeeded;
        }
        public void Funcion_A_Definir()
        {
            TaskDialog.Show("Funcion_A_Definir", "Funcion_A_Definir");
        }
    }

}
