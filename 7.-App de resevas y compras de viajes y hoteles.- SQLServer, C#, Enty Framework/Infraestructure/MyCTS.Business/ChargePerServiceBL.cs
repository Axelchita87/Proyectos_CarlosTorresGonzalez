using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ChargePerServiceBL
    {
        public static List<ChargePerService> GetChargePerService(string StrToSearch)
        {
            List<ChargePerService> ChargePerServiceList = new List<ChargePerService>();
            ChargePerServiceDAL objChargePerService = new ChargePerServiceDAL();
            try
            {
                try
                {
                    ChargePerServiceList = objChargePerService.GetChargePerService(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    ChargePerServiceList = objChargePerService.GetChargePerService(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }
            return ChargePerServiceList;
        }

        //private static List<ListItem> GetMinElements(string StrToSearch)
        //{
        //    if (ObjectsBL.ListChargePerServiceMin == null)
        //    {
        //        ObjectsBL.ListChargePerServiceMin = new List<ListItem>();
        //        string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CHARGEPERSERVICE_FILENAME;
        //        XmlTextReader reader = new XmlTextReader(pathfile);

        //        while (reader.Read())
        //        {
        //            if (reader.NodeType == XmlNodeType.Element)
        //            {
        //                if (reader.HasAttributes)
        //                {
        //                    ListItem li = new ListItem();
        //                    reader.MoveToFirstAttribute();
        //                    li.Value = reader.Value.Trim(new char[] { '$' });
        //                    reader.MoveToNextAttribute();
        //                    li.Text = reader.Value;
        //                    //reader.MoveToNextAttribute();
        //                    //li.Text2 = reader.Value.Trim(new char[]{'$'});
        //                    ObjectsBL.ListChargePerServiceMin.Add(li);
        //                }
        //            }
        //        }
        //    }

        //    return ObjectsBL.ListChargePerServiceMin.FindAll(delegate(ListItem li)
        //    { return (li.Value.StartsWith(StrToSearch)); });
        //}
        //private static List<ListItem> GetMajElements(string StrToSearch)
        //{
        //    if (ObjectsBL.ListChargePerServiceMaj == null)
        //    {
        //        ObjectsBL.ListChargePerServiceMaj = new List<ListItem>();
        //        string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CHARGEPERSERVICE_FILENAME;
        //        XmlTextReader reader = new XmlTextReader(pathfile);

        //        while (reader.Read())
        //        {
        //            if (reader.NodeType == XmlNodeType.Element)
        //            {
        //                if (reader.HasAttributes)
        //                {
        //                    ListItem li = new ListItem();
        //                    reader.MoveToFirstAttribute();
        //                    li.Value = reader.Value; //IDChargePerService
        //                    reader.MoveToNextAttribute();
        //                    li.Text = reader.Value; //Import + ' ' + IDChargePerService + ' ' + [Description]
        //                    reader.MoveToNextAttribute();
        //                    li.Text2 = reader.Value; //Import
        //                    reader.MoveToNextAttribute();
        //                    li.Text3 = reader.Value; //[Description]
        //                    ObjectsBL.ListChargePerServiceMaj.Add(li);
        //                }
        //            }
        //        }
        //    }

        //    //Busca por IdChargePerService
        //    return ObjectsBL.ListChargePerServiceMaj.FindAll(delegate(ListItem li)
        //    { return ((li.Text2.StartsWith(StrToSearch)) | (li.Text3.StartsWith(StrToSearch))); });
        //}

        //public static List<ListItem> GetChargePerService_Predictive(string StrToSearch)
        //{
        //    if (StrToSearch.Length > 0)
        //        return GetMinElements(StrToSearch);
        //    else
        //        return GetMajElements(StrToSearch);
        //}

    }
}
