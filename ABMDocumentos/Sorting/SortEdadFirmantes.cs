using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos.Sorting
{
    public class SortEdadFirmantes : IComparer<Firmante>
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
}
