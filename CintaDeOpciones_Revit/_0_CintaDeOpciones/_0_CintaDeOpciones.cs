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
                string panelName3 = "Panel 3_";
                string panelName4 = "Panel 4_";
                string Iconos = "C:\\Users\\ASUS\\Dropbox\\1 - Arquitectura\\2 - Plug-ins - AutoPropaganda\\_0_Cinta_De_Opciones_Acoplable_WPF\\CintaDeOpciones_Revit\\CintaDeOpciones_Revit\\Imagenes\\Iconos\\";

                application.CreateRibbonTab(tabName);
                RibbonPanel Cinta_1 = application.CreateRibbonPanel(tabName, panelName1);
                RibbonPanel Cinta_2 = application.CreateRibbonPanel(tabName, panelName2);
                RibbonPanel Cinta_3 = application.CreateRibbonPanel(tabName, panelName3);
                RibbonPanel Cinta_4 = application.CreateRibbonPanel(tabName, panelName4);
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
                PulldownButton PulldownButton_1_2 = Cinta_2.AddItem(new PulldownButtonData("PulldownButton_2", "Cinta_2")) as PulldownButton;
                PulldownButton_1_2.LargeImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));

                // Botón LECTURA de datos 1
                PushButton PushButtonCinta_1_2 = PulldownButton_1_2.AddPushButton(new PushButtonData("boton 2", "Boton 2", Path,
                    "CintaDeOpciones_Revit._2_PanelWPF_2.WPF_Boton_2"));
                PushButtonCinta_1_2.LongDescription = "PushButton_2";
                PushButtonCinta_1_2.LargeImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));
                PushButtonCinta_1_2.ToolTipImage = new BitmapImage(new Uri(Iconos + "iconA2.png"));

                // Cinta 3
                PulldownButton PulldownButton_1_3 = Cinta_3.AddItem(new PulldownButtonData("PulldownButton_3", "Cinta_3")) as PulldownButton;
                PulldownButton_1_3.LargeImage = new BitmapImage(new Uri(Iconos + "iconA3.png"));  // Corregir a PulldownButton_1_3


                // Botón LECTURA de datos 1
                PushButton PushButtonCinta_1_3 = PulldownButton_1_3.AddPushButton(new PushButtonData("boton 3", "Boton 3", Path,
                    "CintaDeOpciones_Revit._3_PanelWPF_3.WPF_Boton_3"));
                PushButtonCinta_1_3.LongDescription = "PushButton_3";
                PushButtonCinta_1_3.LargeImage = new BitmapImage(new Uri(Iconos + "iconA3.png"));
                PushButtonCinta_1_3.ToolTipImage = new BitmapImage(new Uri(Iconos + "iconA3.png"));

                // Cinta 4
                PulldownButton PulldownButton_1_4 = Cinta_4.AddItem(new PulldownButtonData("PulldownButton_4", "Cinta_4")) as PulldownButton;
                PulldownButton_1_4.LargeImage = new BitmapImage(new Uri(Iconos + "iconA4.png"));  // Corregir a PulldownButton_1_4

                // Botón LECTURA de datos 1
                PushButton PushButtonCinta_1_4 = PulldownButton_1_4.AddPushButton(new PushButtonData("boton 4", "Boton 4", Path,
                    "CintaDeOpciones_Revit._4_PanelWPF_4.WPF_Boton_4"));
                PushButtonCinta_1_4.LongDescription = "PushButton_4";
                PushButtonCinta_1_4.LargeImage = new BitmapImage(new Uri(Iconos + "iconA4.png"));
                PushButtonCinta_1_4.ToolTipImage = new BitmapImage(new Uri(Iconos + "iconA4.png"));

            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario
                TaskDialog.Show("Error en función", ex.Message);
            }

        }
    }
}
