using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABMDocumentos;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WebLambda.Models
{
    public class BDDManager
    {
        protected SqlConnection coneccion;
        public bool Abrir()
        {
            string conector = "Jaime";
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
        public string InsertarDocumento(Documento documento)
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
        public string InsertarFirmante(Firmante firmante)
         {
            // const string query = "INSERT INTO Firmante (Nombre, Firma,Edad,IdDocumento) VALUES (@Nombre, @Firma,@Edad,@IdDoc) SET @nuevoId = SCOPE_IDENTITY() RETURN Id";
            const string query = "INSERT INTO Firmante (Id,Nombre, Firma,Edad,IdDocumento) VALUES (@nuevoId,@Nombre, @Firma,@Edad,@IdDoc)";

            using (coneccion)
             {
                 using (var command = new SqlCommand(query, coneccion))
                 {
                     command.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = firmante.Nombre;
                     command.Parameters.AddWithValue("@Firma", SqlDbType.VarChar).Value = firmante.Firma;
                     command.Parameters.AddWithValue("@Edad", SqlDbType.Int).Value = firmante.Edad;
                     //command.Parameters.Add("@nuevoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                     command.Parameters.AddWithValue("@nuevoId", SqlDbType.Int).Value = 5;
                     command.Parameters.AddWithValue("@IdDoc", SqlDbType.Int).Value = 5;
                    command.Connection = coneccion;
                     command.ExecuteNonQuery();
                     try
                     {
                         return command.Parameters["@id"].Value.ToString();
                     }
                     catch (Exception)
                     {
                         return "error";
                         throw;
                     }
                 }
             }
         }
    }
}