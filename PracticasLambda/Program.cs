using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasLambda
{
    class Program
    {
        class Documento
        {
            public string Titulo { get; set; }
            public string Cuerpo { get; set; }
            public List<Firmante> Firmantes { get; set; }
        }
        class Firmante
        {
            public string Nombre { get; set; }
            public string Firma { get; set; }
            public int Edad { get; set; }
        }
        static void Main(string[] args)
        {
        }
        static bool FirmanteMayor (Documento documento)
        {
            bool contieneMayor = false;
            foreach (var persona in documento.Firmantes)
            {
                if (true)
                {
                    contieneMayor = true;
                }
            }
            return contieneMayor; 
        }
        Documento GenerarDocumentoAleatorioCon5Firmantes()
        {
        }
        Firmante GenerarFirmanteAleatorio()
        {
            var firmante = new Firmante();
            var aleatorio = new Random();
            firmante.Nombre = aleatorio.Next(0, 100).ToString();
            firmante.Firma = aleatorio.Next(0, 100).ToString();
            firmante.Edad = aleatorio.Next(10, 70);
            return firmante;
        }
    }
}
