using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca d);
        List<Raca> LerTodos();
        Raca BuscarPorId(int id);
        Raca Alterar(int id, Raca d);
        void Excluir(int id);

    }
}
