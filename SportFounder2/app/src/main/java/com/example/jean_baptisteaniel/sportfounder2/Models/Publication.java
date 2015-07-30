package com.example.jean_baptisteaniel.sportfounder2.Models;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Publication {

    private int id;
    private int id_groupe;
    private int id_emmeteur;
    private String message;
    private Date date;

    public Publication () {

    }

    public Publication (int i, int ig, int ie, String m, Date d) {
        this.id = i;
        this.id_groupe = ig;
        this.id_emmeteur = ie;
        this.message = m;
        this.date = d;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getId_groupe() {
        return id_groupe;
    }

    public void setId_groupe(int id_groupe) {
        this.id_groupe = id_groupe;
    }

    public int getId_emmeteur() {
        return id_emmeteur;
    }

    public void setId_emmeteur(int id_emmeteur) {
        this.id_emmeteur = id_emmeteur;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
