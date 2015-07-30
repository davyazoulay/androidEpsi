package com.example.jean_baptisteaniel.sportfounder2.Models;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Chat {

    private int id1;
    private int id2;
    private String message;
    private Date date;

    public Chat() {
    }

    public Chat(int id1, int id2, String message, Date date) {

        this.id1 = id1;
        this.id2 = id2;
        this.message = message;
        this.date = date;
    }
    public int getId1() {
        return id1;
    }

    public void setId1(int id1) {
        this.id1 = id1;
    }

    public int getId2() {
        return id2;
    }

    public void setId2(int id2) {
        this.id2 = id2;
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
