
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CintaDeOpciones_Revit;
using System.Reflection.Emit;

using CintaDeOpciones_Revit._2_Funciones_En_Desarrollo;
using CintaDeOpciones_Revit._1_PanelWPF_1;


namespace CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables
{

    public class RequestHandler : IExternalEventHandler
    {
        // A trivial delegate, but handy
        private delegate void DoorOperation(FamilyInstance e);

        // The value of the latest request made by the modeless form 
        private Request m_request = new Request();

        public Request Request
        {
            get { return m_request; }
        }

        public String GetName()
        {
            return "R2022 External Event Sample";
        }
        
        public void Execute(UIApplication uiapp)
        {

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  // no request at this time -> we can leave immediately
                        }
                    case RequestId.EventoManual_1:
                        {
                            TaskDialog.Show("EventoManual_1", "EventoManual_1");
                            _2_Funciones_WPF_1.Funcion_A_Definir();

                            break;
                        }

                    case RequestId.EventoAutomatico_1:
                        {
                            TaskDialog.Show("EventoManual_1", "EventoManual_1");
                            _2_Funciones_WPF_1.Funcion_A_Definir();

                            break;
                        }


                    case RequestId.Agregar_Categorias_Existentes_Instancias:
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


                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }

            catch (Exception ex)
            {
                TaskDialog.Show("RequestHandler.Execute()", ex.ToString());
            }
            return;
        }
    }
}
