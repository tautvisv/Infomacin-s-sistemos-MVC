using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OroUostoSistema.DatabaseOroUostas;
using OroUostoSistema.Helpers;

namespace OroUostoSistema.Models
{
    public class UserModelView
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Error { get; set; }
        public Uzsakovas Prisijungti(DB db)
        {
            this.Password = PasswordEncrypter.Encode(this.Password);
            var user = db.Users.FirstOrDefault(x => x.ElPastas.Equals(this.Email) && x.Slaptazodis.Equals(this.Password));
            return user;
        }
    }
}