using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet a);
        List<TipoDePet> LerTodos();
        TipoDePet BuscarPorId(int id);
        TipoDePet Alterar(TipoDePet a);
        TipoDePet Excluir(TipoDePet a);
    }
}
