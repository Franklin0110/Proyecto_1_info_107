using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProyectoN1
{
    public class ManejoXML<T>
    {
        private string _filePath;

        public ManejoXML(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> Cargar()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
            {
                return (List<T>)serializer.Deserialize(fileStream);
            }
        }

        public void Guardar(List<T> datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, datos);
            }
        }
    }
}