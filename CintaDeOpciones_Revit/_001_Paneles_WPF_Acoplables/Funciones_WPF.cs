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

namespace CintaDeOpciones_Revit._001_Paneles_WPF_Acoplables
{
    [Transaction(TransactionMode.Manual)]
    public class Funciones_WPF : IExternalCommand
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

            AgregarCategorias(doc);

            return Result.Succeeded;
        }

        public static void TaskDialog_Test()
        {
            TaskDialog.Show("TaskDialog_Test", "TaskDialog_Test");
        }

        public static void AgregarCategorias(Document doc)
        {
            try
            {
                IList<Category> Lista_Categorias = new List<Category>();
                IList<string> Lista_Categorias_Nombres = new List<string>();

                // Crear un filtro para obtener todas las instancias de elementos en el modelo
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> allElements = collector.WhereElementIsNotElementType().ToElements();

                HashSet<Category> categoriasConInstancias = new HashSet<Category>();

                // Iterar sobre todos los elementos y agregar sus categorías
                foreach (Element elem in allElements)
                {
                    Category categoria = elem.Category;

                    if (categoria != null && !categoriasConInstancias.Contains(categoria))
                    {
                        categoriasConInstancias.Add(categoria);
                        Lista_Categorias.Add(categoria);
                        Lista_Categorias_Nombres.Add(categoria.Name);
                    }
                }

                // Ordenar la lista alfabéticamente
                List<string> sortedCategoryNames = Lista_Categorias_Nombres.ToList();
                sortedCategoryNames.Sort();

                // (Opcional) Mostrar las categorías en un cuadro de diálogo
                TaskDialog.Show("Categorias con instancias", String.Join("\n", sortedCategoryNames));
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", ex.ToString());
            }
        }
    }
}
