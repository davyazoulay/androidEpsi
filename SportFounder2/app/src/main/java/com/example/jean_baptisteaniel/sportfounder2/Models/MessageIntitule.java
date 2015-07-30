package com.example.jean_baptisteaniel.sportfounder2.Models;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import org.json.JSONArray;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * Created by davy.azoulay on 28/07/2015.
 */
public class MessageIntitule {
    private int IdAmi;
    private String NomAmi;
    private boolean CestMoi;
    private String Message;
    private Date Date;

    public MessageIntitule(){}

    public MessageIntitule(int idAmi, String nomAmi, boolean cestMoi, String message, Date date)
    {
        IdAmi=idAmi;
        NomAmi=nomAmi;
        CestMoi=cestMoi;
        Message = message;
        Date = date;
    }

    public static List<MessageIntitule> getMessageIntuleFromJson(JSONArray json){
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss").create();
        Type listType = new TypeToken<ArrayList<MessageIntitule>>() {
        }.getType();
        return gson.fromJson(json.toString(), listType);
    }

    public int getIdAmi() {
        return IdAmi;
    }

    public void setIdAmi(int idAmi) {
        IdAmi = idAmi;
    }

    public String getNomAmi() {
        return NomAmi;
    }

    public void setNomAmi(String nomAmi) {
        NomAmi = nomAmi;
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
