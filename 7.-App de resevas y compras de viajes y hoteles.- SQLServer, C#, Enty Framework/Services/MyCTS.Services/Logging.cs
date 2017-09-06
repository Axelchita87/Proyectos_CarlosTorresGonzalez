using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Logging
{
    public Logging()
    {

    }

    public Logging(object objetoLogginVolaris)
    {
        SerializarRespuesta(objetoLogginVolaris);
    }

    /// <summary>
    /// Descomentar cuando se de seguimiento a los mensajes enviados hacia CTS.Services
    /// </summary>
    /// <param name="objetoASerializar"></param>
    private void SerializarRespuesta(object objetoASerializar)
    {
        //try
        //{
        //    System.Xml.Serialization.XmlSerializer writer2 = new System.Xml.Serialization.XmlSerializer(objetoASerializar.GetType());
        //    System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\RESP\Volaris" + objetoASerializar.GetType().Name + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml");
        //    writer2.Serialize(file, objetoASerializar);
        //    file.Close();
        //}
        //catch (Exception ex)
        //{
        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"c:\RESP\ErrorAlSerializar.txt", true))
        //    {
        //        sw.WriteLine(ex.ToString());
        //        sw.WriteLine("------------" + DateTime.Now.ToString() + "------------");
        //    }
        //}
    }
}
