using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class ConversationManager
    {
        public List<int> getAmisEnConversation(int userId)
        {
            ConversationDAO convDAO = new ConversationDAO();
            List<int> listUserId = convDAO.getAmisEnConversation(userId);
            List<int> listAmisId = new List<int>();
            foreach (int id in listUserId)
            {
                if (id != userId && !listAmisId.Any(x => x == id))
                {
                    listAmisId.Add(id);
                }
            }

            return listAmisId;
        }

        public List<MessageIntitule> getConversationIntutle(int userId)
        {
            List<int> listAmisId = getAmisEnConversation(userId);
            List<MessageChat> listConvers = new List<MessageChat>();
            ConversationDAO convDao = new ConversationDAO();
            foreach (int amiId in listAmisId)
            {
                listConvers.Add(convDao.getConversationIntitule(userId, amiId));
            }
            List<MessageIntitule> listeIntitules = new List<MessageIntitule>();
            UtilisateurDAO userDao = new UtilisateurDAO();
            foreach (MessageChat msgChat in listConvers)
            {
                bool moi = false;
                int idAmi = msgChat.IdEmmeteur;
                if (msgChat.IdEmmeteur == userId)
                {
                    moi = true;
                    idAmi = msgChat.IdDestinataire;
                }
                listeIntitules.Add(new MessageIntitule(idAmi, userDao.getUserById(idAmi).Prenom, moi, msgChat.Message, msgChat.Date));
            }
            return listeIntitules;
        }

        public Conversation getConversationByIds(int idUser, int idFriend)
        {
            UtilisateurDAO userDao = new UtilisateurDAO();
            Conversation convers = new Conversation(idFriend);
            convers.UserNom = userDao.getUserById(idFriend).Prenom;
            ConversationDAO convDao = new ConversationDAO();
            List<MessageChat> listMsgChat = convDao.getConversationByIds(idUser, idFriend);
            foreach(MessageChat msg in listMsgChat)
            {
                convers.Messages.Add(new MessageSimple(msg, idUser));
            }
            return convers;
        }

        public void sendMessage(int userId, int friendId, string message)
        {
            ConversationDAO convDao = new ConversationDAO();
            convDao.sendMessageChat(userId, friendId, message);
        }
    }
}