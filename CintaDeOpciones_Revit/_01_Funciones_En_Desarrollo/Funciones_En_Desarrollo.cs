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
        public static void Funcion_A_Definir()
        {
            TaskDialog.Show("Funcion_A_Definir", "Funcion_A_Definir");
        }
        public static void Funcion_A_Definir_2()
        {
            TaskDialog.Show("Funcion_A_Definir", "Funcion_A_Definir");
        }
        public static void Funcion_A_Definir_3()
        {
            TaskDialog.Show("Funcion_A_Definir", "Funcion_A_Definir");
        }

        public static List<string> Agregar_Categorias(Document doc)
        {

            try
            {
                IList<Category> Lista_Categorias = new List<Category>();
                IList<string> Lista_Categorias_Nombres = new List<string>();

                Categories categories = doc.Settings.Categories;

                foreach (Category category in categories)
                {
                    Lista_Categorias.Add(category);
                    Lista_Categorias_Nombres.Add(category.Name);
                }

                // Ordenar la lista alfabéticamente
                List<string> sortedCategoryNames = Lista_Categorias_Nombres.ToList();
                sortedCategoryNames.Sort();

                // (Opcional) Mostrar las categorías en un cuadro de diálogo
                TaskDialog.Show("Categorias", String.Join("\n", sortedCategoryNames));

                return sortedCategoryNames;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("TodasLasCategorias", ex.ToString());
                return null;
            }
        }
    }
}
