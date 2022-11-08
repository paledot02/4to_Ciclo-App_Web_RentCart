using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // --
using System.Data.SqlClient; // --
using Dominio.Core.Entities; // --

namespace Infraestructura.Data.SQLServer
{
    public class DistritoDAL
    {

        Conexion objCon = new Conexion();
        SqlConnection cn = null;

        public List<Distrito> listar()
        {
            cn = objCon.getConecta();
            List<Distrito> lista = new List<Distrito>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DISTRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distrito objD = new Distrito()
                {
                    ide_dis = int.Parse(dr[0].ToString()),
                    des_dis = dr[1].ToString()
                };
                lista.Add(objD);
            }
            cn.Close();
            return lista;
        }


    }
}
