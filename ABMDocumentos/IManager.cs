using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMDocumentos
{
    public interface IManager
    {
        void Alta(object obj);
        void Baja(object obj);
        void Modificacion(object obj);
        void Consulta(object obj);
    }
}
