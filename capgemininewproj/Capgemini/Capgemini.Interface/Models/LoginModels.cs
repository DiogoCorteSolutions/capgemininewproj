using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Capgemini.Interface.Models
{
    public class LoginModels
    {
        public int IdCadastro { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Cpf { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }


        private const string sessionUser = "sessionUser";

        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static bool IsLogado() { return (Session[sessionUser] != null); }

        public static void LogOff()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }

        public static LoginModels GetLoginModel()
        {
            return !IsLogado() ? null : (LoginModels)Session[sessionUser];
        }

        public static void SetLoginModel(LoginModels model)
        {
            Session[sessionUser] = model;
        }

    }
}