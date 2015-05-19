using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Models
{
    public class TicketReservationModelView
    {
        public TicketReservationModelView() { }
        public TicketReservationModelView(DB db, int? flightID, int? ticketID)
        {
            if (flightID == null && ticketID != null)
            {
                Ticket = db.Tickets.Include(x => x.SedimaVieta).FirstOrDefault(x => x.ID == ticketID);
                Flight = db.Flights.FirstOrDefault(x => x.ID == Ticket.Skrydis_ID);
                IEnumerable<int?> seatsIDs = db.Tickets.Where(x => x.Skrydis_ID == Flight.ID && x.Busena != BilietoBusena.Atsaukta).Select(x => x.SedimaVieta_ID).ToArray().Where(x => x != Ticket.SedimaVieta_ID);
                Seats = db.Seats.Where(x => x.Lektuvas_ID == Ticket.Skrydis_ID && !seatsIDs.Contains(x.ID)).ToList();
            }
            else if (ticketID == null)
            {
                Flight = db.Flights.FirstOrDefault(x => x.ID == flightID);
                IList<int?> seatsIDs = db.Tickets.Where(x => x.Skrydis_ID == flightID && x.Busena != BilietoBusena.Atsaukta).Select(x => x.SedimaVieta_ID).ToArray();
                Seats = db.Seats.Where(x => x.Lektuvas_ID == flightID  && !seatsIDs.Contains(x.ID)).ToList();
                Ticket = new Bilietas() { Kaina = 300.00m, Skrydis_ID = flightID };
            }
            else
            {
                Ticket = db.Tickets.Include(x => x.SedimaVieta).FirstOrDefault(x => x.ID == ticketID);
                Flight = db.Flights.FirstOrDefault(x => x.ID == Ticket.Skrydis_ID);
                Seats = db.Seats.Where(x => x.Lektuvas_ID == Ticket.Skrydis_ID).ToList();
            }
            Sellers = db.Sellers.ToList();
        }

        public IList<SedimaVieta> Seats { get; set; }
        public Skrydis Flight { get; set; }
        public Bilietas Ticket { get; set; }
        public IList<Pardavejas> Sellers { get; set; }
    }
}