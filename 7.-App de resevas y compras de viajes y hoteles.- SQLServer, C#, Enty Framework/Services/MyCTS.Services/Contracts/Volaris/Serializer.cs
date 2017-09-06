using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace MyCTS.Services.Contracts.Volaris
{
    public static class Serializer
    {

        public static void Serialize(string fileName, object objectToSerialize)
        {
            try
            {
                //var xmlFile = new FileStream(fileName + DateTime.Now.ToString("ddMMMyy-HH-mm",new CultureInfo("es-mx")) + ".xml", FileMode.Create);
                //var serializer = new XmlSerializer(objectToSerialize.GetType());

                //serializer.Serialize(xmlFile, objectToSerialize);
                //xmlFile.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
