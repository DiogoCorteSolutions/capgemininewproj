using Capgemini.DTO;
using Capgemini.Interface.InfraStructre;
using Capgemini.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Interface.Controllers
{
    public class LoginController : Controller
    {

        private readonly Capgemini.Business.CadastroBusines business;

        public LoginController()
        {
            this.business = new Business.CadastroBusines();
        }
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View(new CadastroDTO());
        }

        [HttpPost]
        public ActionResult Index(CadastroDTO dto)
        {
            dto.Cpf = StringHelper.FormatarCpf(dto.Cpf);

            var retorno = this.business.Login(dto.Senha, dto.Cpf);

            if (retorno != null)
            {

                LoginModels.SetLoginModel(new LoginModels
                {
                    IdCadastro = retorno.IdCadastro,
                    PrimeiroNome = retorno.PrimeiroNome,
                    UltimoNome = retorno.UltimoNome,
                    Cep = retorno.Cep,
                    Complemento = retorno.Complemento,
                    Cpf = retorno.Cpf,
                    Email = retorno.Email,
                    Endereco = retorno.Endereco,
                    Numero = retorno.Numero,
                    Rua = retorno.Rua,
                    Senha = retorno.Senha,
                    Sexo = retorno.Sexo,

                });

            }

            if (LoginModels.IsLogado())
                return RedirectToAction("index", "Cadastro");
            else
            {
                TempData["error"] = "Nenhum usuário encontrado.";
                return View(dto);
            }
        }

        public ActionResult logoff()
        {
            LoginModels.LogOff();
            return RedirectToAction("index", "Login");
        }


        public ActionResult RecuperarSenha()
        {
            return View(new CadastroDTO());
        }

        [HttpPost]
        public ActionResult RecuperarSenha(CadastroDTO dto)
        {
            var retorno = this.business.ListarPorEmail(dto.Email);

            if (retorno != null)
            {
                var mensagem = string.Format(
                    "<p>Prezado(a), {0},<br><br>Segue abaixo suas informações de acesso.<br><br>CPF: {1}<br>Senha: {2}</p>",
                        retorno.PrimeiroNome, retorno.Cpf, retorno.Senha);

                TempData["sucesso"] = InfraStructre.Send.EnviarSenha(retorno.Email, mensagem, "Infromações de Acesso");
            }
            else
                TempData["error"] = "Nenhum usuário encontrado.";

            return View(dto);
        }

    }
}
