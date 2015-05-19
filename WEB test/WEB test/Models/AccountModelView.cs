using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Models
{
    public class AccountModelView
    {
        public AccountModelView(){}

        public AccountModelView(DB db, int userID)
        {
            Client = db.Users.FirstOrDefault(x => x.ID == userID);
            Services = db.Services.ToList();
        }
        public Uzsakovas Client { get; private set; }
        [Display(Name = "Paslaugos")]
        public IList<Paslauga> Services { get; private set; }
    }
}