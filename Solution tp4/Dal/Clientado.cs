using bibliotheque_de_classe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Clientado
    {

        public void Inserer(Client C)
        {
            SqlCommand cmdaj = new SqlCommand("insert into Client(Cin,NOM,Prenom,ville,Tel) values (@Cin,@NOM,@Prenom,@ville,@Tel)", Connexion.cn);
            cmdaj.Parameters.AddWithValue("@Cin", C.Cin);
            cmdaj.Parameters.AddWithValue("@Nom", C.NOM);
            cmdaj.Parameters.AddWithValue("@Pren", C.Prenom);
            cmdaj.Parameters.AddWithValue("@Ville", C.ville);
            cmdaj.Parameters.AddWithValue("@Tel", C.Tel);
            cmdaj.ExecuteNonQuery();
        }
        public static bool Existe_Client(Int64 Cin)
        {
            SqlDataReader drverif;
            SqlCommand cverif = new SqlCommand("select * from Client where Cin = @Cin", Connexion.cn);
            cverif.Connection = Connexion.cn;
            cverif.Parameters.AddWithValue("@Cin", Cin);
             drverif = cverif.ExecuteReader();
            if (drverif.HasRows == true)
            {
                drverif.Close();
                return true;
            }
            else
            {
                drverif.Close();
                return false;
            }
        }
        public void Supprimer(Int64 Cin)
        {
            string req = "delete from Client where Cin = @Cin";
            SqlCommand cmdsupp = new SqlCommand(req, Connexion.cn);
            _ = cmdsupp.Parameters.AddWithValue("@Cin", Cin);
            cmdsupp.ExecuteNonQuery();
        }
        public void Modifier(Client C)
        {
            string req = "update Client set NOM=@Nom,Prenom=@Pren, ville=@Ville, Tel=@Tel where Cin =@Cin";
            SqlCommand cmdmaj = new SqlCommand(req, Connexion.cn);
            cmdmaj.Parameters.AddWithValue("@Nom", C.NOM);
            cmdmaj.Parameters.AddWithValue("@Pren", C.Prenom);
            cmdmaj.Parameters.AddWithValue("@Ville", C.ville);
            cmdmaj.Parameters.AddWithValue("@Tel", C.Tel);
            cmdmaj.Parameters.AddWithValue("@Cin", C.Cin);
            cmdmaj.ExecuteNonQuery();
        }

        public static DataTable Liste_Client()
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Client", Connexion.cn);
            da.Fill(dtcl);
            return dtcl;
        }
        public static DataTable Liste_Client(Int64 Cin)
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Client where Cin=@Cin", Connexion.cn);
            da.SelectCommand.Parameters.AddWithValue("@Cin", Cin);
            da.Fill(dtcl);
            return dtcl;
        }
        public static DataTable Liste_Client_Cde(Int64 NCde)
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cl.* from Client cl, Commande c where cl.Cin=c.Cin and c.numcde=@Num", Connexion.cn);
            da.SelectCommand.Parameters.AddWithValue("@Num", NCde);
            da.Fill(dtcl);
            return dtcl;
        }
    }
}
