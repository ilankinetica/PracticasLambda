using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public class Funciones
    {
        string DocumentosConFirmantesMayores(List<Documento> documentos)
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
    }
}
