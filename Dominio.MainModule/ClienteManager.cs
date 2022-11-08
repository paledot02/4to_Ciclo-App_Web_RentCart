using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities; // --
using Infraestructura.Data.SQLServer; // --
using System.Web; // --

namespace Dominio.MainModule
{
    public class ClienteManager
    {

        ClienteDAL objDAL = new ClienteDAL();

        public int generarCodigo()
        {
            return objDAL.generarCodigo();
        }


        public List<Cliente> listar()
        {
            return objDAL.listar();
        }
        

        public List<ClienteO> listarOriginal()
        {
            return objDAL.listarOriginal();
        }


        public List<ClienteFiltroDistrito> listarPorDistrito(int dis)
        {
            return objDAL.listarPorDistrito(dis);
        }


        public String registrar(ClienteO obj)
        {
            return objDAL.registrar(obj);
        }


        public String modificar(ClienteO obj)
        {
            return objDAL.modificar(obj);
        }


        public void eliminar(int id)
        {
            objDAL.eliminar(id);
        }

    }
}
