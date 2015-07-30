using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ws_sportFounder.Models
{
    public class GroupeDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";

        const string SP_GETGROUPEBYID = "SP_GETGROUPEBYID";
        const string SP_CREATEGROUPE = "SP_CREATEGROUPE";
        //const string SP_UPDATEGROUPE = "SP_UPDATEGROUPE";
        const string SP_CHECKIFGROUPEEXISTS = "SP_CHECKIFGROUPEEXISTS";
        const string SP_GETLISTUSERS = "SP_GETLISTUSERS";

        public GroupeDAO()
        {
            this._properties = new PropertiesManager.Properties();
            this._connectionString = this._properties.get(CHAINE_CNX);
        }

        public Groupe getGroupeById(int idGroupe)
        {
            Groupe groupe = null; 
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETGROUPEBYID).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idGroupe", idGroupe));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            groupe = new Groupe(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("libelle")),
                                reader.GetString(reader.GetOrdinal("description")));
                        }
                    }
                }
            }
            return groupe;
        }

        public int createGroupe(Groupe newGroupe)
        {
            int idNewGroupe;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CREATEGROUPE).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nom", newGroupe.Nom));
                    cmd.Parameters.Add(new SqlParameter("@libelle", newGroupe.Libelle));
                    cmd.Parameters.Add(new SqlParameter("@description", newGroupe.Description));
                    cnx.Open();
                    cmd.Connection = cnx;
                    idNewGroupe = int.Parse(cmd.ExecuteScalar().ToString());
                    cnx.Close();
                }
            }
            return idNewGroupe;
        }

        public List<Utilisateur> getListUsers(int idGroupe)
        {
            List<Utilisateur> listUsers = new List<Utilisateur>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETLISTUSERS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idGroupe", idGroupe));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            Utilisateur utilisateur = new Utilisateur(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("login")),
                                reader.GetString(reader.GetOrdinal("mdp")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("prenom")),
                                reader.GetString(reader.GetOrdinal("email")),
                                reader.GetDateTime(reader.GetOrdinal("date_naissance")),
                                reader.GetString(reader.GetOrdinal("pays")),
                                reader.GetString(reader.GetOrdinal("ville")),
                                reader.GetString(reader.GetOrdinal("code_postal")),
                                reader.GetInt32(reader.GetOrdinal("type")));
                            listUsers.Add(utilisateur);
                        }
                    }
                }
            }
            return listUsers;
        }

        //public bool updateGroupe(Groupe updatedGroupe)
        //{
        //    bool updatedOrNot = false;
        //    using (SqlConnection cnx = new SqlConnection(this._connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_UPDATEGROUPE).ToString()))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", updatedGroupe.Id));
        //            cmd.Parameters.Add(new SqlParameter("@nom", updatedGroupe.Nom));
        //            cmd.Parameters.Add(new SqlParameter("@code_postal", updatedGroupe.CP));
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

       
        public bool exists(int idGroupe)
        {
            bool groupeExists = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CHECKIFGROUPEEXISTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", idGroupe));
                    cnx.Open();
                    cmd.Connection = cnx;
                    if ((int)cmd.ExecuteScalar() >= 1)
                    {
                        groupeExists = true;
                    }
                }
            }
            return groupeExists;
        }
    }
}