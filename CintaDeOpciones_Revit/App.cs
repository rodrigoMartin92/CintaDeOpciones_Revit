
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;

using CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables;
using CintaDeOpciones_Revit._1_PanelWPF_1;
using CintaDeOpciones_Revit._2_PanelWPF_2;
using CintaDeOpciones_Revit._3_PanelWPF_3;
using CintaDeOpciones_Revit._4_PanelWPF_4;
using System.Windows;



namespace CintaDeOpciones_Revit
{
    internal class App : IExternalApplication
    {
        internal static App thisApp = null;
        internal UIApplication uiapp = null;
        internal Document doc = null;

        internal WPF_Boton_1_Formulario WPF_Boton_1_Formulario = null;
        internal WPF_Boton_2_Formulario WPF_Boton_2_Formulario = null;
        internal WPF_Boton_3_Formulario WPF_Boton_3_Formulario = null;
        internal WPF_Boton_4_Formulario WPF_Boton_4_Formulario = null;

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                _0_CintaDeOpciones._0_CintaDeOpciones.CrearCintaDeOpciones(application);
                thisApp = this;

                application.ViewActivated += OnViewActivated;

                RequestHandler handler = new RequestHandler();
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                InitializeFormularios(exEvent, handler);

                RegisterDockableWindows(application);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error CrearCintaDeOpciones", "Error en función CrearCintaDeOpciones \n" + ex.Message);
                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            application.ViewActivated -= OnViewActivated;
            return Result.Succeeded;
        }

        private void InitializeFormularios(ExternalEvent exEvent, RequestHandler handler)
        {
            WPF_Boton_1_Formulario = new WPF_Boton_1_Formulario(exEvent, handler);
            WPF_Boton_2_Formulario = new WPF_Boton_2_Formulario(exEvent, handler);
            WPF_Boton_3_Formulario = new WPF_Boton_3_Formulario(exEvent, handler);
            WPF_Boton_4_Formulario = new WPF_Boton_4_Formulario(exEvent, handler);
        }

        private void RegisterDockableWindows(UIControlledApplication application)
        {
            thisApp.RegisterDockableWindow(application, new Guid("{6f6fe7f8-1f07-4189-8692-7064b5020450}"), "WPF_Boton_1_Formulario", WPF_Boton_1_Formulario);
            thisApp.RegisterDockableWindow(application, new Guid("{2eae0d32-b6d3-4dc8-b297-d887a5bbe635}"), "WPF_Boton_2_Formulario", WPF_Boton_2_Formulario);
            thisApp.RegisterDockableWindow(application, new Guid("{4cea362d-1644-4afe-8eb6-e01122d351a8}"), "WPF_Boton_3_Formulario", WPF_Boton_3_Formulario);
            thisApp.RegisterDockableWindow(application, new Guid("{2cf49925-b5cc-476f-afff-93ae99de48b5}"), "WPF_Boton_4_Formulario", WPF_Boton_4_Formulario);
        }

        public void RegisterDockableWindow<T>(UIControlledApplication application, Guid mainPageGuid, string WPF_Boton, T WPF_Formulario) where T : FrameworkElement
        {
            DockablePaneId sm_UserDockablePaneId = new DockablePaneId(mainPageGuid);
            application.RegisterDockablePane(sm_UserDockablePaneId, WPF_Boton, (IDockablePaneProvider)WPF_Formulario);
        }

        void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
            uiapp = sender as UIApplication;
            doc = e.Document;
        }
    }

}

