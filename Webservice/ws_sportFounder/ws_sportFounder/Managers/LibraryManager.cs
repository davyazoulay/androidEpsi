using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_sportFounder.Managers
{
    public class LibraryManager
    {
        UtilisateurManager _utilisateurManager;
        VilleManager _villeManager;
        SportManager _sportManager;
        LieuManager _lieuManager;
        GroupeManager _groupeManager;
        ConversationManager _conversationManager;

        public LibraryManager() { }

        public UtilisateurManager Utilisateurs
        {
            get
            {
                if (_utilisateurManager == null)
                    return _utilisateurManager = new UtilisateurManager();
                else
                    return _utilisateurManager;
            }
        }

        public VilleManager Villes
        {
            get
            {
                if (_villeManager == null)
                    return _villeManager = new VilleManager();
                else
                    return _villeManager;
            }
        }

        public SportManager Sports
        {
            get
            {
                if (_sportManager == null)
                    return _sportManager = new SportManager();
                else
                    return _sportManager;
            }
        }

        public LieuManager Lieus
        {
            get
            {
                if (_lieuManager == null)
                    return _lieuManager = new LieuManager();
                else
                    return _lieuManager;
            }
        }

        public GroupeManager Groupes
        {
            get
            {
                if (_groupeManager == null)
                    return _groupeManager = new GroupeManager();
                else
                    return _groupeManager;
            }
        }

        public ConversationManager Conversations
        {
            get
            {
                if (_conversationManager == null)
                    _conversationManager = new ConversationManager();
                return _conversationManager;
            }
        }
    }
}