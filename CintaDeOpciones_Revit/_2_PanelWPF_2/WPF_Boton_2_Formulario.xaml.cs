using Autodesk.Revit.Creation;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

using CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables;

namespace CintaDeOpciones_Revit._2_PanelWPF_2
{
    public partial class WPF_Boton_2_Formulario : Page, IDockablePaneProvider
    {
        #region dock Seccion añadida al SDK
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Tabbed,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
            };
        }
        #endregion

        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        UIApplication uiapp;
        UIDocument uidoc;
        Autodesk.Revit.ApplicationServices.Application app;
        Autodesk.Revit.DB.Document doc;

        public WPF_Boton_2_Formulario(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();

            m_Handler = handler;
            m_ExEvent = exEvent;


        }
    }
}