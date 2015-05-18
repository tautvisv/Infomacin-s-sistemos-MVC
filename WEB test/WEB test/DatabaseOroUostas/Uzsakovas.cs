using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OroUostoSistema.Helpers;

namespace OroUostoSistema.DatabaseOroUostas
{
    public enum VartotojoTipas
    {
        Admin=1,
        User=2,
        VIP=3,
    }
    public class Uzsakovas
    {
        public int ID { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        [Display(Name = "Pavardė")]
        public string Pavarde { get; set; }
        [Required]
        [Display(Name = "El. paštas")]
        public  string ElPastas { get; set; }
        [Required]
        [RegularExpression(@"^\+?\d{1,9}")]
        public string Numeris { get; set; }
        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Slaptazodis { get; set; }
        [Required]
        [NotMapped] 
        [Display(Name = "Patvirti slaptažodį")]
        [Compare("Slaptazodis", ErrorMessage = "Nesutampa slaptažodžiai.")]
        public string ReSlaptazodis { get; set; }

        public VartotojoTipas Tipas { get; set; }
        [ForeignKey("Paslauga")] 
        public int? Paslauga_ID { get; set; }
        public virtual Paslauga Paslauga { get; set; }
        public virtual IList<Bilietas> Bilietai { get; set; }

        public void EncodePassword()
        {
            this.Slaptazodis = PasswordEncrypter.Encode(this.Slaptazodis);
            this.ReSlaptazodis = PasswordEncrypter.Encode(this.ReSlaptazodis);
        }

        public void Registruoti(DB db)
        {
            this.EncodePassword();
            this.Tipas = VartotojoTipas.Admin;
            this.Save(db);
        }

        public void NaujosPrivilegijos(DB db)
        {
            db.Users.Add(this);
            var entry = db.Entry(this);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Slaptazodis).IsModified = false;
            entry.Property(e => e.Tipas).IsModified = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
        public void Save(DB db)
        {
            db.Users.Add(this);
            db.SaveChanges();
        }
    }
}