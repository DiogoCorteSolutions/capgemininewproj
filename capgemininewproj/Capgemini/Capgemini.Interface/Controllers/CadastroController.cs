using Capgemini.DTO;
using Capgemini.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Interface.Controllers
{
    public class CadastroController : Controller
    {

        private readonly Capgemini.Business.CadastroBusines business;

        public CadastroController()
        {
            this.business = new Business.CadastroBusines();
        }
        //
        // GET: /Cadastro/

        public ActionResult Index()
        {
            var retorno = this.business.GetAll();

            var model = retorno.Select(item => new Cadastro
            {
                IdCadastro = item.IdCadastro,
                PrimeiroNome = item.PrimeiroNome,
                UltimoNome = item.UltimoNome,
                DataCadastro = item.DataCadastro,
                DataNascimento = item.DataNascimento,
                Email = item.Email,
                Endereco = item.Endereco,
                Numero = item.Numero,
                Rua = item.Rua,
                Cep = item.Cep,
                Cpf = item.Cpf,
                Senha = item.Senha,
                Sexo = item.Sexo

            }).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Cadastro();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Cadastro model)
        {
            if (this.business.Exists(model.Cpf))
            {
                TempData["msgsucesso"] = "Cpf ja cadastrado";
                return View(model);
            }
            if (custom.ValidationCPF.IsCpf(model.Cpf))
            {
                try
                {

                    var dto = new CadastroDTO
                    {
                        PrimeiroNome = model.PrimeiroNome,
                        UltimoNome = model.UltimoNome,
                        Cpf = model.Cpf,
                        Sexo = model.Sexo,
                        Senha = model.Senha,
                        Endereco = model.Endereco,
                        DataNascimento = model.DataNascimento,
                        DataCadastro = DateTime.Now,
                        Email = model.Email,
                        Rua = model.Rua,
                        Numero = model.Rua,
                        Cep = model.Cep,
                        Complemento = model.Complemento


                    };

                    if (ModelState.IsValid)
                    {
                        this.business.Save(dto);
                        TempData["msgsucesso"] = "Cadastro efetuado com sucesso";
                    }

                    model.PrimeiroNome = string.Empty;
                    model.UltimoNome = string.Empty;
                    model.Cpf = string.Empty;
                    model.Senha = string.Empty;
                    model.Senha = string.Empty;
                    model.Endereco = string.Empty;
                    model.Email = string.Empty;
                    model.Rua = string.Empty;
                    model.Numero = string.Empty;
                    model.Cep = string.Empty;
                    model.Complemento = string.Empty;

                }
                catch (Exception exception)
                {

                    TempData["msgerro"] = exception.Message.ToString();
                    return View(model);
                }

            }
            else
            {
                TempData["msgerro"] = "Cpf invalido";
            }

            return RedirectToAction("index", "cadastro");

        }

    }
}
