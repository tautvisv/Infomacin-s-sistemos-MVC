using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Models
{
    public class FlightsHelper
    {
        public FlightsHelper(DB db, string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                Flights = db.Flights.ToList();
                return;
            }
            var searchText = search.ToLower();
            var stringProperties = typeof(Skrydis).GetProperties().Where(x => !x.GetGetMethod().IsVirtual);
            Flights =
                db.Flights.AsEnumerable()
                    .Where(x => stringProperties.Any(prop => prop.GetValue(x).ToString().ToLower().Contains(searchText)))
                    .ToList();
        }
        public IEnumerable<Skrydis> Flights { get; private set; }

    }
}