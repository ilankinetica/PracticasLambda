using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasLambda
{
    class Program
    {
        public class Documento
        {
            public string Titulo { get; set; }
            public string Cuerpo { get; set; }
            public List<Firmante> Firmantes { get; set; }
        }
        public class Firmante
        {
            public string Nombre { get; set; }
            public string Firma { get; set; }
            public int Edad { get; set; }
        }
        #region Sorting
        public class sortEdadFirmantes : IComparer<Firmante>
        {
            /// <summary>
            /// Compara dos objetos y devuelve un valor que determina el orden alfabetico
            /// </summary>
            /// <param name="x">Primer objeto a comparar</param>
            /// <param name="y">Segundo objeto a comparar</param>
            /// <returns>0 si son iguales, -1 si y es mayor, 1 si x es mayor</returns>
            public int Compare(Firmante x, Firmante y)
            {
                if (x.Edad == y.Edad)
                {
                    return 0;
                }
                else if (x.Edad > y.Edad)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public class sortPrimercaracterDocumentos : IComparer<Documento>
        {
            public int Compare(Documento x, Documento y)
            {
                if (x.Titulo == y.Titulo)
                {
                    return 0;
                }
                var lengthX = x.Titulo.Length;
                var lengthY = y.Titulo.Length;
                int maximo = 0;
                if (lengthX >= lengthY) maximo = lengthY;
                else if (lengthX < lengthY) maximo = lengthX;
                int letra = 0;
                bool palabraDesordenada = true;
                do
                {
                    if (x.Titulo.ToUpper()[letra] > y.Titulo.ToUpper()[letra])
                    {
                        palabraDesordenada = false;
                        return 1;
                    }
                    else if (x.Titulo.ToUpper()[letra] < y.Titulo.ToUpper()[letra])
                    {
                        palabraDesordenada = false;
                        return -1;
                    }
                    letra++;
                } while (palabraDesordenada && letra < maximo);
                if (lengthX >= lengthY) return 1;
                else if (lengthX < lengthY) return -1;
                else return 0;
            }
        }
        #endregion
        static void Main(string[] args)
        {
            EscribeDocumentosConFirmantesMayores();
            EscribeDocumentosConTituloConA();
            EscribeDocumentosConTitulo3Caracteres();
            EscribeSiFirmanteEdad17();
            EscribePrimerDocumentoConCuerpoConAB();
            EscribeDocumentosOrdenadosTituloAlfabeticamnete();
            EscribirUltimoDocumentoConUltimaLetraZ();
            EscribeDocumentosQueContenganMayusculas();
            EscribeOrdenaFirmantesPorEdad();
            EscribeDocumentosTitulosEnMayuscula();
            EscribeTitulos();
            EscribeCualFirmanteEsMayor();
            Console.ReadLine();
        }
        #region Funciones de escritura en la consola
        static string EscribirDocumentosConsola(List<Documento> documentos, string encabezado)
        {
            string resultado = "";
            try
            {
                resultado += encabezado + "\n\n";
                foreach (var documento in documentos)
                {
                    resultado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
                    foreach (var firmante in documento.Firmantes)
                    {
                        resultado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
                    }
                    resultado += "\n----- -----";
                }
                resultado += "\n----- ----- -----\n";
            }

            catch (Exception)
            {
                resultado = "No se pudo procesar esta petición";
            }
            return resultado;
        }
        static string Escribir1DocumentoConosola(Documento documento)
        {
            string resultado = "";
            try
            {
                resultado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
                foreach (var firmante in documento.Firmantes)
                {
                    resultado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
                }
                resultado += "\n----- -----";
            }
            catch (Exception)
            {

                resultado = "No se pudo procesar esta petición";
            }

            return resultado;
        }
        static string Escribir1DocumentoConosola(Documento documento, string encabezado)
        {
            string resultado = "";
            try
            {
                resultado += encabezado + "\n\n";
                resultado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
                foreach (var firmante in documento.Firmantes)
                {
                    resultado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
                }
                resultado += "\n----- -----";
                resultado += "\n----- ----- -----\n";
            }
            catch (Exception)
            {

                resultado = "No se pudo procesar esta petición";
            }

            return resultado;
        }
        static string EscribirFirmantesConsola(List<Firmante> firmantes, string encabezado)
        {
            string resultado = "";
            try
            {
                resultado += encabezado + "\n\n";
                foreach (var firmante in firmantes)
                {
                    resultado += "\nFirmante: \nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString();
                    resultado += "\n----- -----";
                }
                resultado += "\n----- ----- -----\n";
            }
            catch (Exception)
            {

                resultado = "No se pudo procesar esta petición";
            }

            return resultado;
        }
        #endregion
        #region Escribe en la Consola
        static void EscribirUltimoDocumentoConUltimaLetraZ()
        {
            var encabezado = "";
            try
            {
                var documentos = GenerarListaDocumentos(300, 1);
                Documento ultimoDocConUltimaLetraZ = documentos.Last((Documento x) =>
                {
                    bool hayDocumento = false;
                    var longitud = x.Titulo.Length - 1;
                    if (x.Titulo[longitud] == 'Z')
                    {
                        ultimoDocConUltimaLetraZ = x;
                        hayDocumento = true;
                    }
                    else
                    {
                        hayDocumento = false;
                    }
                    return hayDocumento;
                });
                var contador = documentos.Where(x => x.Titulo[x.Titulo.Length - 1] == 'Z').Count();
                encabezado = "MUESTRO ULTIMO DOCUMENTO CON ULTIMA LETRA DE TITULO 'Z'. SE HAN ENCONTRADO " + contador + " DOCUMENTOS CON ULTIMA LETRA 'Z'   ";
                Console.Write(Escribir1DocumentoConosola(ultimoDocConUltimaLetraZ, encabezado));
            }
            catch (InvalidOperationException)
            {
                Console.Write("NO HAY DOCUMENTOS CON ULTIMA LETRA 'Z'");
            }
            catch (Exception)
            {

                Console.Write("NO ES POSIBLE MOSTRAR ULTIMO DOCUMENTO CON ULTIMA LETRA 'Z'");
            }
        }
        static void EscribeDocumentosConFirmantesMayores()
        {
            string encabezado = "";
            var documentosConMayores = new List<Documento>();
            try
            {
                var documentos = GenerarListaDocumentos(5, 5);
                //Separa los documentos que tienen por lo menos un firmante mayor a 18
                documentosConMayores = documentos.FindAll((Documento doc) =>
                {
                    bool contieneMayor = false;
                    foreach (var firmante in doc.Firmantes)
                    {
                        if (firmante.Edad >= 18 && !contieneMayor)
                        {
                            contieneMayor = true;
                            documentosConMayores.Add(doc);
                        }
                    }
                    return contieneMayor;
                });
                encabezado = "MUESTRO DOCUMENTOS CON POR LO MENOS UN FIRMANTE MAYOR A 18 AÑOS DE EDAD";
            }
            catch (Exception)
            {
                encabezado = "NO ES POSIBLE MOSTRAR DOCUMENTOS CON POR LO MENOS UN FIRMANTE MAYOR A 18 AÑOS DE EDAD";

            }

            Console.Write(EscribirDocumentosConsola(documentosConMayores, encabezado));
        }
        static void EscribeSiFirmanteEdad17()
        {
            try
            {
                var documentos = GenerarListaDocumentos(3, 50);
                //Separa firmantes con 17 años
                bool existeFirmanteEdad17 = false;
                List<Firmante> firmantesEdad17 = new List<Firmante>();
                existeFirmanteEdad17 = documentos.Exists((Documento doc) =>
                {
                    foreach (var firmante in doc.Firmantes)
                    {
                        if (firmante.Edad == 17)
                        {
                            existeFirmanteEdad17 = true;
                            firmantesEdad17.Add(firmante);
                        }
                    }
                    return existeFirmanteEdad17;
                });
                string encabezado = "EXISTE FIRMANTE CON 17 AÑOS:" + existeFirmanteEdad17;
                Console.Write(EscribirFirmantesConsola(firmantesEdad17, encabezado));
            }
            catch (Exception)
            {

                Console.Write("NO ES POSIBLE ESCRIBIR FIRMANTES CON 17 AÑOS");
            }

        }
        static void EscribeDocumentosConTituloConA()
        {
            try
            {
                var documentos = GenerarListaDocumentos(20, 5);
                //separa documentos con titulo que contenga A
                var documentosConTituloA = documentos.FindAll(doc => doc.Titulo.Contains("A") == true);
                //Escribe en consola
                string encabezado = "MUESTRO DOCUMENTOS CON TITULO QUE CONTENGA LETRA A";
                Console.Write(EscribirDocumentosConsola(documentosConTituloA, encabezado));
            }
            catch (Exception)
            {

                Console.Write("NO ES POSIBLE MOSTRAR DOCUMENTOS CON TITULO QUE CONTENGA LETRA A");
            }

        }
        static void EscribeDocumentosConTitulo3Caracteres()
        {
            try
            {
                var documentos = GenerarListaDocumentos(20, 2);
                //separa docuemntos con titulo de tres caracteres
                var documentosConTitulo3 = documentos.Where(doc => doc.Titulo.Length == 3).ToList();
                //Escribe en consola
                string encabezado = "MUESTRO DOCUMENTOS CON TITULO DE 3 CARACTERES";
                Console.Write(EscribirDocumentosConsola(documentosConTitulo3, encabezado));
            }
            catch (Exception)
            {
                Console.Write("NO ES POSIBLE MOSTRAR DOCUMENTOS CON TITULO DE 3 CARACTERES");
            }

        }
        static void EscribePrimerDocumentoConCuerpoConAB()
        {
            //carga incial
            var documentos = GenerarListaDocumentos(5000, 1);
            //separar primer documento con abc
            try
            {
                var documentoConAB = documentos.First(doc => doc.Cuerpo.Contains("AB"));
                var contadorConAB = documentos.Where(doc => doc.Cuerpo.Contains("AB")).Count();
                //escribe en consola
                string encabezado = "MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB. TOTAL CUERPO CON AB: " + contadorConAB.ToString();
                Console.Write(Escribir1DocumentoConosola(documentoConAB, encabezado));
            }
            catch
            {
                Console.Write("MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB\nNo hay ningun documento con cuerpo que contenga AB");
            }
        }
        static void EscribeDocumentosOrdenadosTituloAlfabeticamnete()
        {
            try
            {
                var documentos = GenerarListaDocumentos(10, 1);
                //ordena alfabeticamente
                sortPrimercaracterDocumentos ordenar = new sortPrimercaracterDocumentos();
                documentos.Sort(ordenar);
                //escribe en consola
                string encabezado = "ORDENO DOCUMENTOS POR TITULO ALFABETICAMENTE";
                Console.Write(EscribirDocumentosConsola(documentos, encabezado));
            }
            catch (Exception)
            {

                Console.Write("NO ES POSIBLE ORDENAR DOCUMENTOS POR TITULO ALFABETICAMENTE");
            }

        }
        static void EscribeDocumentosQueContenganMayusculas()
        {
            try
            {
                var documentos = GenerarListaDocumentos(10, 1);
                var documentosConMayusculas = new List<Documento>();
                var encabezado = "MUESTRO DOCUMENTOS QUE TENGAN POR LO MENOS UNA LETRA EN MAYUSCULA COMO TITULO";
                documentosConMayusculas = documentos.FindAll((Documento x) =>
                {
                    var longitud = x.Titulo.Length - 1;
                    var hayDocumentoConMayuscula = false;
                    while (longitud > 0)
                    {
                        if (x.Titulo[longitud] == x.Titulo.ToUpper()[longitud])
                        {
                            documentosConMayusculas.Add(x);
                            longitud = -1;
                            hayDocumentoConMayuscula = true;
                        }
                        longitud--;
                    }
                    if (hayDocumentoConMayuscula == false)
                    {
                        encabezado = "NO HAY DOCUMENTOS QUE TENGAN POR LO MENOS UNA LETRA EN MAYUSCULA COMO TITULO";
                    }
                    return hayDocumentoConMayuscula;
                });
                Console.Write(EscribirDocumentosConsola(documentosConMayusculas, encabezado));
            }
            catch (Exception)
            {
                Console.Write("NO ES POSIBLE ESCRIBIR DOCUMENTOS QUE CONTENGAN MAYUSCULAS");
            }
        }
        static void EscribeOrdenaFirmantesPorEdad()
        {
            try
            {
                var documentos = GenerarListaDocumentos(2, 5);
                var listaFirmantesOrdenados = new List<Firmante>();
                documentos = documentos.FindAll(x =>
                 {
                     foreach (var firmante in x.Firmantes)
                     {
                         listaFirmantesOrdenados.Add(firmante);
                     }

                     bool nkfldsnf = true;
                     return nkfldsnf;
                 });
                sortEdadFirmantes ordenar = new sortEdadFirmantes();
                listaFirmantesOrdenados.Sort(ordenar);
                string encabezado = "ORDENO FIRMANTES POR EDAD";
                Console.Write(EscribirFirmantesConsola(listaFirmantesOrdenados, encabezado));
            }
            catch (Exception)
            {
                Console.Write("ERROR");
            }
        }
        static void EscribeDocumentosTitulosEnMayuscula()
        {
            try
            {
                var documentos = GenerarListaDocumentos(5, 3);
                var documentosTitulomayuscula = new List<Documento>();
                Func<string, string> ponerTituloMayuscula = (titulo => titulo.ToUpper());
                foreach (var documento in documentos)
                {
                    documento.Titulo = ponerTituloMayuscula(documento.Titulo);
                    documentosTitulomayuscula.Add(documento);
                }
                string encabezado = "PONE TODOS LOS TITULOS EN MAYUSCULA";
                Console.Write(EscribirDocumentosConsola(documentosTitulomayuscula, encabezado));
                Console.WriteLine("\n----- ----- -----");
            }
            catch (Exception)
            {
                Console.Write("ERROR");
            }
        }
        static void EscribeCualFirmanteEsMayor()
        {
            try
            {   
                var documentos = GenerarListaDocumentos(10, 2);
                Func<int, int, string> cualEsMayor = ((edad1, edad2) =>
                {
                    string mensaje;
                    if (edad1 > edad2) mensaje = "El firmante 1 es mayor";
                    else if (edad1 < edad2) mensaje = "El firmante 2 es mayor";
                    else mensaje = "La edad es la misma";
                    return mensaje;
                });
                Console.WriteLine("DETERMINA QUE FIRMANTE ES MAYOR");
                foreach (var documento in documentos)
                {
                    int edad1=0;
                    int edad2=0;
                    foreach (var firmante in documento.Firmantes)
                    {
                        if (edad1 == 0) edad1 = firmante.Edad;
                        else edad2 = firmante.Edad;
                    }
                    Console.WriteLine(cualEsMayor(edad1, edad2));
                    Console.WriteLine(Escribir1DocumentoConosola(documento));
                }
                Console.WriteLine("\n----- ----- -----");
            }
            catch
            {
                Console.Write("ERROR");
            }

        }
        static void EscribeTitulos()
        {
            try
            {
                Console.WriteLine("\nESCRIBIR TITUTLOS DE DOCUMENTOS");
                var documentos = GenerarListaDocumentos(15, 1);
                Action<Documento> escribirTitulos = doc => Console.WriteLine(doc.Titulo);
                foreach (var documento in documentos)
                {
                    escribirTitulos(documento);
                }
            }
            catch (Exception)
            {
                Console.Write("ERROR");
            }
        }
        #endregion
        #region Aleatorios
        public static Random random = new Random();
        static List<Documento> GenerarListaDocumentos(int cantidadDocumentos, int cantidadFirmantes)
        {
            var documentos = new List<Documento>();
            for (int i = 0; i < cantidadDocumentos; i++)
            {
                documentos.Add(GenerarDocumentoAleatorioConFirmantes(cantidadFirmantes));
            }
            return documentos;
        }
        static Documento GenerarDocumentoAleatorioConFirmantes(int cantidad)
        {
            var documento = new Documento();
            documento.Titulo = GenerarStringAleatorio();
            documento.Cuerpo = GenerarStringAleatorio();
            var firmantes = new List<Firmante>();
            for (int i = 0; i < cantidad; i++)
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
            //var random = new Random(DateTime.Now.Millisecond);
            firmante.Edad = random.Next(10, 70);
            return firmante;
        }
        static string GenerarStringAleatorio()
        {
            //var random = new Random(DateTime.Now.Millisecond); //random que voy a usar en toda la funcion
            string stringAleatorio = ""; //el nuevo string que voy a generar (return)
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; //los caracters que puede llevar
            int cantCaracteres = caracteres.Length; //el numero de caracteres que uso
            char letra; //la letra que voy a agregar a mi nueva palabra
            int cantStringAleatorio = random.Next(1, 10); //el maximo de letras que le voy a poner a mi nueva palabra
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