using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Configuration;

namespace ADMIN2.Controls
{
    public class CatalogSection : ConfigurationSection
    {

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public CatalogCollection Catalogos
        {
            get
            {
               // System.Diagnostics.Debugger.Launch();
                CatalogCollection CatalogCollection = (CatalogCollection)base[""];

                return CatalogCollection;

            }
        }

    }

    public class CatalogCollection : ConfigurationElementCollection
    {
        public CatalogCollection()
        {
            CatalogConfigElement details = (CatalogConfigElement)CreateNewElement();
            if (details.Nombre != "")
            {
                Add(details);
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CatalogConfigElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((CatalogConfigElement)element).Nombre;
        }

        public CatalogConfigElement this[int index]
        {
            get
            {
                return (CatalogConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public CatalogConfigElement this[string name]
        {
            get
            {
                return (CatalogConfigElement)BaseGet(name);
            }
        }

        public int IndexOf(CatalogConfigElement details)
        {
            return BaseIndexOf(details);
        }

        public void Add(CatalogConfigElement details)
        {
            BaseAdd(details);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(CatalogConfigElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.Nombre);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override string ElementName
        {
            get { return "Catalogo"; }
        }
    }

    public class CatalogConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Metodo", IsRequired = true, IsKey = false)]
        public string Metodo
        {
            get { return (string)this["Metodo"]; }
            set { this["Metodo"] = value; }
        }

        [ConfigurationProperty("MetodoBorrar", IsRequired = false, IsKey = false)]
        public string MetodoBorrar
        {
            get { return (string)this["MetodoBorrar"]; }
            set { this["MetodoBorrar"] = value; }
        }

        [ConfigurationProperty("InitBinding", IsRequired = true, IsKey = false)]
        public string InitBinding
        {
            get { return (string)this["InitBinding"]; }
            set { this["InitBinding"] = value; }
        }

        [ConfigurationProperty("InitSort", IsRequired = true, IsKey = false)]
        public string InitSort
        {
            get { return (string)this["InitSort"]; }
            set { this["InitSort"] = value; }
        }

        [ConfigurationProperty("Nombre", IsRequired = true, IsKey = true)]
        public string Nombre
        {
            get { return (string)this["Nombre"]; }
            set { this["Nombre"] = value; }
        }

        [ConfigurationProperty("Altas", IsRequired = false, IsKey = false,DefaultValue=true)]
        public bool Altas
        {
            get { return (bool)this["Altas"]; }
            set { this["Altas"] = value; }
        }

        [ConfigurationProperty("Bajas", IsRequired = false, IsKey = false, DefaultValue = true)]
        public bool Bajas
        {
            get { return (bool)this["Bajas"]; }
            set { this["Bajas"] = value; }
        }

        [ConfigurationProperty("Cambios", IsRequired = false, IsKey = false, DefaultValue = true)]
        public bool Cambios
        {
            get { return (bool)this["Cambios"]; }
            set { this["Cambios"] = value; }
        }

        [ConfigurationProperty("Mostrar", IsRequired = false, IsKey = false)]
        public bool Mostrar
        {
            get { return (bool)this["Mostrar"]; }
            set { this["Mostrar"] = value; }
        }

        [ConfigurationProperty("Columnas", IsDefaultCollection = false)]
        public ColumnCollection Columnas
        {
            get { return (ColumnCollection)base["Columnas"]; }

        }
    }

    public class ColumnCollection : ConfigurationElementCollection
    {

        public new ColumnConfigElement this[string name]
        {
            get
            {
                if (IndexOf(name) < 0) return null;

                return (ColumnConfigElement)BaseGet(name);
            }
        }

        public ColumnConfigElement this[int index]
        {
            get { return (ColumnConfigElement)BaseGet(index); }
        }

        public int IndexOf(string name)
        {
            name = name.ToLower();

            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Name.ToLower() == name)
                    return idx;
            }
            return -1;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ColumnConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ColumnConfigElement)element).Name;
        }

        protected override string ElementName
        {
            get { return "Columna"; }
        }

    }

    public class ColumnConfigElement : ConfigurationElement
    {

        public ColumnConfigElement()
        {
        }

        public ColumnConfigElement(string name, string binding, bool resize, bool sort, int size)
        {
            this.Binding = binding;
            this.Name = name;
            this.Resize = resize;
            this.Sort = sort;
            this.Size = size;
        }

        [ConfigurationProperty("Name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Binding", IsRequired = true, DefaultValue = "")]
        public string Binding
        {
            get { return (string)this["Binding"]; }
            set { this["Binding"] = value; }
        }

        [ConfigurationProperty("Resize", IsRequired = false, DefaultValue = true)]
        public bool Resize
        {
            get { return (bool)this["Resize"]; }
            set { this["Resize"] = value; }
        }

        [ConfigurationProperty("Sort", IsRequired = false, DefaultValue = true)]
        public bool Sort
        {
            get { return (bool)this["Sort"]; }
            set { this["Sort"] = value; }
        }

        [ConfigurationProperty("Size", IsRequired = false, DefaultValue = 70)]
        public int Size
        {
            get { return (int)this["Size"]; }
            set { this["Size"] = value; }
        }

        [ConfigurationProperty("TextAlign", IsRequired = false, DefaultValue = "Left")]
        public string TextAlign
        {
            get { return (string)this["TextAlign"]; }
            set { this["TextAlign"] = value; }
        }

        [ConfigurationProperty("TextFormat", IsRequired = false, DefaultValue = "")]
        public string TextFormat
        {
            get { return (string)this["TextFormat"]; }
            set { this["TextFormat"] = value; }
        }
    }

    public class SITAConfig
    {
        public static CatalogConfigElement GetConfigCatalogo(string catalogo)
        {
            CatalogSection catalogos = new CatalogSection();
            try
            {
                //  System.Diagnostics.Debugger.Launch();
                var map = new ExeConfigurationFileMap();

                Utils get = new Utils();
                map.ExeConfigFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, ConfigurationManager.AppSettings["catalogConfig"]);
                //map.ExeConfigFilename = get.AbrirArchivoIncrustado(ConfigurationManager.AppSettings["catalogConfig"], true);
                var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                //Toma los elementos del archivo AppCatalogs.Config que usará para llenar el grid
                catalogos = config.GetSection("CatalogSection") as CatalogSection;

                return catalogos.Catalogos[catalogo];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ConfigCatalogo");
            }
            return catalogos.Catalogos[catalogo]; ;
        }
    }
}
