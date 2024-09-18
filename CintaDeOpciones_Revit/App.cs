
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Runtime.Serialization;

using CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables;
using CintaDeOpciones_Revit._1_PanelWPF_1;


namespace CintaDeOpciones_Revit
{
    internal class App : IExternalApplication
    {
        internal static App thisApp = null;

        internal UIApplication uiapp = null;
        internal UIDocument uidoc = null;
        internal Autodesk.Revit.ApplicationServices.Application app = null;
        internal Document doc = null;

        internal static WPF_Boton_1_Formulario WPF_Boton_1_Formulario { get; set; }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                thisApp = this; 

                _0_CintaDeOpciones._0_CintaDeOpciones.CrearCintaDeOpciones(application); //bien 

                application.ViewActivated += new EventHandler<ViewActivatedEventArgs>(OnViewActivated); 

                application.ViewActivated += (sender, e) =>
                {
                    uiapp = sender as UIApplication;
                    doc = e.Document;

                    // Activa los eventos que permiten acotar automaticamente o re-acotar automaticamente
                    uiapp.Application.DocumentChanged += new EventHandler<Autodesk.Revit.DB.Events.DocumentChangedEventArgs>(_02_Eventos_En_Desarrollo.Funciones_Eventos_1.Evento_TD);
                }; 

                RequestHandler handler = new RequestHandler(); 
                ExternalEvent exEvent = ExternalEvent.Create(handler); 


                WPF_Boton_1_Formulario = new WPF_Boton_1_Formulario(exEvent, handler);

                // Configuración del DockablePaneProviderData
                DockablePaneProviderData data = new DockablePaneProviderData
                {
                    FrameworkElement = WPF_Boton_1_Formulario as System.Windows.FrameworkElement,
                    InitialState = new DockablePaneState
                    {
                        DockPosition = DockPosition.Tabbed,
                        TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
                    }
                };

                // Registro de la ventana acoplable
                RegisterDockableWindow(application, new Guid("{6f6fe7f8-1f07-4189-8692-7064b5020450}"), WPF_Boton_1_Formulario);

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error OnStartup", "Error en función OnStartup \n" + ex.Message);
                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            application.ViewActivated -= OnViewActivated;

            // Desregistrar el evento OnViewActivated
            application.ViewActivated -= new EventHandler<ViewActivatedEventArgs>(OnViewActivated);
            if (uiapp != null)
            {
                // Desactiva los eventos que permiten acotar automaticamente cuando se cierra Revit
                uiapp.Application.DocumentChanged -= new EventHandler<Autodesk.Revit.DB.Events.DocumentChangedEventArgs>(_02_Eventos_En_Desarrollo.Funciones_Eventos_1.Evento_TD);
            }
            return Result.Succeeded;
        }

        void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
            try
            {
                // Actualizar las referencias de uiapp y doc
                // Cada vez que se activa una vista nueva, ¿Se actualizan estos valores?
                uiapp = sender as UIApplication;
                doc = e.Document;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error OnViewActivated", "Error en OnViewActivated \n" + ex.Message);
            }
        }

        public void RegisterDockableWindow(UIControlledApplication application, Guid mainPageGuid, IDockablePaneProvider PaneProvider)
        {

            try
            {
                // Crear y registrar el DockablePaneId
                DockablePaneId sm_UserDockablePaneId = new DockablePaneId(mainPageGuid);
                application.RegisterDockablePane(sm_UserDockablePaneId, "WPF_Boton", PaneProvider);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error RegisterDockableWindow", "Error en RegisterDockableWindow \n" + ex.Message);
            }
        }

    }

}

