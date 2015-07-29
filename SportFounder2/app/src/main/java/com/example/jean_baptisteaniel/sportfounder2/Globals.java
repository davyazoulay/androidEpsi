package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Application;

import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;

/**
 * Created by jean-baptisteaniel on 25/06/15.
 */
public class Globals extends Application {
    private int user_id = 0;
    private Utilisateur user;
    private int friend_id;

    public int getUser_id() {
        return user_id;
    }

    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }

    public Utilisateur getUser() {
        return user;
    }

    public void setUser(Utilisateur user) {
        this.user = user;
    }

    public int getFriend_id() {
        return friend_id;
    }

    public void setFriend_id(int friend_id) {
        this.friend_id = friend_id;
    }
}
