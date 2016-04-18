using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABMDocumentos;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace WebLambda.Models
{
    public class BDDManager
    {
        protected SqlConnection coneccion;
        public bool Abrir()
        {
            string conector = "DefaultConnection";
            coneccion = new SqlConnection(@WebConfigurationManager.ConnectionStrings[conector].ToString());
            try
            {
                if (coneccion.State.ToString() != "Open")
                {
                    coneccion.Open();
                }
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        public bool Cerrar()
        {
            try
            {
                coneccion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string InsertarDocumento (Documento documento)
        {
            const string query = "INSERT INTO Documento (Titulo, Cuerpo) VALUES (@titulo, @cuerpo) SET @nuevoId = SCOPE_IDENTITY() RETURN Id";
            using (coneccion)
            {
                using (var command = new SqlCommand(query, coneccion))
                {
                    command.Parameters.AddWithValue("@titulo", SqlDbType.VarChar).Value = documento.Titulo;
                    command.Parameters.AddWithValue("@cuerpo", SqlDbType.VarChar).Value = documento.Cuerpo;
                    command.Parameters.Add("@nuevoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Connection = coneccion;
                    command.ExecuteNonQuery();
                    try
                    {
                        return command.Parameters["@id"].Value.ToString();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}