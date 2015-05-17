using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OroUostoSistema.DatabaseOroUostas
{
    public class Lektuvas
    {
        public int ID { get; set; }
        public string Pavadinimas { get; set; }
        public virtual IList<SedimaVieta> SedimosViewtos { get; set; } 
    }
}