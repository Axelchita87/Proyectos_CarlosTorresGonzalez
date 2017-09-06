using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public class Productivity
    {
        private static ProductivityProxy.ProductivityService objProdService;
        private static ProductivityProxyDev.ProductivityService objProdServiceDev;

        private static ProductivityProxy.ProductivityService ProdService
        {
            get
            {
                try
                {
                    if (objProdService == null)
                        objProdService = new ProductivityProxy.ProductivityService();
                }
                catch { }

                return objProdService;
            }
        }

        private static ProductivityProxyDev.ProductivityService ProdServiceDev
        {
            get
            {
                    try
                    {
                        if (objProdServiceDev == null)
                            objProdServiceDev = new ProductivityProxyDev.ProductivityService();
                    }
                    catch { }
                
                return objProdServiceDev;
            }
        }


        public static DateTime GetCurrentDateTime()
        {
            DateTime currentDT;

            try
            {
                
                currentDT = ProdService.GetServerDateTime();
            }
            catch
            {
                try
                {
                    currentDT = ProdServiceDev.GetServerDateTime();
                }

                catch 
                {
                    currentDT = DateTime.Now;
                }
            }

            return currentDT;
        }


        public static bool AddCommandsTransaction(Byte[] fileBinaryArray)
        {
            bool result = false;

            try 
            {
                ProdService.AddCommandsTransaction(fileBinaryArray);
                result = true;
            }
            catch
            {
                try
                {
                    ProdServiceDev.AddCommandsTransaction(fileBinaryArray);
                    result = true;

                }
                catch
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
