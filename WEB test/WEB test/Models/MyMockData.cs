using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Models
{
    public class MyMockData
    {
        private readonly DB _db;
        private readonly IList<Uzsakovas> _users = new List<Uzsakovas>()
        {
            new Uzsakovas(){ElPastas = "a@a", Numeris = "869958879", Tipas = VartotojoTipas.Admin, Vardas = "Tautvydas", Pavarde = "Vatiekunas", Slaptazodis = "a", ReSlaptazodis = "a"},
            new Uzsakovas(){ElPastas = "liudas@gmail.com", Numeris = "869958875", Tipas = VartotojoTipas.Admin, Vardas = "Liudas", Pavarde = "Strimaitis", Slaptazodis = "a", ReSlaptazodis = "a"},
            new Uzsakovas(){ElPastas = "user@a", Numeris = "869958871", Tipas = VartotojoTipas.User, Vardas = "Paprastas", Pavarde = "Vartotojas", Slaptazodis = "a", ReSlaptazodis = "a"},
            new Uzsakovas(){ElPastas = "vip@a", Numeris = "869958870", Tipas = VartotojoTipas.VIP, Vardas = "VIP", Pavarde = "Vartotojas2", Slaptazodis = "a", ReSlaptazodis = "a"},
        };
        private  readonly IList<Veiksmas> _actions = new List<Veiksmas>()
        {
            new Veiksmas(){Kiekis = 1, Pavadinimas = "Pietus"},
            new Veiksmas(){Kiekis = 2, Pavadinimas = "Gėrimai"},
            new Veiksmas(){Kiekis = 10, Pavadinimas = "Bagažas"},
        }; 
        private readonly IList<Paslauga> _services = new List<Paslauga>()
        {
            new Paslauga(){Veiksmas = "Maistas", Veiksmai = new List<Veiksmas>(){new Veiksmas(){ID = 1, Kiekis = 1, Pavadinimas = "Pietus"}, new Veiksmas(){ID = 2, Kiekis = 2, Pavadinimas = "Gerimai"} }},
            new Paslauga(){Veiksmas = "Bagazas", Veiksmai = new List<Veiksmas>(){new Veiksmas(){ID = 3, Kiekis = 10, Pavadinimas = "Bagazas"}}},
        };
        private readonly IList<Skrydis> _flights = new List<Skrydis>()
        {
            new Skrydis()
            {
                Pavadinimas = "Kaunas-Honolulu", 
                Lektuvas = new Lektuvas()
                {
                    Pavadinimas = "Boeing 787",
                    SedimosViewtos = new List<SedimaVieta>()
                    {
                        new SedimaVieta(){Klase = KlaseEnum.A, Vieta = 1},
                        new SedimaVieta(){Klase = KlaseEnum.B, Vieta = 12},
                        new SedimaVieta(){Klase = KlaseEnum.C, Vieta = 20},
                        new SedimaVieta(){Klase = KlaseEnum.D, Vieta = 21},
                        new SedimaVieta(){Klase = KlaseEnum.E, Vieta = 35},
                        new SedimaVieta(){Klase = KlaseEnum.B, Vieta = 99}
                    }
                }
            },
            new Skrydis(){Pavadinimas = "Roma-Kaunas"},
            new Skrydis(){Pavadinimas = "Vilnius-Madridas"},
            new Skrydis(){Pavadinimas = "Palanga-Varšuna"},
            new Skrydis(){Pavadinimas = "Maskva-Kaunas"},
            new Skrydis(){Pavadinimas = "Londonas-Vilnius"},
            new Skrydis(){Pavadinimas = "Palanga-Kaunas"},
        };
        private readonly IList<Bilietas> _tickets = new List<Bilietas>()
        {
            new Bilietas(){Kaina = 10.10M, Skrydis_ID = 1, UzsakimoData = DateTime.Now, Busena = BilietoBusena.Kita},
            new Bilietas(){Kaina = 310.10M, Skrydis_ID = 2, UzsakimoData = DateTime.Now, Busena = BilietoBusena.Kita},
            new Bilietas(){Kaina = 120.10M, Skrydis_ID = 3, UzsakimoData = DateTime.Now, Busena = BilietoBusena.Kita},
            new Bilietas(){Kaina = 1000.10M, Skrydis_ID = 2, UzsakimoData = DateTime.Now, Busena = BilietoBusena.Kita},
        };
        private  readonly IList<Pardavejas> _sellers = new List<Pardavejas>()
        {
            new Pardavejas(){ImonesKodas = "843565465", Pavadinimas = "UAB geriausia įmonė"},
            new Pardavejas(){ImonesKodas = "684641", Pavadinimas = "UAB rekvita"},
            new Pardavejas(){ImonesKodas = "51651321", Pavadinimas = "UAB bilieta"},
            new Pardavejas(){ImonesKodas = "646465465", Pavadinimas = "UAB bilietai.lt"},
        }; 
        public MyMockData(DB db)
        {
            this._db = db;
        }
        public void CreateMockData()
        {
            foreach (var user in _users)
            {
                user.EncodePassword();
                _db.Users.Add(user);
            }
            foreach (var seller in _sellers)
            {
                _db.Sellers.Add(seller);
            }
            foreach (var service in _services)
            {
                _db.Services.Add(service);
            }
            foreach (var flight in _flights)
            {
                _db.Flights.Add(flight);
            }

            _db.SaveChanges();
            foreach (var ticket in _tickets)
            {
                _db.Tickets.Add(ticket);
            }
            
            _db.SaveChanges();
        }
    }
}