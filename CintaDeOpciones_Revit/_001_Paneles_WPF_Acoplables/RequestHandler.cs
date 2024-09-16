
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CintaDeOpciones_Revit;
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
                            // Otros eventos que se pueden agregar a futuro
                            TaskDialog.Show("Evento 1", "Evento 1");

                            break;
                        }
                    case RequestId.EventoManual_2:
                        {
                            // Otros eventos que se pueden agregar a futuro
                            TaskDialog.Show("Evento 2", "Evento 2");

                            break;
                        }
                    case RequestId.EventoManual_3:
                        {
                            // Otros eventos que se pueden agregar a futuro
                            TaskDialog.Show("Evento 3", "Evento 3");

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
