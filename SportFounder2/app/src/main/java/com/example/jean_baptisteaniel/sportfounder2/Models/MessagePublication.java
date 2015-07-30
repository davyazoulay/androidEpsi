package com.example.jean_baptisteaniel.sportfounder2.Models;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class MessagePublication {

    private int id_pub;
    private int id_emetteur;
    private String message;
    private Date date;
    
    public MessagePublication () {

    }

    public MessagePublication (int ip, int ie, String m, Date d) {
        this.id_pub = ip;
        this.id_emetteur = ie;
        this.message = m;
        this.date = d;
    }

    public int getId_pub() {
        return id_pub;
    }

    public void setId_pub(int id_pub) {
        this.id_pub = id_pub;
    }

    public int getId_emetteur() {
        return id_emetteur;
    }

    public void setId_emetteur(int id_emetteur) {
        this.id_emetteur = id_emetteur;
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
