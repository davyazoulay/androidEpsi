package com.example.jean_baptisteaniel.sportfounder2.Models;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Sport {

    private int Id;
    private String Nom;
    private String Type;

    public Sport () {}

    public Sport (int id,String nom, String type) {
        Id = id;
        Nom = nom;
        Type = type;
    }

    public static List<Sport> getListeSportsFromJson(JSONArray json)
    {
        Gson gson = new Gson();
        java.lang.reflect.Type listType = new TypeToken<ArrayList<Sport>>() {
        }.getType();
        return gson.fromJson(json.toString(), listType);
    }

    public static Sport getSportFromJson(JSONObject json){
        Gson gson = new Gson();
        return gson.fromJson(json.toString(), Sport.class);
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getNom() {
        return Nom;
    }

    public void setNom(String nom) {
        Nom = nom;
    }

    public String getType() {
        return Type;
    }

    public void setType(String type) {
        Type = type;
    }
}
