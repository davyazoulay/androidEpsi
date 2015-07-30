package com.example.jean_baptisteaniel.sportfounder2.Models;

import java.util.Date;

/**
 * Created by davy.azoulay on 29/07/2015.
 */
public class MessageSimple {
    private boolean CestMoi;
    private String Message;
    private java.util.Date Date;

    public MessageSimple(){}

    public MessageSimple (boolean cestMoi, String message, Date date){
        CestMoi = cestMoi;
        Message = message;
        Date = date;
    }

    public boolean isCestMoi() {
        return CestMoi;
    }

    public void setCestMoi(boolean cestMoi) {
        CestMoi = cestMoi;
    }

    public String getMessage() {
        return Message;
    }

    public void setMessage(String message) {
        Message = message;
    }

    public java.util.Date getDate() {
        return Date;
    }

    public void setDate(java.util.Date date) {
        Date = date;
    }
}
