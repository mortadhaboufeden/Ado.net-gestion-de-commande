using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Connexion
    {
            public static SqlConnection cn;
            public static string cnxstring = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Gestcom;Integrated Security=True";
            public static void Ouvrir()
            {
                cn = new SqlConnection();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.ConnectionString = cnxstring;
                    cn.Open();
                }

            }
            public static void Fermer()
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
    }
}
