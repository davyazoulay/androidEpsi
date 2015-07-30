package com.example.jean_baptisteaniel.sportfounder2.Models;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONObject;

import java.util.List;

/**
 * Created by davy.azoulay on 29/07/2015.
 */
public class Conversation {
    private int UserId;
    private String UserNom;
    private List<MessageSimple> Messages;

    public Conversation(){}

    public static Conversation getConversationFromJson(JSONObject json){
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss").create();
        return gson.fromJson(json.toString(), Conversation.class);
    }

    public int getUserId() {
        return UserId;
    }

    public void setUserId(int userId) {
        UserId = userId;
    }

    public String getUserNom() {
        return UserNom;
    }

    public void setUserNom(String userNom) {
        UserNom = userNom;
    }

    public List<MessageSimple> getMessages() {
        return Messages;
    }

    public void setMessages(List<MessageSimple> messages) {
        Messages = messages;
    }
}
