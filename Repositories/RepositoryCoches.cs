using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WFCLogicaCoches.Models;

namespace WFCLogicaCoches.Repositories
{
    public class RepositoryCoches
    {
        private XDocument document;

        public RepositoryCoches()
        {
            //NAMESPACE/CARPETA/DOCUMENTO
            string resourceName = "WFCLogicaCoches.coches.xml";
            Stream stream = this.GetType().Assembly
                .GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<Coche> GetCoches()
        {
            var consulta = from datos in document.Descendants("coche")
                           select new Coche()
                           {
                               IdCoche = int.Parse(datos.Element("idcoche").Value),
                               Marca = datos.Element("marca").Value,
                               Modelo = datos.Element("modelo").Value,
                               Imagen = datos.Element("imagen").Value
                           };
            return consulta.ToList();
        }

        public Coche FindCoche(int idcoche)
        {
            return this.GetCoches().FirstOrDefault(x => x.IdCoche == idcoche);
        }

    }
}
