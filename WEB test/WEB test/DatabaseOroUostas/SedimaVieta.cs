using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OroUostoSistema.DatabaseOroUostas
{
    public enum KlaseEnum
    {
        A,B,C,D,E 
    }
    public class SedimaVieta
    {
        public int ID { get; set; }
        public int Vieta { get; set; }
        [ForeignKey("Lektuvas")]
        // ReSharper disable once InconsistentNaming
        public int Lektuvas_ID { get; set; }
        public virtual Lektuvas Lektuvas { get; set; }
        public KlaseEnum Klase { get; set; }
        public int GetKlassID { get { return (int) Klase; } }
        public string GetFullName
        {
            get
            {
                return "Vieta: " + Vieta + " | Klase: " + Klase.ToString();
            }
        }

        public override string ToString()
        {
            return "Vieta: " + Vieta + " | Klase: " + Klase.ToString();
        }
    }
}