using Capgemini.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Data
{
    public class CadastroData
    {
        private readonly Capgemini.Infra.Context.DefaultContext _context;

        public CadastroData()
        {
            this._context = new Infra.Context.DefaultContext();
        }
        public IEnumerable<CadastroDTO> GetAll()
        {
            return this._context.Cadastroes;
        }
        public void Delete(int id)
        {
            var filtro = this._context.Cadastroes.Find(id);
            this._context.Entry(filtro).State = System.Data.Entity.EntityState.Deleted;
            this._context.SaveChanges();
        }
        public void Save(CadastroDTO dto)
        {
            this._context.Cadastroes.Add(dto);
            this._context.SaveChanges();
        }
        public void Update(CadastroDTO dto)
        {
            this._context.Entry(dto).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
        public bool Exists(string cpf)
        {
            return this._context.Cadastroes.ToList().Exists(x => x.Cpf == cpf);
        }
        public CadastroDTO Login(string senha, string cpf)
        {
            return this._context.Cadastroes.ToList().FirstOrDefault(x => x.Senha.Equals(senha) && x.Cpf.Equals(cpf));
        }
        public CadastroDTO ListarPorEmail(string email)
        {
            return this._context.Cadastroes.ToList().FirstOrDefault(x => x.Email.Equals(email));
        }


    }
}
