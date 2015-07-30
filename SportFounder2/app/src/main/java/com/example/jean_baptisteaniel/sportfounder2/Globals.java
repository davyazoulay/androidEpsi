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
    private int groupe_id;
    private int sport_id;

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

    public int getGroupe_id() {
        return groupe_id;
    }

    public void setGroupe_id(int groupe_id) {
        this.groupe_id = groupe_id;
    }

    public int getSport_id() {
        return sport_id;
    }

    public void setSport_id(int sport_id) {
        this.sport_id = sport_id;
    }
}
