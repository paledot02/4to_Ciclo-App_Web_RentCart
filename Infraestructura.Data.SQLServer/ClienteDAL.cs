using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // --
using System.Data.SqlClient; // --
using Dominio.Core.Entities; // --
using System.Web; // --
using System.IO; // --

namespace Infraestructura.Data.SQLServer
{
    public class ClienteDAL
    {

        Conexion objCon = new Conexion();
        SqlConnection cn = null;


        public int generarCodigo()
        {
            int codigo = 0;

            cn = objCon.getConecta();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ULTIMO_IDE_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                codigo = int.Parse(dr[0].ToString()) + 1;
            }

            cn.Close();
            return codigo;
        }


        public List<Cliente> listar()
        {
            cn = objCon.getConecta();
            List<Cliente> lista = new List<Cliente>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTE_ALTERADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente obj = new Cliente()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    nom_cli = dr[1].ToString(),
                    dni_cli = dr[2].ToString(),
                    tel_cli = dr[3].ToString(),
                    des_dis = dr[4].ToString(),
                };
                lista.Add(obj);
            }
            cn.Close();
            return lista;
        }


        public List<ClienteO> listarOriginal()
        {
            cn = objCon.getConecta();
            List<ClienteO> lista = new List<ClienteO>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTE_ORIGINAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClienteO obj = new ClienteO()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    ape_cli = dr[1].ToString(),
                    nom_cli = dr[2].ToString(),
                    dni_cli = dr[3].ToString(),
                    tel_cli = dr[4].ToString(),
                    ide_dis = int.Parse(dr[5].ToString()),
                };
                lista.Add(obj);
            }
            cn.Close();
            return lista;
        }


        public List<ClienteFiltroDistrito> listarPorDistrito(int dis)
        {
            List<ClienteFiltroDistrito> lista = new List<ClienteFiltroDistrito>();
            cn = objCon.getConecta();
            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_LISTADO_CLIENTE_POR_DISTRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dis", dis);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClienteFiltroDistrito obj = new ClienteFiltroDistrito()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    nom_cli = dr[1].ToString(),
                    ape_cli = dr[2].ToString(),
                    dni_cli = dr[3].ToString(),
                    tel_cli = dr[4].ToString(),
                    des_dis = dr[5].ToString(),
                    veces_alquilo = int.Parse(dr[6].ToString()),
                    monto_acumulado = double.Parse(dr[7].ToString())
                };
                lista.Add(obj);
            }
            cn.Close();
            return lista;
        }


        public String registrar(ClienteO obj)
        {
            cn = objCon.getConecta();
            String mensaje = "";
            cn.Open();
            
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_CLIENTE", cn, tr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ide", obj.ide_cli);
                cmd.Parameters.AddWithValue("@ape", obj.ape_cli);
                cmd.Parameters.AddWithValue("@nom", obj.nom_cli);
                cmd.Parameters.AddWithValue("@dni", obj.dni_cli);
                cmd.Parameters.AddWithValue("@tel", obj.tel_cli);
                cmd.Parameters.AddWithValue("@dis", obj.ide_dis);

                int n = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = n.ToString() + " Cliente registrado correctamente";
            }
            catch (Exception ex)
            {
                tr.Rollback();
                mensaje = "Error al registrar cliente " + ex.Message;
            }

            cn.Close();
            return mensaje;
        }


        public String modificar(ClienteO obj)
        {
            cn = objCon.getConecta();
            cn.Open();
            string mensaje = "";

            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CLIENTE", cn, tr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ide", obj.ide_cli);
                cmd.Parameters.AddWithValue("@ape", obj.ape_cli);
                cmd.Parameters.AddWithValue("@nom", obj.nom_cli);
                cmd.Parameters.AddWithValue("@dni", obj.dni_cli);
                cmd.Parameters.AddWithValue("@tel", obj.tel_cli);
                cmd.Parameters.AddWithValue("@dis", obj.ide_dis);

                int n = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = n.ToString() + " Cliente actualizado correctamente";
            }
            catch (Exception ex)
            {
                tr.Rollback();
                mensaje = "Error al actualizar cliente " + ex.Message;
            }

            cn.Close();
            return mensaje;
        }


        public void eliminar(int id)
        {
            cn = objCon.getConecta();
            cn.Open();

            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CLIENTE", cn, tr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", id);

                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception)
            {
                tr.Rollback();
            }

            cn.Close();
        }

    }
}
