using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OroUostoSistema.DatabaseOroUostas;
using OroUostoSistema.Helpers;
using OroUostoSistema.Models;

namespace OroUostoSistema.Controllers
{
    public class VartotojasController : Controller
    {
        private readonly DB _db = new DB();

        // GET: /Account/
        public ActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        // GET: /Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakovas uzsakovas = _db.Users.Find(id);
            if (uzsakovas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakovas);
        }

        // GET: /Account/Create 
        // TODO example [Authorize(Roles="Administrators")]
        [AllowAnonymous]
        public ActionResult Registracija()
        {
            return View();
        }

        // POST: /Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registracija([Bind(Include = "ID,Vardas,Pavarde,ElPastas,Numeris,Slaptazodis,ReSlaptazodis")] Uzsakovas uzsakovas)
        {
            if (!ModelState.IsValid) 
                return View(uzsakovas);
            uzsakovas.Registruoti(_db);
            return RedirectToAction("Index", "Klientas");
        }

        public ActionResult Prisijungimas()
        {

            return View(new UserModelView());
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Prisijungimas([Bind(Include = "Email,Password")] UserModelView prisijungimas)
        {
            var user = prisijungimas.Prisijungti(_db);
            if (user == null)
            {
                prisijungimas.Error = "Blogi prisijungimo duomenys";
                return View(prisijungimas);
            }

            AccountManagerHelper.Login(Request.GetOwinContext(),user);
            Session["UserID"] = user.ID;
            return RedirectToAction("Index", "Klientas");
        }

        public ActionResult Atsijungti()
        {
            AccountManagerHelper.Logout(Request.GetOwinContext());
            return RedirectToAction("Index","Klientas");
        }

        // GET: /Account/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakovas uzsakovas = _db.Users.Find(id);
            if (uzsakovas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakovas);
        }

        // POST: /Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include="ID,Vardas,Pavarde,ElPastas,Numeris,Slaptazodis")] Uzsakovas uzsakovas)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(uzsakovas).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uzsakovas);
        }

        // GET: /Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakovas uzsakovas = _db.Users.Find(id);
            if (uzsakovas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakovas);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzsakovas uzsakovas = _db.Users.Find(id);
            _db.Users.Remove(uzsakovas);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
