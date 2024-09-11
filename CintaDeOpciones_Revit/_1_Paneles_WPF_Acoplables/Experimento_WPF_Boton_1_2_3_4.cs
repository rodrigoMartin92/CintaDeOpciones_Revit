#region Namespaces
using Autodesk.Revit.Attributes;
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
#endregion

namespace CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables
{
    [Transaction(TransactionMode.Manual)]
    public class Experimento_WPF_Boton_1_2_3_4 : IExternalCommand
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
            TaskDialog.Show("_1_Paneles_WPF_Acoplables", "_1_Paneles_WPF_Acoplables");

            return Result.Succeeded;
        }
    }
}
