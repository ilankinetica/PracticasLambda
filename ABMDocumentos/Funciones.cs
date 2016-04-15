using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public static class Funciones
    {
        public static List<Documento> DocumentosConFirmantesMayores(List<Documento> documentos)
        {
            var documentosConMayores = new List<Documento>();
            try
            {
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
            }
            catch (Exception)
            {
                throw;
            }
            return documentosConMayores;
        }
        public static Documento UlitmoDocumentoConUltimaLetratituloZ(List<Documento> documentos)
        {
            Documento ultimoDocConUltimaLetraZ = new Documento();
            try
            {
                ultimoDocConUltimaLetraZ = documentos.Last((Documento x) =>
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
            }
            catch (Exception)
            {
            }
            return ultimoDocConUltimaLetraZ;
        }
        public static List<Firmante> PrimerFirmanteEdad17(List<Documento> documentos)
        {
            List<Firmante> firmantesEdad17 = new List<Firmante>();
            try
            {
                bool existeFirmanteEdad17 = false;
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
            }
            catch (Exception)
            {

                throw;
            }
            return firmantesEdad17;
        }
        public static List<Documento> DocumentosConTituloConA(List<Documento> documentos)
        {
            var documentosConTituloA = new List<Documento>();
            try
            {
                documentosConTituloA = documentos.FindAll(doc => doc.Titulo.Contains("A") == true);
            }
            catch (Exception)
            {

                throw;
            }
            return documentosConTituloA;
        }
        public static List<Documento> DocumentosConTitulo3Caracteres(List<Documento> documentos)
        {
            var documentosConTitulo3 = new List<Documento>();
            try
            {
                documentosConTitulo3 = documentos.Where(doc => doc.Titulo.Length == 3).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return documentosConTitulo3;
        }
        public static Documento DocumentoConCuerpoAB(List<Documento> documentos)
        {
            var documentoConAB = new Documento();
            try
            {
                documentoConAB = documentos.First(doc => doc.Cuerpo.Contains("AB"));
            }
            catch (Exception)
            {

                throw;
            }
            return documentoConAB;
        }
        public static Documento UltimoDocumento(List<Documento> documentos)
        {
            var documentoUltimo = new Documento();
            try
            {
                documentoUltimo = documentos.Last();
            }
            catch (Exception)
            {

                throw;
            }
            return documentoUltimo;
        }
        public static List<Documento> DocuementosOrdenadosPorTituloAlfabeticamente(List<Documento> documentos)
        {
            try
            {
                documentos.Sort(Sorting.SortAlfabeticamenteDocumentos.Compare);
            }
            catch (Exception)
            {

                throw;
            }
            return documentos;
        }
        public static List<Documento> DocumentosConMayusculas(List<Documento> documentos)
        {
            var documentosConMayusculas = new List<Documento>();
            try
            {
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
                        }
                        longitud--;
                    } while (longitud >= 0);
                   
                    return hayDocumentoConMayuscula;
                });
            }
            catch (Exception)
            {

                throw;
            }
            return documentosConMayusculas;
        }
        public static List<Firmante> FirmantesOrdenadosPorEdad(List<Documento> documentos)
        {
            var firmantesOrdenados = new List<Firmante>();
            try
            {
                foreach (var documento in documentos)
                {
                    foreach (var firmante in documento.Firmantes)
                    {
                        firmantesOrdenados.Add(firmante);
                    }
                }
                firmantesOrdenados.Sort(Sorting.SortEdadFirmantes.Compare);
            }
            catch (Exception)
            {

                throw;
            }
            return firmantesOrdenados;
        }
        public static List<Documento> DocumentosConTitulosEnMayuscula(List<Documento> documentos)
        {
            var documentosTitulomayuscula = new List<Documento>();
            try
            {
                Func<string, string> ponerTituloMayuscula = (titulo => titulo.ToUpper());
                foreach (var documento in documentos)
                {
                    documento.Titulo = ponerTituloMayuscula(documento.Titulo);
                    documentosTitulomayuscula.Add(documento);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return documentosTitulomayuscula;
        }
        public static List<string> Titulos(List<Documento> documentos)
        {
            var titulos = new List<string>();
            try
            {
                Action<Documento> escribirTitulos = (doc => titulos.Add(doc.Titulo));
                foreach (var titulo in titulos)
                {
                    titulos.Add(titulo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return titulos;
        }
        public static List<Documento> DocumentosConFirmantesOrdenadosPorEdad(List<Documento> documentos)
        {
            var documentosFirmantesOrdenados = new List<Documento>();
            try
            {
                Func<Documento, Documento> ordenaFirmantes = (documento =>
                {
                    documento.Firmantes.Sort(Sorting.SortEdadFirmantes.Compare);
                    return documento;
                });
                foreach (var documento in documentos)
                {
                    documentosFirmantesOrdenados.Add(ordenaFirmantes(documento));
                }
            }
            catch (Exception)
            {
                var firmantesOrdenados = new List<Firmante>();
                Action<Firmante> ColocarFirmanteEnLista = firmante => firmantesOrdenados.Add(firmante);

                throw;
            }
            return documentosFirmantesOrdenados;
        }
    }
}
