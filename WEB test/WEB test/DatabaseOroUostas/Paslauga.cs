using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OroUostoSistema.DatabaseOroUostas
{
    public class Paslauga
    {
        public int ID { get; set; }
        public string Veiksmas { get; set; }
        public IList<Veiksmas> Veiksmai { get; set; }
    }
}