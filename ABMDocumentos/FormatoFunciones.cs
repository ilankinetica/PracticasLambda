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
            string formateado = "";
            try
            {
                formateado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
                foreach (var firmante in documento.Firmantes)
                {
                    formateado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
                }
                formateado += "\n----- -----";
            }
            catch (Exception)
            {

            }
            return formateado;
        }
        string DocumentosVarios (List<Documento> documentos, string encabezado)
        {
            string formateado = "";
            try
            {
                formateado += encabezado + "\n\n";
                foreach (var documento in documentos)
                {
                    formateado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
                    foreach (var firmante in documento.Firmantes)
                    {
                        formateado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
                    }
                    formateado += "\n----- -----";
                }
                formateado += "\n----- ----- -----\n";
            }
            catch (Exception)
            {

            }
            return formateado;
        }
    }
}
