using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OroUostoSistema.DatabaseOroUostas;
using OroUostoSistema.Models;

namespace OroUostoSistema.Controllers
{
    [Authorize]
    public class KlientasController : Controller
    {
        [AllowAnonymous]
        public ActionResult Paieska(string searchText)
        {
            using (var db = new DB())
            {
                var flights = new FlightsHelper(db,searchText);
                return View("Index", flights.Flights);
            }
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var db = new DB())
            {
                var flights = db.Flights.ToList();
                return View(flights);
            }
        }
        public ActionResult GautiBilietus(int id)
        {
            using (var db = new DB())
            {
                var tickets = db.Tickets.Include(x => x.Pardavejas).Include(x => x.SedimaVieta).Include(x => x.Skrydis).Where(x => x.Uzsakovas_ID == id).ToList();
                return View(tickets);
            }
        }
        public ActionResult RezervuotiBilieta(int id, int? ticketID)
        {
            using (var db = new DB())
            {
                var data = new TicketReservationModelView(db, id, ticketID);
                //var ticket = new Bilietas(){Skrydis = flight, Skrydis_ID = flight.ID};
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult RezervuotiBilieta(TicketReservationModelView data)
        {
            using (var db = new DB())
            {
                data.Ticket.UzsakytiBielieta(db, (int)Session["UserID"]);
                //var ticket = new Bilietas(){Skrydis = flight, Skrydis_ID = flight.ID};
                return RedirectToAction("Index", "Bankas", new { id = data.Ticket.ID});
            }
        }

        [HttpGet]
        public ActionResult Uzsakyti(int id, int? niekas)
        {
            using (var db = new DB())
            {
                var ticket = db.Tickets.FirstOrDefault(x => x.ID == id);
                if (ticket != null)
                {
                    ticket.SumoketiUzBielieta(db);
                    return RedirectToAction("RezervuotiBilieta", "Klientas", new { id = ticket.Skrydis_ID, ticketID = ticket.ID });
                }
                else throw new NullReferenceException("Nėra tokio bilieto!");
            }
        }

        [HttpGet]
        public ActionResult PirktiBilieta(int id)
        {
            using (var db = new DB())
            {
                var ticket = db.Tickets.FirstOrDefault(x => x.ID == id);
                if (ticket != null) ticket.PirktiBielieta(db);
                return RedirectToAction("Index");
            }
        }

        public ActionResult PerziuretiBilieta(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasirinktiPrivilegija(Uzsakovas client)
        {
            using (var db = new DB())
            {
                client.NaujosPrivilegijos(db);
            }
            
            return RedirectToAction("Index");

        }
        public ActionResult PasirinktiPrivilegija()
        {
            int userID;
            // ReSharper disable once SuggestUseVarKeywordEvident
            try
            {
                userID = (int) Session["UserID"];
            }
            catch (Exception e)
            {
                return RedirectToAction("Atsijungti", "Vartotojas");
            }
            using (var db = new DB())
            {
                var user = db.Users.FirstOrDefault(x => x.ID == userID);
                var services = db.Services.ToList();
                return View(new AccountModelView(user, services));
            }
            
        }
        [HttpGet]
        public ActionResult RedaguotiRezervuotaBilieta(int id)
        {
            using (var db = new DB())
            {
                var data = new TicketReservationModelView(db, null, id);
                //var ticket = db.Tickets.Include(x => x.Skrydis).Include(x => x.SedimaVieta).FirstOrDefault(x => x.ID == id);
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult RedaguotiRezervuotaBilieta(Bilietas ticket)
        {
            using (var db = new DB())
            {
                ticket.RedaguotiBielieta(db);
                return RedirectToAction("Index");
            }
        }
	}
}