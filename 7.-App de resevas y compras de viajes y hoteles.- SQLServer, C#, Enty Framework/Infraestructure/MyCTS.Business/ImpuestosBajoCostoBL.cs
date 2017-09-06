using MyCTS.DataAccess;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Business
{
    public class ImpuestosBajoCostoBL
    {
        public static void InsertImpuestosBajoCosto(string id, string impuestosObtenidos, string pnrBajoCosto, string impuestosMostrados, string lineaContable, string pnrSabre)
        {
            ImpuestosBajoCostoDAL objImpuestos = new ImpuestosBajoCostoDAL();
            try
            {
                objImpuestos.InsertImpuestosBajoCosto(id, impuestosObtenidos,pnrBajoCosto,impuestosMostrados,lineaContable,pnrSabre, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                try
                {
                    objImpuestos.InsertImpuestosBajoCosto(id, impuestosObtenidos, pnrBajoCosto, impuestosMostrados, lineaContable, pnrSabre, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
                catch
                {
                    throw ex;
                }
            }
        }


        public static void UpdateImpuestosBajoCosto(string id, string impuestosObtenidos, string pnrBajoCosto, string impuestosMostrados, string lineaContable, string pnrSabre)
        {
            ImpuestosBajoCostoDAL objImpuestos = new ImpuestosBajoCostoDAL();

            try
            {
                objImpuestos.UpdateImpuestosBajoCosto(id,impuestosObtenidos, pnrBajoCosto, impuestosMostrados, lineaContable, pnrSabre, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                try
                {
                    objImpuestos.UpdateImpuestosBajoCosto(id, impuestosObtenidos, pnrBajoCosto, impuestosMostrados, lineaContable, pnrSabre, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
                catch
                {
                    throw ex;
                }
            }
        }
    }
}
