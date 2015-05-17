using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema.Helpers
{
    public static class AccountManagerHelper
    {
        public static void Login(IOwinContext context, Uzsakovas user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Vardas));
            claims.Add(new Claim(ClaimTypes.Email, user.ElPastas));
            claims.Add(new Claim(ClaimTypes.Role, user.Tipas.ToString()));
            var id = new ClaimsIdentity(claims,
                                        DefaultAuthenticationTypes.ApplicationCookie);

            var authenticationManager = context.Authentication;
            authenticationManager.SignIn(id);
        }
        public static void Logout(IOwinContext context)
        {
            var authenticationManager = context.Authentication;
            authenticationManager.SignOut();
        }
    }
}