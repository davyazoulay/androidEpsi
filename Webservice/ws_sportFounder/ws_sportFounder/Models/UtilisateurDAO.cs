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
    public class UtilisateurDAO : IUtilisateurDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";

        const string SP_GETUSERBYID = "SP_GETUSERBYID";
        const string SP_CREATEUSER = "SP_CREATEUSER";
        const string SP_UPDATEUSER = "SP_UPDATEUSER";
        const string SP_CHECKIFUSEREXISTS = "SP_CHECKIFUSEREXISTS";
        const string SP_GETUSERBYLOGIN = "SP_GETUSERBYLOGIN";
        const string SP_GETLISTAMIS = "SP_GETLISTAMIS";
        const string SP_ADDSPORTFORUSER = "SP_ADDSPORTFORUSER";
        const string SP_ADDFRIEND = "SP_ADDFRIEND";
        const string SP_GETLISTGROUPES = "SP_GETLISTGROUPES";

        public UtilisateurDAO()
        {
            this._properties = new PropertiesManager.Properties();
            this._connectionString = this._properties.get(CHAINE_CNX);
        }

        public Utilisateur getUserById(int idUser)
        {
            Utilisateur utilisateur = null;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETUSERBYID).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            utilisateur = new Utilisateur(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("prenom")),
                                reader.GetString(reader.GetOrdinal("email")),
                                reader.GetDateTime(reader.GetOrdinal("date_naissance")),
                                reader.GetString(reader.GetOrdinal("pays")),
                                reader.GetString(reader.GetOrdinal("ville")),
                                reader.GetString(reader.GetOrdinal("code_postal")));
                        }
                    }
                }
            }
            return utilisateur;
        }

        public List<Utilisateur> getListAmis(int idUser)
        {
            List<Utilisateur> listAmis = new List<Utilisateur>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETLISTAMIS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            Utilisateur utilisateur = new Utilisateur(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("prenom")),
                                reader.GetString(reader.GetOrdinal("email")),
                                reader.GetDateTime(reader.GetOrdinal("date_naissance")),
                                reader.GetString(reader.GetOrdinal("pays")),
                                reader.GetString(reader.GetOrdinal("ville")),
                                reader.GetString(reader.GetOrdinal("code_postal")));
                            listAmis.Add(utilisateur);
                        }
                    }
                }
            }
            return listAmis;
        }

        public List<Groupe> getListGroupes(int idUser)
        {
            List<Groupe> listGroupes = new List<Groupe>();
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETLISTGROUPES)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            Groupe groupe = new Groupe(reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("nom")),
                                reader.GetString(reader.GetOrdinal("libelle")),
                                reader.GetString(reader.GetOrdinal("description")));
                            listGroupes.Add(groupe);
                        }
                    }
                }
            }
            return listGroupes;
        }


        public int createUser(Utilisateur newUser)
        {
            int idNewUser;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CREATEUSER).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@login", newUser.Login));
                    cmd.Parameters.Add(new SqlParameter("@mdp", newUser.Mdp));
                    cmd.Parameters.Add(new SqlParameter("@nom", newUser.Nom));
                    cmd.Parameters.Add(new SqlParameter("@prenom", newUser.Prenom));
                    cmd.Parameters.Add(new SqlParameter("@email", newUser.Email));
                    cmd.Parameters.Add(new SqlParameter("@date_naissance", newUser.DateNaissance));
                    cmd.Parameters.Add(new SqlParameter("@pays", newUser.Pays));
                    cmd.Parameters.Add(new SqlParameter("@ville", newUser.Ville));
                    cmd.Parameters.Add(new SqlParameter("@code_postal", newUser.CP));
                    cnx.Open();
                    cmd.Connection = cnx;
                    idNewUser = int.Parse(cmd.ExecuteScalar().ToString());
                    cnx.Close();
                }
            }
            return idNewUser;
        }

        public bool updateUser(Utilisateur updatedUser)
        {
            bool updatedOrNot = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_UPDATEUSER).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", updatedUser.Id));
                    cmd.Parameters.Add(new SqlParameter("@login", updatedUser.Login));
                    cmd.Parameters.Add(new SqlParameter("@mdp", updatedUser.Mdp));
                    cmd.Parameters.Add(new SqlParameter("@nom", updatedUser.Nom));
                    cmd.Parameters.Add(new SqlParameter("@prenom", updatedUser.Prenom));
                    cmd.Parameters.Add(new SqlParameter("@email", updatedUser.Email));
                    cmd.Parameters.Add(new SqlParameter("@date_naissance", updatedUser.DateNaissance));
                    cmd.Parameters.Add(new SqlParameter("@pays", updatedUser.Pays));
                    cmd.Parameters.Add(new SqlParameter("@ville", updatedUser.Ville));
                    cmd.Parameters.Add(new SqlParameter("@code_postal", updatedUser.CP));
                    cnx.Open();
                    cmd.Connection = cnx;
                    if (cmd.ExecuteNonQuery() > 1)
                    {
                        updatedOrNot = true;
                    }
                    cnx.Close();
                }
            }
            return updatedOrNot;
        }

        public Utilisateur getUserByLogin(string login)
        {
            Utilisateur utilisateur = null;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_GETUSERBYLOGIN).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@login", login));
                    cnx.Open();
                    cmd.Connection = cnx;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            utilisateur = new Utilisateur(reader.GetInt32(reader.GetOrdinal("id")),
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
                        }
                    }
                }
            }
            return utilisateur;
        }

        public void addSport(int idUser, int idSport)
        {
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_ADDSPORTFORUSER).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_user", idUser));
                    cmd.Parameters.Add(new SqlParameter("@id_sport", idSport));
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.ExecuteScalar();
                }
            }
        }

        public void addFriend(int idUser, int idFriend)
        {
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_ADDFRIEND).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_user", idUser));
                    cmd.Parameters.Add(new SqlParameter("@id_friend", idFriend));
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.ExecuteScalar();
                }
            }
        }

        public bool exists(int idUser)
        {
            bool userExists = false;
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_CHECKIFUSEREXISTS).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", idUser));
                    cnx.Open();
                    cmd.Connection = cnx;
                    if ((int)cmd.ExecuteScalar() >= 1)
                    {
                        userExists = true;
                    }
                }
            }
            return userExists;
        }
    }
}