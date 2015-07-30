using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ws_sportFounder.Managers;

namespace ws_sportFounder.Controllers.RestControllers
{
    public class ConversationController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Conversation/GetMesConversations/{idUser}")]
        public IHttpActionResult GetMesConversations([FromUri]int idUser)
        {
            if (idUser > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser))
                    {
                        List<MessageIntitule> listMsg = Librairie.Conversations.getConversationIntutle(idUser);
                        return Ok(listMsg);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Conversation/GetConversationByIds/{idUser}/{idFriend}")]
        public IHttpActionResult GetConversationByIds([FromUri]int idUser, [FromUri]int idFriend)
        {
            if (idUser > 0 && idFriend > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser) && Librairie.Utilisateurs.exists(idFriend))
                    {
                        Conversation convers = Librairie.Conversations.getConversationByIds(idUser, idFriend);
                        return Ok(convers);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Conversation/SendMessageChat/{idUser}/{idFriend}")]
        public IHttpActionResult SendMessageChat([FromUri]int idUser, [FromUri]int idFriend, [FromBody]string message)
        {
            if (idUser > 0 && idFriend > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser) && Librairie.Utilisateurs.exists(idFriend))
                    {
                        Librairie.Conversations.sendMessage(idUser, idFriend, message);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
