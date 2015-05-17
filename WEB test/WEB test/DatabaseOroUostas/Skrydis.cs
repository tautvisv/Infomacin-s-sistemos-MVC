using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OroUostoSistema.DatabaseOroUostas
{
    //TODO Reik visk1 implementuoti
    public class Skrydis
    {
        [Key]
        public int ID { get; set; }
        public string Pavadinimas { get; set; }
        public virtual Lektuvas Lektuvas { get; set; }
        public virtual IList<Bilietas> Bilietai { get; set; } 
    }
}