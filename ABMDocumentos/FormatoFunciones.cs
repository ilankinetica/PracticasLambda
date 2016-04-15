using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public class FormatoFunciones
    {
        string Documentos1(Documento documento)
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
                throw new FormatException("Error en el formateo");
            }
            return resultado;
        }
        string Documentos1 (Documento documento, string encabezado)
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
                throw new FormatException("Error en el formateo");
            }
            return resultado;
        }
        string DocumentosVarios (List<Documento> documentos, string encabezado)
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
                throw new FormatException("Error en el formate");
            }
            return resultado;
        }
        string Firmante1 (Firmante firmante, string encabezado)
        {
            string resultado = "";
            try
            {
                resultado += encabezado + "\n\n";
                resultado += "\nFirmante: \nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString();
                resultado += "\n----- -----";
                resultado += "\n----- ----- -----\n";
            }
            catch (Exception)
            {
                throw new FormatException("Error en el formate");
            }
            return resultado;
        }
        string FirmantesVarios(List<Firmante> firmantes, string encabezado)
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
                throw new FormatException("Error en el formate");
            }
            return resultado;
        }
    }
}
