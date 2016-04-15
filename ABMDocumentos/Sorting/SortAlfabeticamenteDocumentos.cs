using System.Collections.Generic;

namespace ABMDocumentos.Sorting
{
    public class SortAlfabeticamenteDocumentos /*: IComparer<Documento>*/
    {
       /* public int Compare(Documento x, Documento y)
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
        }*/
    }
}
