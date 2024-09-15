
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
