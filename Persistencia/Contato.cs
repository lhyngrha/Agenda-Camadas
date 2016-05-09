using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Contato
    {
        private string arquivo = "C:\\Users\\20131011110029\\Documents\\Visual Studio 2015\\Projects\\agenda.xml";

        public void Insert(Modelo.Contato c)
        {
            List<Modelo.Contato> agenda = abrirArquivo();
            //Adicionou o objeto a lista agenda
            agenda.Add(c);
            salvarArquivo(agenda);
        }

        public List<Modelo.Contato> Select()
        {
            return abrirArquivo();
        }

        private List<Modelo.Contato> abrirArquivo()
        {
            List<Modelo.Contato> result = null;
            try {
                using (StreamReader sr = new StreamReader(arquivo))
                {

                    //Serializou um arquivo para XML
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Contato>));
                    //Transforma de XML para lista
                    result = (List<Modelo.Contato>)xml.Deserialize(sr);
                } }
            catch
            {
                result = new List<Modelo.Contato>();
            }
            return result;
            
        }

        private void salvarArquivo(List<Modelo.Contato> agenda)
        {
            StreamWriter sw = new StreamWriter(arquivo);
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Contato>));
            //Serializa os arquivo de agenda em sw
            xml.Serialize(sw, agenda);
            sw.Close();
        }
    }
}
