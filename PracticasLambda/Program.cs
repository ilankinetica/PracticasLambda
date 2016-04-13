﻿using System;
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
        public static Random random = new Random();
        static void Main(string[] args)
        {
            EscribeDocumentosConFirmantesMayores();
            EscribeDocumentosConTituloConA();
            EscribeDocumentosConTitulo3Caracteres();
            EscribeSiFirmanteEdad17();
            EscribePrimerDocumentoConCuerpoConAB();
            Console.ReadLine();
        }
        #region Escribe en la Consola
        //enteros.First
        //enteros.Sort
        //enteros.Last
        static string EscribirDocumentosConsola(List<Documento> documentos, string encabezado)
        {
            string resultado = "";
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
            resultado+="\n----- ----- -----";
            return resultado;
        }
        static string Escribir1DocumentoConosola(Documento documento, string encabezado)
        {
            string resultado = "";
            resultado += encabezado + "\n\n";
            resultado += "\n\nDocumento: \nTitulo: " + documento.Titulo + "\nCuerpo: " + documento.Cuerpo + "\nFirmantes: \n";
            foreach (var firmante in documento.Firmantes)
            {
                resultado += "\nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString() + "\n-----";
            }
            resultado += "\n----- -----";
            resultado+="\n----- ----- -----";
            return resultado;
        }
        static string EscribirFirmantesConsola (List<Firmante> firmantes, string encabezado)
        {
            string resultado = "";
            resultado += encabezado + "\n\n";
            foreach (var firmante in firmantes)
            {
                resultado += "\nFirmante: \nNombre: " + firmante.Nombre + "\nFirma: " + firmante.Firma + "\nEdad: " + firmante.Edad.ToString();
                resultado += "\n----- -----";
            }
            resultado += "\n----- ----- -----";
            return resultado;
        }
        static void EscribeSiFirmanteEdad17()
        {
            //Carga inicial de datos
            var documentos = GenerarListaDocumentos(3, 50);
            //Separa firmantes con 17 años
            bool existeFirmanteEdad17 = false;
            List<Firmante> firmantesEdad17 = new List<Firmante>();
            existeFirmanteEdad17 = documentos.Exists((Documento doc) =>
            {
                foreach (var firmante in doc.Firmantes)
                {
                    if (firmante.Edad==17)
                    {
                        existeFirmanteEdad17 = true;
                        firmantesEdad17.Add(firmante);
                    }
                }
                return existeFirmanteEdad17;
            });
            string encabezado = "EXISTE FIRMANTE CON 17 AÑOS:" + existeFirmanteEdad17;
            Console.Write(EscribirFirmantesConsola(firmantesEdad17,encabezado));
        }
        static void EscribeDocumentosConFirmantesMayores()
        {
            //Carga de datos inicial
            var documentos = GenerarListaDocumentos(10,5);
            //Separa los documentos que tienen por lo menos un firmante mayor a 18
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
            //Escribe en la consola
            string encabezado = "MUESTRO DOCUMENTOS CON POR LO MENOS UN FIRMANTE MAYOR A 18 AÑOS DE EDAD";
            Console.Write(EscribirDocumentosConsola(documentosConMayores, encabezado));
        }
        static void EscribeDocumentosConTituloConA()
        {
            //Carga incial de datos
            var documentos = GenerarListaDocumentos(20,5);
            //separa documentos con titulo que contenga A
            var documentosConTituloA = new List<Documento>();
            documentosConTituloA = documentos.FindAll(doc => doc.Titulo.Contains("A") == true);
            //Escribe en consola
            string encabezado = "MUESTRO DOCUMENTOS CON TITULO QUE CONTENGA LETRA A";
            Console.Write(EscribirDocumentosConsola(documentosConTituloA, encabezado));
        }
        static void EscribeDocumentosConTitulo3Caracteres()
        {
            //carga incial
            var documentos = GenerarListaDocumentos(20, 2);
            //separa docuemntos con titulo de tres caracteres
            var documentosConTitulo3 = new List<Documento>();
            documentosConTitulo3 = documentos.Where(doc => doc.Titulo.Length == 3).ToList();
            //Escribe en consola
            string encabezado = "MUESTRO DOCUMENTOS CON TITULO DE 3 CARACTERES";
            Console.Write(EscribirDocumentosConsola(documentosConTitulo3, encabezado));
        }
        static void EscribePrimerDocumentoConCuerpoConAB()
        {
            //carga incial
            var documentos = GenerarListaDocumentos(10000, 1);
            //separar primer documento con abc
            try
            {
                var documentoConAB = documentos.First(doc => doc.Cuerpo.Contains("AB"));
                //escribe en consola
                string encabezado = "MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB";
                Console.Write(Escribir1DocumentoConosola(documentoConAB, encabezado));
            }
            catch
            {
                Console.Write("MUESTRO PRIMER DOCUMENTO CON CUERPO QUE CONTIENE AB\nNo hay ningun documento con cuerpo que contenga ABC");
            }
        }
        #endregion
        #region Aleatorios
        static List<Documento> GenerarListaDocumentos (int cantidadDocumentos, int cantidadFirmantes)
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