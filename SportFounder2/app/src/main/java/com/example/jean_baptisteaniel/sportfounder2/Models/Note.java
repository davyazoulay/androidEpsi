package com.example.jean_baptisteaniel.sportfounder2.Models;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Note {

    private int id_utilisateur;
    private int id_lieu;
    private int note;
    private String message;
    private Date date;

    public Note() {
    }

    public Note(int id_utilisateur, int id_lieu, int note, String message, Date date) {
        this.id_utilisateur = id_utilisateur;
        this.id_lieu = id_lieu;
        this.note = note;
        this.message = message;
        this.date = date;
    }

    public int getId_utilisateur() {
        return id_utilisateur;
    }

    public void setId_utilisateur(int id_utilisateur) {
        this.id_utilisateur = id_utilisateur;
    }

    public int getId_lieu() {
        return id_lieu;
    }

    public void setId_lieu(int id_lieu) {
        this.id_lieu = id_lieu;
    }

    public int getNote() {
        return note;
    }

    public void setNote(int note) {
        this.note = note;
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
