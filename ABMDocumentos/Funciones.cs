using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public static class Funciones
    {
        public static string DocumentosConFirmantesMayores(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var documentosConMayores = new List<Documento>();
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
                var encabezado = "MUESTRO DOCUMENTOS CON POR LO MENOS UN FIRMANTE MAYOR A 18 AÑOS DE EDAD";
                texto = FormatoFunciones.DocumentosVarios(documentosConMayores, encabezado);
            }
            catch (Exception)
            {
                throw;
            }
            return texto;
        }
        public static string UlitmoDocumentoYCantidadConUltimaLetratituloZ(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                Documento ultimoDocConUltimaLetraZ = documentos.Last((Documento x) =>
                {
                    bool hayDocumento = false;
                    var ultimaLetra = x.Titulo.Length - 1;
                    if (x.Titulo[ultimaLetra] == 'Z')
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
                var encabezado = "MUESTRO ULTIMO DOCUMENTO CON ULTIMA LETRA DE TITULO 'Z'. SE HAN ENCONTRADO " + contador + " DOCUMENTOS CON ULTIMA LETRA 'Z'   ";
                texto = FormatoFunciones.Documentos1(ultimoDocConUltimaLetraZ, encabezado);
            }
            catch (Exception)
            {
            }
            return texto;
        }
        public static string PrimerFirmanteEdad17(List<Documento> documentos)
        {
            string texto = "";
            try
            {
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
                var encabezado = "EXISTE FIRMANTE CON 17 AÑOS:" + existeFirmanteEdad17;
                texto = FormatoFunciones.FirmantesVarios(firmantesEdad17, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string DocumentosConTituloConA(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var documentosConTituloA = documentos.FindAll(doc => doc.Titulo.Contains("A") == true);
                string encabezado = "MUESTRO DOCUMENTOS CON TITULO QUE CONTENGA LETRA A";
                texto = FormatoFunciones.DocumentosVarios(documentosConTituloA, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string DocumentosConTitulo3Caracteres(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var documentosConTitulo3 = documentos.Where(doc => doc.Titulo.Length == 3).ToList();
                string encabezado = "MUESTRO DOCUMENTOS CON TITULO DE 3 CARACTERES";
                texto = FormatoFunciones.DocumentosVarios(documentosConTitulo3, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string DocumentoYCantidadConCuerpoAB(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var documentoConAB = documentos.First(doc => doc.Cuerpo.Contains("AB"));
                var contadorConAB = documentos.Where(doc => doc.Cuerpo.Contains("AB")).Count();
                string encabezado = "MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB. TOTAL CUERPO CON AB: " + contadorConAB.ToString();
                texto = FormatoFunciones.Documentos1(documentoConAB, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string UltimoDocumentoYCantidadConUltimaLetaTituloZ(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var contadorConAB = documentos.Where(doc => doc.Cuerpo.Contains("AB")).Count();
                Documento documentoConAB = new Documento();
                if (contadorConAB!=0) documentoConAB = documentos.First(doc => doc.Cuerpo.Contains("AB"));
                string encabezado = "MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB. TOTAL CUERPO CON AB: " + contadorConAB.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string DocuementosOrdenadosPorTituloAlfabeticamente(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                documentos.Sort(Sorting.SortAlfabeticamenteDocumentos.Compare);
                string encabezado = "ORDENO DOCUMENTOS POR TITULO ALFABETICAMENTE";
                FormatoFunciones.DocumentosVarios(documentos, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string DocumentosConMayusculas(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var encabezado = "MUESTRO DOCUMENTOS QUE TENGAN POR LO MENOS UNA LETRA EN MAYUSCULA COMO TITULO";
                var documentosConMayusculas = new List<Documento>();
                documentosConMayusculas = documentos.FindAll((Documento x) =>
                {
                    var longitud = x.Titulo.Length - 1;
                    var hayDocumentoConMayuscula = false;
                    do
                    {
                        if (x.Titulo[longitud] == x.Titulo.ToUpper()[longitud])
                        {
                            documentosConMayusculas.Add(x);
                            longitud = -1;
                            hayDocumentoConMayuscula = true;
                        }
                        longitud--;
                    } while (longitud >= 0);
                    if (hayDocumentoConMayuscula == false)
                    {
                        encabezado += "\nNO HAY DOCUMENTOS QUE TENGAN POR LO MENOS UNA LETRA EN MAYUSCULA COMO TITULO";
                    }
                    return hayDocumentoConMayuscula;
                });
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
        public static string OrdenarFirmantesPorEdad(List<Documento> documentos)
        {
            string texto = "";
            try
            {
                var firmantesOrdenados = new List<Firmante>();
                foreach (var documento in documentos)
                {
                    foreach (var firmante in documento.Firmantes)
                    {
                        firmantesOrdenados.Add(firmante);
                    }
                }
                firmantesOrdenados.Sort(Sorting.SortEdadFirmantes.Compare);
                string encabezado = "ORDENO FIRMANTES POR EDAD";
                texto = FormatoFunciones.FirmantesVarios(firmantesOrdenados, encabezado);
            }
            catch (Exception)
            {

                throw;
            }
            return texto;
        }
    }
}
