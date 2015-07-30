using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ws_sportFounder.Models
{
    public class ConversationDAO
    {
        private string _connectionString;
        private PropertiesManager.Properties _properties;

        const string CHAINE_CNX = "CHAINE_CNX";
        const string SP_GETAMISENCONVERSATION = "SP_GETAMISENCONVERSATION";
        const string SP_GETCONVERSATIONINTITULE = "SP_GETCONVERSATIONINTITULE";
        const string SP_GETCONVERSATIONBYIDS = "SP_GETCONVERSATIONBYIDS";
        const string SP_SENDMESSAGECHAT = "SP_SENDMESSAGECHAT";

        public ConversationDAO()
        {
            _properties = new PropertiesManager.Properties();
            _connectionString = _properties.get(CHAINE_CNX);
        }

        public List<int> getAmisEnConversation(int idUser)
        {
            List<int> amisConvers = new List<int>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_properties.get(SP_GETAMISENCONVERSATION)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    con.Open();
                    cmd.Connection = con;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(reader.GetOrdinal("id_expediteur"));
                            int user2Id = reader.GetInt32(reader.GetOrdinal("id_destinataire"));
                            amisConvers.Add(userId);
                        }
                    }
                }
            }
            return amisConvers;
        }

        public MessageChat getConversationIntitule(int idUser, int idAmi)
        {
            MessageChat msgChat = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_properties.get(SP_GETCONVERSATIONINTITULE)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cmd.Parameters.Add(new SqlParameter("@idFriend", idAmi));
                    con.Open();
                    cmd.Connection = con;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            msgChat = new MessageChat(reader.GetInt32(reader.GetOrdinal("id_expediteur")),
                                reader.GetInt32(reader.GetOrdinal("id_destinataire")),
                                reader.GetString(reader.GetOrdinal("message")),
                                reader.GetDateTime(reader.GetOrdinal("date")));
                        }
                    }
                }
            }
            return msgChat;
        }

        public List<MessageChat> getConversationByIds(int idUser, int idAmi)
        {
            List<MessageChat> listMsgChat = new List<MessageChat>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_properties.get(SP_GETCONVERSATIONBYIDS)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cmd.Parameters.Add(new SqlParameter("@idFriend", idAmi));
                    con.Open();
                    cmd.Connection = con;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            MessageChat msgChat = new MessageChat(reader.GetInt32(reader.GetOrdinal("id_expediteur")),
                                reader.GetInt32(reader.GetOrdinal("id_destinataire")),
                                reader.GetString(reader.GetOrdinal("message")),
                                reader.GetDateTime(reader.GetOrdinal("date")));
                            listMsgChat.Add(msgChat);
                        }
                    }
                }
            }
            return listMsgChat;
        }

        public void sendMessageChat(int idUser, int idFriend, string message)
        {
            using (SqlConnection cnx = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(this._properties.get(SP_SENDMESSAGECHAT).ToString()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idUser", idUser));
                    cmd.Parameters.Add(new SqlParameter("@idFriend", idFriend));
                    cmd.Parameters.Add(new SqlParameter("@message", message));
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.ExecuteScalar();
                }
            }
        }
    }
}