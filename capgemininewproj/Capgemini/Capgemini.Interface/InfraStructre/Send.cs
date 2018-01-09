using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace Capgemini.Interface.InfraStructre
{
    public static class Send
    {
        public static string EnviarSenha(string para, string mensagem, string assunto, List<string> file = null)
        {
            return _Send(para, mensagem, assunto) ? "E-mail enviado com sucessso." : "Error ao enviar e-mail.";
        }

        public static string Contato(string para, string mensagem, string assunto, string email, string nome, List<string> file = null)
        {
            return _Send(para,
                string.Format("<p>Mensagem de contato do site.<br><br><br>Nome: {0}<br>Mensagem: {1}<br>E-mail: {2}</p>",
                    nome, mensagem, email), assunto) ? "E-mail enviado com sucessso." : "Error ao enviar e-mail.";
        }

        private static bool _Send(string toEmail, string toBody, string assunto, bool isHtml = true, List<string> toFile = null)
        {
            try
            {
                var credenciais = new System.Net.NetworkCredential()
                {
                    UserName = Settings.Send.UsuarioOuEmail,
                    Password = Settings.Send.Senha
                };

                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new System.Net.Mail.MailAddress(Settings.Send.UsuarioOuEmail, assunto),
                    Subject = assunto,
                    IsBodyHtml = isHtml,
                    Body = toBody
                };

                if (toFile != null)
                {
                    for (int i = 0; i < toFile.Count; i++)
                    {
                        Attachment att = new Attachment(toFile[i].Replace("/", @"\"));
                        mail.Attachments.Add(att);
                    }
                }

                mail.To.Add(new System.Net.Mail.MailAddress(toEmail.Trim()));

                mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mail.HeadersEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                var smtpClient = new System.Net.Mail.SmtpClient(Settings.Send.Smtp)
                {
                    Credentials = credenciais,
                };

                if (Settings.Send.Port > 0) smtpClient.Port = Settings.Send.Port;

                smtpClient.EnableSsl = false;
                smtpClient.Send(mail);

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static string ReplaceMailMessage(string pathTemplate, System.Collections.Specialized.NameValueCollection arrCampos)
        {
            try
            {
                string body = String.Empty;

                if (!File.Exists(pathTemplate)) { throw new Exception(string.Format("O caminho '{0}' não existe, verifique !", pathTemplate)); }

                using (StreamReader oReader = File.OpenText(pathTemplate))
                {
                    body = oReader.ReadToEnd();
                    oReader.Close();
                }

                foreach (string fieldname in arrCampos)
                {
                    body = body.Replace("[%" + fieldname + "%]", arrCampos[fieldname]);
                }

                return body;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}