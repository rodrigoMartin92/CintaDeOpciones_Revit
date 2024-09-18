#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;

#endregion

namespace CintaDeOpciones_Revit._1_PanelWPF_1
{
    [Transaction(TransactionMode.Manual)]
    public class _2_Funciones_WPF_1 : IExternalCommand
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
        public static void Funcion_A_Definir()
        {
            TaskDialog.Show("Funcion_A_Definir 1", "Funcion_A_Definir 1");
        }
    }
}
