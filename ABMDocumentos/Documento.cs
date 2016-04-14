using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public class Documento
    {
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public List<Firmante> Firmantes { get; set; }
    }
}
