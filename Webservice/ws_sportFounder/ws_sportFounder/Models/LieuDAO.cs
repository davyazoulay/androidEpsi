using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ws_sportFounder.Models
{
    public class LieuDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";

        const string SP_GETLIEUBYID = "SP_GETLIEUBYID";
        const string SP_CREATELIEU = "SP_CREATELIEU";
        //const string SP_UPDATELIEU = "SP_UPDATELIEU";
        const string SP_CHECKIFLIEUEXISTS = "SP_CHECKIFLIEUEXISTS";
        const string SP_GETLIEUBYSPORT = "SP_GETLIEUBYSPORT";
        const string SP_GETALLLIEUX = "SP_GETALLLIEUX";

        public LieuDAO()
        {
            this._properties = new PropertiesManager.Properties();
            this._connectionString = this._properties.get(CHAINE_CNX);
        }

        public Lieu getLieuById(int idLieu)
        {
            Lieu lieu = null; 
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETLIEUBYID).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idLieu", idLieu));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            lieu = new Lieu(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("libelle")),
                                reader.GetString(reader.GetOrdinal("description")),
                                reader.GetString(reader.GetOrdinal("code_postal")),
                                reader.GetString(reader.GetOrdinal("latitude")),
                                reader.GetString(reader.GetOrdinal("longitude")));
                        }
                    }
                }
            }
            return lieu;
        }

        public List<Lieu> getAllLieux()
        {
            List<Lieu> lieux = new List<Lieu>() ;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETALLLIEUX).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            Lieu lieu = new Lieu(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("libelle")),
                                reader.GetString(reader.GetOrdinal("description")),
                                reader.GetString(reader.GetOrdinal("code_postal")),
                                reader.GetString(reader.GetOrdinal("latitude")),
                                reader.GetString(reader.GetOrdinal("longitude")));
                            lieux.Add(lieu);
                        }
                    }
                }
            }
            return lieux;
        }

        public List<Lieu> getLieuxBySport(int idSport)
        {
            List<Lieu> listLieux = new List<Lieu>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETLIEUBYSPORT).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idSport", idSport));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            Lieu lieu = new Lieu(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("libelle")),
                                reader.GetString(reader.GetOrdinal("description")),
                                reader.GetString(reader.GetOrdinal("code_postal")),
                                reader.GetString(reader.GetOrdinal("latitude")),
                                reader.GetString(reader.GetOrdinal("longitude")));
                            listLieux.Add(lieu);
                        }
                    }
                }
            }
            return listLieux;
        }

        public int createLieu(Lieu newLieu)
        {
            int idNewLieu;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CREATELIEU).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nom", newLieu.Nom));
                    cmd.Parameters.Add(new SqlParameter("@libelle", newLieu.Libelle));
                    cmd.Parameters.Add(new SqlParameter("@description", newLieu.Description));
                    cmd.Parameters.Add(new SqlParameter("@code_postal", newLieu.CP));
                    cmd.Parameters.Add(new SqlParameter("@latitude", newLieu.Latitude));
                    cmd.Parameters.Add(new SqlParameter("@longitude", newLieu.Longitude));
                    cnx.Open();
                    cmd.Connection = cnx;
                    idNewLieu = int.Parse(cmd.ExecuteScalar().ToString());
                    cnx.Close();
                }
            }
            return idNewLieu;
        }

        //public bool updateLieu(Lieu updatedLieu)
        //{
        //    bool updatedOrNot = false;
        //    using (SqlConnection cnx = new SqlConnection(this._connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_UPDATELIEU).ToString()))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", updatedLieu.Id));
        //            cmd.Parameters.Add(new SqlParameter("@nom", updatedLieu.Nom));
        //            cmd.Parameters.Add(new SqlParameter("@code_postal", updatedLieu.CP));
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

       
        public bool exists(int idLieu)
        {
            bool sportExists = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CHECKIFLIEUEXISTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", idLieu));
                    cnx.Open();
                    cmd.Connection = cnx;
                    if ((int)cmd.ExecuteScalar() >= 1)
                    {
                        sportExists = true;
                    }
                }
            }
            return sportExists;
        }
    }
}