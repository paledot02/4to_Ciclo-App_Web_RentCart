using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities; // --
using Infraestructura.Data.SQLServer; // --

namespace Dominio.MainModule
{
    public class DistritoManager
    {

        DistritoDAL objDAL = new DistritoDAL();

        public List<Distrito> listar()
        {
            return objDAL.listar();
        }

    }
}
