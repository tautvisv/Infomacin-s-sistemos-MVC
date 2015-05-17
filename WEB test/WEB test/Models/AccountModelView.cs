using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Models
{
    public class AccountModelView
    {
        public AccountModelView(Uzsakovas client, IList<Paslauga> paslaugos)
        {
            Client = client;
            Services = paslaugos;
        }
        public Uzsakovas Client { get; private set; }
        [Display(Name = "Paslaugos")]
        public IList<Paslauga> Services { get; private set; }
    }
}