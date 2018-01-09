using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Capgemini.Interface.InfraStructre

{
    public static class Settings
    {
        public static class Send
        {
            public static string Smtp { get { return ConfigurationManager.AppSettings["smtp"]; } }
            public static string UsuarioOuEmail { get { return ConfigurationManager.AppSettings["email"]; } }
            public static string Senha { get { return ConfigurationManager.AppSettings["senha"]; } }
            public static int Port { get { return int.Parse(ConfigurationManager.AppSettings["port"]); } }
        }
    }
}