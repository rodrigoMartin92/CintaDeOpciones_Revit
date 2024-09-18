
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Creation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.Attributes;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;


using CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables;


namespace CintaDeOpciones_Revit._02_Eventos_En_Desarrollo
{
    internal class Funciones_Eventos_1
    {
        internal static void Evento_TD(object sender, Autodesk.Revit.DB.Events.DocumentChangedEventArgs e)
        {
            try
            {
                Autodesk.Revit.DB.Document doc = e.GetDocument();

                if (App.WPF_Boton_1_Formulario != null)
                {
                    App.WPF_Boton_1_Formulario.MakeRequest(RequestId.Agregar_Categorias_Existentes_Instancias);
                }
                

                TaskDialog.Show("Evento_TD_ 1", "Evento_TD _1");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error Evento_TD", "Error en Evento_TD \n" + ex.Message);
            }
        }

    }

}
