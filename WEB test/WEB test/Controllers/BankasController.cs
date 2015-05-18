﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Controllers
{
    public class BankasController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            using (var db = new DB())
            {
                var ticket = db.Tickets.Include(x => x.Skrydis).FirstOrDefault(x => x.ID == id);
                return View(ticket);
            }
        }
        [HttpPost]
        public ActionResult Index(int id,int? niekas)
        {
            return RedirectToAction("Uzsakyti", "Klientas", new {id = id, niekas = niekas});
            //using (var db = new DB())
            //{
            //    var ticket = db.Tickets.FirstOrDefault(x => x.ID == id);
            //    if (ticket != null)
            //    {
            //        ticket.SumoketiUzBielieta(db);
            //        return RedirectToAction("RezervuotiBilieta", "Klientas", new { id = ticket.Skrydis_ID, ticketID = ticket.ID });
            //    }
            //    else throw new NullReferenceException("Nėra tokio bilieto!");
            //}
        }
	}
}