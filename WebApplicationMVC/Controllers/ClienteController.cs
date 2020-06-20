using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.models1;

namespace WebApplicationMVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cliente()
        {
            try
            {
                //ClienteEntities db = new ClienteEntities();
                using (var db = new ClienteEntities()) {
                List<clientes> listaclie = db.clientes.ToList();
                return View(listaclie);
                }
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(clientes cli)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new ClienteEntities())
                {
                    db.clientes.Add(cli);
                    db.SaveChanges();
                    return RedirectToAction("Cliente");
                }
                   
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error al agregar",ex);
                return View();

                // throw;
            }


        }

        [Route("Editar/{IdCliente}")]
        public ActionResult Editar(int? id)
        {
            using (var db = new ClienteEntities())
            {
                clientes cl = db.clientes.Find(id);

                return View(cl);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(clientes cli)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new ClienteEntities())
                {
                    clientes c = db.clientes.Find(cli.IdCliente);
                    c.NomCliente = cli.NomCliente;
                    c.AliasCliente = cli.AliasCliente;
                    c.DirCliente = cli.DirCliente;
                    c.idPais = cli.idPais;
                    c.fonoCliente = cli.fonoCliente;

                    db.SaveChanges();
                    return RedirectToAction("Cliente");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error al editar", ex);
                return View();

                // throw;
            }


        }

        public ActionResult Detalle(int? id)
        {
            try
            {
                //ClienteEntities db = new ClienteEntities();
                using (var db = new ClienteEntities())
                {
                    clientes c = db.clientes.Find(id);
                    return View(c);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult Eliminar(int? id)
        {
            try
            {
                //ClienteEntities db = new ClienteEntities();
                using (var db = new ClienteEntities())
                {
                    clientes c = db.clientes.Find(id);
                    db.clientes.Remove(c);
                    db.SaveChanges();
                    return RedirectToAction("Cliente");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}