using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities; // --
using Dominio.MainModule; // --
using System.IO; // --

namespace Presentacion.BDRentCar.Controllers
{
    public class ClienteController : Controller
    {

        DistritoManager mDistrito = new DistritoManager();
        ClienteManager mCliente = new ClienteManager();


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult listarCliente(int p = 0)
        {
            List<Cliente> lista = mCliente.listar();
            int filas = 11;
            int total = lista.Count();
            int pag = 0;
            if (total % filas > 0)
            {
                pag = (total / filas) + 1;
            }
            else
                pag = total / filas;
            ViewBag.pag = pag;
            ViewBag.p = p;
            return View(lista.Skip(p * filas).Take(filas));

        }


        public ActionResult listarClientePorDistrito(int dis = 0)
        {
            ViewBag.dis = dis;
            ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis");
            return View(mCliente.listarPorDistrito(dis));
        }


        [HttpGet]
        public ActionResult registrarCliente()
        {
            ViewBag.newCodigo = mCliente.generarCodigo();
            ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis");
            return View(new ClienteO());
        }
        [HttpPost]
        public ActionResult registrarCliente(ClienteO obj)
        {
            ViewBag.mensaje = mCliente.registrar(obj);
            ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis");
            return View();
        }


        [HttpGet]
        public ActionResult modificarCliente(int id)
        {
            ClienteO obj = mCliente.listarOriginal().Where(v => v.ide_cli == id).FirstOrDefault();
            ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis", obj.ide_dis);

            return View(obj);
        }
        [HttpPost]
        public ActionResult modificarCliente(ClienteO obj)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis", obj.ide_dis);
                return View(obj);
            }
            ViewBag.mensaje = mCliente.modificar(obj);
            ViewBag.distrito = new SelectList(mDistrito.listar(), "ide_dis", "des_dis", obj.ide_dis);
            return RedirectToAction("listarCliente");

        }

        public ActionResult detalleCliente(int id)
        {
            Cliente obj = mCliente.listar().Where(v => v.ide_cli == id).FirstOrDefault();
            return View(obj);
        }


        public ActionResult eliminarCliente(int id)
        {
            mCliente.eliminar(id);
            return RedirectToAction("listarCliente");
        }

    }
}