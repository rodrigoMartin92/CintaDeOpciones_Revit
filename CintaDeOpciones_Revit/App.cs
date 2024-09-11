#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

#endregion

namespace CintaDeOpciones_Revit
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                // Inicialización de la cinta de opciones
                _0_CintaDeOpciones._0_CintaDeOpciones.CrearCintaDeOpciones(application);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error CrearCintaDeOpciones", "Error en función CrearCintaDeOpciones \n" + ex.Message);
            }
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
