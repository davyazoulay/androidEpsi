using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ws_sportFounder.Models.DaoInterfaces;

namespace ws_sportFounder.Models
{
    public class VilleDAO : IVilleDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";

        const string SP_GETVILLEBYID = "SP_GETVILLEBYID";
        const string SP_CREATEVILLE = "SP_CREATEVILLE";
        //const string SP_UPDATEVILLE = "SP_UPDATEVILLE";
        const string SP_CHECKIFVILLEEXISTS = "SP_CHECKIFVILLEEXISTS";

        public VilleDAO()
        {
            this._properties = new PropertiesManager.Properties();
            this._connectionString = this._properties.get(CHAINE_CNX);
        }

        public Ville getVilleById(int idVille)
        {
            Ville ville = null; 
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETVILLEBYID).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idVille", idVille));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            ville = new Ville(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("code_postal")));
                        }
                    }
                }
            }
            return ville;
        }

        public int createVille(Ville newVille)
        {
            int idNewVille;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CREATEVILLE).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nom", newVille.Nom));
                    cmd.Parameters.Add(new SqlParameter("@code_postal", newVille.CP));
                    cnx.Open();
                    cmd.Connection = cnx;
                    idNewVille = int.Parse(cmd.ExecuteScalar().ToString());
                    cnx.Close();
                }
            }
            return idNewVille;
        }

        //public bool updateVille(Ville updatedVille)
        //{
        //    bool updatedOrNot = false;
        //    using (SqlConnection cnx = new SqlConnection(this._connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_UPDATEVILLE).ToString()))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", updatedVille.Id));
        //            cmd.Parameters.Add(new SqlParameter("@nom", updatedVille.Nom));
        //            cmd.Parameters.Add(new SqlParameter("@code_postal", updatedVille.CP));
        //            cnx.Open();
        //            cmd.Connection = cnx;
        //            if (cmd.ExecuteNonQuery() > 1)
        //            {
        //                updatedOrNot = true;
        //            }
        //            cnx.Close();
        //        }
        //    }
        //    return updatedOrNot;
        //}

       
        public bool exists(int idVille)
        {
            bool villeExists = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CHECKIFVILLEEXISTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", idVille));
                    cnx.Open();
                    cmd.Connection = cnx;
                    if ((int)cmd.ExecuteScalar() >= 1)
                    {
                        villeExists = true;
                    }
                }
            }
            return villeExists;
        }
    }
}