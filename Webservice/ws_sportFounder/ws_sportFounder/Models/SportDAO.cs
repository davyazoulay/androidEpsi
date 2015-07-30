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
    public class SportDAO : ISportDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";

        const string SP_GETSPORTBYID = "SP_GETSPORTBYID";
        const string SP_CREATESPORT = "SP_CREATESPORT";
        //const string SP_UPDATESPORT = "SP_UPDATESPORT";
        const string SP_CHECKIFSPORTEXISTS = "SP_CHECKIFSPORTEXISTS";
        const string SP_GETMESSPORTS = "SP_GETMESSPORTS";
        const string SP_GETSPORTSBYLIEU = "SP_GETSPORTSBYLIEU";

        public SportDAO()
        {
            this._properties = new PropertiesManager.Properties();
            this._connectionString = this._properties.get(CHAINE_CNX);
        }

        public Sport getSportById(int idSport)
        {
            Sport sport = null; 
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETSPORTBYID).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idSport", idSport));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            sport = new Sport(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("type")));
                        }
                    }
                }
            }
            return sport;
        }

        public int createSport(Sport newSport)
        {
            int idNewSport;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CREATESPORT).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nom", newSport.Nom));
                    cmd.Parameters.Add(new SqlParameter("@type", newSport.Type));
                    cnx.Open();
                    cmd.Connection = cnx;
                    idNewSport = int.Parse(cmd.ExecuteScalar().ToString());
                    cnx.Close();
                }
            }
            return idNewSport;
        }

        public List<Sport> getMesSports(int idUser)
        {
            List<Sport> listSports = new List<Sport>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETMESSPORTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            Sport sport = new Sport(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("type")));
                            listSports.Add(sport);
                        }
                    }
                }
            }
            return listSports;
        }

        public List<Sport> getSportsByLieu(int idLieu)
        {
            List<Sport> listSports = new List<Sport>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETSPORTSBYLIEU).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idLieu", idLieu));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            Sport sport = new Sport(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("type")));
                            listSports.Add(sport);
                        }
                    }
                }
            }
            return listSports;
        }

        //public bool updateSport(Sport updatedSport)
        //{
        //    bool updatedOrNot = false;
        //    using (SqlConnection cnx = new SqlConnection(this._connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_UPDATESPORT).ToString()))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", updatedSport.Id));
        //            cmd.Parameters.Add(new SqlParameter("@nom", updatedSport.Nom));
        //            cmd.Parameters.Add(new SqlParameter("@code_postal", updatedSport.CP));
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

       
        public bool exists(int idSport)
        {
            bool sportExists = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CHECKIFSPORTEXISTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", idSport));
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