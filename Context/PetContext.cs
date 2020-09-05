using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Context
{
    public class PetContext
    {
        SqlConnection con = new SqlConnection();

        public PetContext()
        {
            con.ConnectionString = @"Data Source = DESKTOP - EKBOU6F\SQLEXPRESS; Initial Catalog = PetShop; Persist Security Info = True; User ID = sa; Password = ***********";
        }
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();

            }
            return con;
        }
        public void Desconectar()
        {
            con.Close();
        }   
    }
}
