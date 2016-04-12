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
            var documentos = new List<Documento>();
            for (int i = 0; i < 10; i++)
            {
                documentos.Add(GenerarDocumentoAleatorioCon5Firmantes());
            }
            var documentosConMayores = documentos.FindAll((Documento doc) =>
            {
                bool contieneMayor = false;
                foreach (var persona in doc.Firmantes)
                {
                    if (persona.Edad >= 18) contieneMayor = true;
                }
                return contieneMayor;
            });
        }
        void escribirDocumentosConsola (List<Documento> documentos)
        {
            string resultado = "";
            foreach (var documento in documentos)
            {
                resultado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "Firmantes: ";
                foreach (var firmante in documento.Firmantes)
                {
                    resultado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad" + firmante.Edad.ToString();
                }
            }
        }
        /* funcion que devuelve si el documento tiene un firmante mayor
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
        }*/
        #region Aleatorios
        static Documento GenerarDocumentoAleatorioCon5Firmantes()
        {
            var documento = new Documento();
            documento.Titulo = GenerarStringAleatorio();
            documento.Cuerpo = GenerarStringAleatorio();
            var firmantes = new List<Firmante>();
            for (int i = 0; i < 5; i++)
            {
                firmantes.Add(GenerarFirmanteAleatorio());
            }
            documento.Firmantes = firmantes;
            return documento;
        }
        static Firmante GenerarFirmanteAleatorio()
        {
            var firmante = new Firmante();
            firmante.Nombre = GenerarStringAleatorio();
            firmante.Firma = GenerarStringAleatorio();
            var random = new Random();
            firmante.Edad = random.Next(10, 70);
            return firmante;
        }
        static string GenerarStringAleatorio()
        {
            var random = new Random(); //random que voy a usar en toda la funcion
            string stringAleatorio = ""; //el nuevo string que voy a generar (return)
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; //los caracters que puede llevar
            int cantCaracteres = caracteres.Length; //el numero de caracteres que uso
            char letra; //la letra que voy a agregar a mi nueva palabra
            int cantStringAleatorio = random.Next(1,10); //el maximo de letras que le voy a poner a mi nueva palabra
            for (int i = 0; i < cantStringAleatorio; i++)
            {
                letra = caracteres[random.Next(cantCaracteres)];
                stringAleatorio += letra.ToString();
            }
            return stringAleatorio;
        }
        #endregion
    }
}