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
    public class commandeado
    {
        public void Inserer(commande Cm)
        {
            SqlCommand cmdaj = new SqlCommand("insert into produit(cin,numcde,date) values (@Cin,@numcde,@date)", Connexion.cn);
            cmdaj.Parameters.AddWithValue("@Cin", Cm.cin);
            cmdaj.Parameters.AddWithValue("@Nom", Cm.numcde);
            cmdaj.Parameters.AddWithValue("@Pren", Cm.date);
            cmdaj.ExecuteNonQuery();
        }
        public static bool Existe_Client(Int64 Cin)
        {
            SqlCommand cverif = new SqlCommand("select * from produit where cin = @Cin", Connexion.cn);
            cverif.Parameters.AddWithValue("@Cin", Cin);
            SqlDataReader drverif = cverif.ExecuteReader();
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
            string req = "delete from produit where Cin = @Cin";
            SqlCommand cmdsupp = new SqlCommand(req, Connexion.cn);
            cmdsupp.Parameters.AddWithValue("@Cin", Cin);
            cmdsupp.ExecuteNonQuery();
        }
        public void Modifier(commande Cm)
        {
            string req = "update produit set Nom_Cl=@Nom,Pren_Cl=@Pren, Ville_Cl=@Ville, Tel_Cl=@Tel where Cin_Cl =@Cin";
            SqlCommand cmdmaj = new SqlCommand(req, Connexion.cn);
            cmdmaj.Parameters.AddWithValue("@Nom", Cm.cin);
            cmdmaj.Parameters.AddWithValue("@Pren", Cm.numcde);
            cmdmaj.Parameters.AddWithValue("@Ville", Cm.date);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from Client where Cin_Cl=@Cin", Connexion.cn);
            da.SelectCommand.Parameters.AddWithValue("@Cin", Cin);
            da.Fill(dtcl);
            return dtcl;
        }
        public static DataTable Liste_Client_Cde(Int64 NCde)
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select cl.* from Client cl, Commande c where cl.Cin_Cl=c.Cin_Cl and c.Num_Cde=@Num", Connexion.cn);
            da.SelectCommand.Parameters.AddWithValue("@Num", NCde);
            da.Fill(dtcl);
            return dtcl;
        }
    }
}
