using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.Owin.Security.Provider;

namespace OroUostoSistema.DatabaseOroUostas
{
    public enum BilietoBusena
    {
        Uzsakyta = 1,
        Sumoketa = 2,
        LaukiamaPatvirtinimo = 3,
        Parduota = 4,
        Atsaukta = 5,
        Redaguota = 6,
        LaukiamaPatvirtinimoPoRedagavimo = 7,
        Kita = 10,
    }
    public class Bilietas
    {
        public int ID { get; set; }
        public DateTime UzsakimoData { get; set; }
        public BilietoBusena Busena { get; set; }
        public decimal Kaina { get; set; }

        [ForeignKey("Pardavejas")]
        public int? Pardavejas_ID { get; set; }

        [Display(Name = "Pardavėjas")]
        public virtual Pardavejas Pardavejas { get; set; }

        [ForeignKey("SedimaVieta")]
        public int? SedimaVieta_ID { get; set; }
        public virtual SedimaVieta SedimaVieta { get; set; }

        [ForeignKey("Uzsakovas")]
        public int? Uzsakovas_ID { get; set; }
        public virtual Uzsakovas Uzsakovas { get; set; }
        [ForeignKey("Skrydis")]
        public int? Skrydis_ID { get; set; }
        public virtual Skrydis Skrydis { get; set; }

        public string GetStatus
        {
            get
            {
                {
                    string status;
                    switch (Busena)
                    {
                        case BilietoBusena.Atsaukta:
                            status = "Ašaukta";
                            break;
                        case BilietoBusena.LaukiamaPatvirtinimo:
                            status = "Laukiama patvirtinimo";
                            break;
                        case BilietoBusena.Uzsakyta:
                            status = "Užsakyta";
                            break;
                        case BilietoBusena.LaukiamaPatvirtinimoPoRedagavimo:
                            status = "Laukiama patvirtinimo po redagavimo";
                            break;
                        default: 
                            status = Busena.ToString();
                            break;
                    }
                    return status;
                }
            }
        }

        public void UzsakytiBielieta(DB db, int uzsakovas)
        {
            this.UzsakimoData = DateTime.Now;
            this.Uzsakovas_ID = uzsakovas;
            this.Busena = BilietoBusena.Uzsakyta;
            db.Tickets.Add(this);
            db.SaveChanges();
        }
        public void SumoketiUzBielieta(DB db)
        {
            this.Busena = BilietoBusena.Sumoketa;
            db.Tickets.Attach(this);
            db.Entry(this).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void PirktiBielieta(DB db)
        {
            this.Busena = BilietoBusena.LaukiamaPatvirtinimo;
            db.Tickets.Attach(this);
            db.Entry(this).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void RedaguotiBielieta(DB db)
        {
            this.Busena = BilietoBusena.Redaguota;
            db.Tickets.Attach(this);
            db.Entry(this).Property(x => x.Kaina).IsModified = true;
            db.Entry(this).Property(x => x.SedimaVieta_ID).IsModified = true;
            //db.Entry(this).Property(x => x.Pardavejas_ID).IsModified = true;
            db.Entry(this).Property(x => x.Busena).IsModified = true;
            db.SaveChanges();
        }

        internal void TrintiBilieta(DB db)
        {
            this.Busena = BilietoBusena.Atsaukta;
            db.Tickets.Attach(this);
            db.Entry(this).Property(x => x.Busena).IsModified = true;
            db.SaveChanges();
        }

        public void BaigtiRedagavima(DB db)
        {
            this.Busena = BilietoBusena.LaukiamaPatvirtinimoPoRedagavimo;
            db.Tickets.Attach(this);
            db.Entry(this).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}