using APIPets.Context;
using APIPets.Domains;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        //Conectando com o banco
        PetContext conexao = new PetContext();

        public TipoDePet Alterar(TipoDePet a)
        {
            throw new NotImplementedException();
        }

        public TipoDePet BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public TipoDePet Cadastrar(TipoDePet a)
        {
            throw new NotImplementedException();
        }

        public TipoDePet Excluir(TipoDePet a)
        {
            throw new NotImplementedException();
        }

        public List<TipoDePet> LerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
