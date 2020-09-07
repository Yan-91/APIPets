using APIPets.Context;
using APIPets.Domains;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Repositories
{
    public class RacaRepository : IRaca
    {
        //Conectando com o banco
        PetContext conexao = new PetContext();
        // Chamando o Comando que vai executar os comandos no banco
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca d)
        {
            cmd.Connection = conexao.Conectar();

            //Colocando os Parametros
            cmd.CommandText = "UPDATE Raca SET Descricao = @descricao WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@descricao", d.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //encerrar Conexao
            conexao.Desconectar();
            return d;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //SELECT por Id
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            // ID = @id!
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca d = new Raca();
            while (dados.Read())
            {
                d.IdRaca    = Convert.ToInt32(dados.GetValue(0));
                d.Descricao = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return d;
        }

        public Raca Cadastrar(Raca d)
        {
            cmd.Connection = conexao.Conectar();


            cmd.CommandText =
                "INSERT INTO Raca (Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", d.Descricao);

            //Como é POST ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            return d;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            //Mostrando que o Id tem que ser Deletado
            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();


        }

        public List<Raca> LerTodos()
        {
            // Colocando A conexão com o banco
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();
            //Lista para guardar as Raças
            List<Raca> racas = new List<Raca>();
            //Fazendo o Laço
            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca    = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
             );
             }
            conexao.Desconectar();
            return racas;
        }
    }
}
