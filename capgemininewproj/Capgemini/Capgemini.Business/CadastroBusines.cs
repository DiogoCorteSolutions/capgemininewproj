using Capgemini.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Business
{
    public class CadastroBusines
    {
        private readonly Capgemini.Data.CadastroData data;

        public CadastroBusines()
        {
            this.data = new Data.CadastroData();
        }
        public IEnumerable<CadastroDTO> GetAll()
        {
            return this.data.GetAll();
        }
        public void Save(CadastroDTO dto)
        {
            this.data.Save(dto);
        }
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
        public void Update(CadastroDTO dto)
        {
            this.data.Update(dto);
        }
        public bool Exists(string cpf)
        {
            return this.data.Exists(cpf);
        }
        public CadastroDTO Login(string senha, string cpf)
        {
            return this.data.Login(senha, cpf);
        }
        public CadastroDTO ListarPorEmail(string email)
        {
            return this.data.ListarPorEmail(email);
        }
    }
}
