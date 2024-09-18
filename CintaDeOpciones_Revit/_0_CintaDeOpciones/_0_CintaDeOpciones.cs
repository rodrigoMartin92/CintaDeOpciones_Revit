using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace CintaDeOpciones_Revit._0_CintaDeOpciones
{
    internal class _0_CintaDeOpciones
    {
        
        public static void CrearCintaDeOpciones(UIControlledApplication application)
        {

            try
            {

                // CREACION DE LA CINTA DE OPCIONES

                string tabName = "Plug ins - Rodrigo Martin";
                string panelName1 = "Panel 1_";
                string panelName2 = "Panel 2_";
                string Iconos = "C:\\Users\\ASUS\\Dropbox\\1 - Arquitectura\\2 - Plug-ins - AutoPropaganda\\_0_Cinta_De_Opciones_Acoplable_WPF\\CintaDeOpciones_Revit\\CintaDeOpciones_Revit\\Imagenes\\Iconos\\";

                application.CreateRibbonTab(tabName);

                RibbonPanel Cinta_1 = application.CreateRibbonPanel(tabName, panelName1);
                RibbonPanel Cinta_2 = application.CreateRibbonPanel(tabName, panelName2);

                string Path = Assembly.GetExecutingAssembly().Location;

                // Cinta 1
                PulldownButton PulldownButton_1_1 = Cinta_1.AddItem(new PulldownButtonData("PulldownButton_1", "Cinta_1")) as PulldownButton;
                PulldownButton_1_1.LargeImage = new BitmapImage(new Uri(Iconos + "iconA1.png"));

                // Botón LECTURA de datos 1
                PushButton PushButtonCinta_1_1 = PulldownButton_1_1.AddPushButton(new PushButtonData("boton 1", "Boton 1", Path,
                    "CintaDeOpciones_Revit._1_PanelWPF_1.WPF_Boton_1"));
                PushButtonCinta_1_1.LongDescription = "PushButton_1";
                PushButtonCinta_1_1.LargeImage = new BitmapImage(new Uri(Iconos + "iconA1.png"));
                PushButtonCinta_1_1.ToolTipImage = new BitmapImage(new Uri(Iconos + "iconA1.png"));

                // Cinta 2
                PulldownButton PulldownButton_2_1 = Cinta_2.AddItem(new PulldownButtonData("PulldownButton_2", "Cinta_2")) as PulldownButton;
                PulldownButton_2_1.LargeImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));

                // Botón LECTURA de datos 1
                PushButton PushButtonCinta_2_1 = PulldownButton_2_1.AddPushButton(new PushButtonData("boton 2", "Boton 2", Path,
                    "CintaDeOpciones_Revit._2_PanelWPF_2.WPF_Boton_2"));
                PushButtonCinta_2_1.LongDescription = "PushButton_2";
                PushButtonCinta_2_1.LargeImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));
                PushButtonCinta_2_1.ToolTipImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));

            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario
                TaskDialog.Show("Error en función", ex.Message);
            }

        }
    }
}
