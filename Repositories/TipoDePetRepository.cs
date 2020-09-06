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
    public class TipoDePetRepository : ITipoDePet
    {
        //Conectando com o banco
        PetContext conexao = new PetContext();
        // Chamando o Comando que vai executar os comandos no banco
        SqlCommand cmd = new SqlCommand();

        public TipoDePet Alterar(int id,TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            //Colocando os Parametros
            cmd.CommandText = "UPDATE TipoDePet SET Descricao = @descricao WHERE IdTipoDePet = @id";

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //encerrar Conexao
            conexao.Desconectar();
            return a;
        }

       
        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            //SELECT por Id
            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";
            // ID = @id!
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet a = new TipoDePet();
            while (dados.Read())
            {
                a.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }
            conexao.Desconectar();
            return a;
        }

  

        public TipoDePet Cadastrar(TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();


            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            //Como é POST ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            return a;

        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            //Mostrando que o Id tem que ser Deletado
            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();



        }

        public List<TipoDePet> LerTodos()
        {
            // Colocando A conexão com o banco
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            //Lista para guardar os Tipos de Pet
            List<TipoDePet> tipoDePets = new List<TipoDePet>();

            //Fazendo o laço
            while (dados.Read())
            {
                tipoDePets.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                    );

            }
            // Conexão Fechada
            conexao.Desconectar();
            return tipoDePets;
        }
    }
}
