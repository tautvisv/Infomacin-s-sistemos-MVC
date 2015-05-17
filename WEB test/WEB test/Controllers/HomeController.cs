using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var db = new DB())
            {
                db.Tickets.Include(x => x.Pardavejas).ToList();
                return View();
            }
        }
	}
}