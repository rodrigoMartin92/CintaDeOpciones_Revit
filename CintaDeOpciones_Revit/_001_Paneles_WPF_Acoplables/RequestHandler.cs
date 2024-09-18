
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CintaDeOpciones_Revit;
using System.Reflection.Emit;

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
                            _001_Paneles_WPF_Acoplables.Funciones_WPF.TaskDialog_Test();

                            break;
                        }

                    case RequestId.EventoAutomatico_1:
                        {
                            TaskDialog.Show("EventoAutomatico_1", "EventoAutomatico_1");
                            _001_Paneles_WPF_Acoplables.Funciones_WPF.TaskDialog_Test();

                            break;
                        }


                    case RequestId.Agregar_Categorias_Existentes_Instancias:
                        {
                            _001_Paneles_WPF_Acoplables.Funciones_WPF.AgregarCategorias(doc);


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
