package com.example.jean_baptisteaniel.sportfounder2.Models;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Groupe {

    private int Id;
    private String Nom;
    private String Libelle;
    private String Description;

    public Groupe () {

    }

    public Groupe (int id,String nom,String libelle,String description) {
        Id = id;
        Nom = nom;
        Description = description;
        Libelle = libelle;
    }

    public static List<Groupe> getListGroupesFromJson(JSONArray json)
    {
        Gson gson = new Gson();
        java.lang.reflect.Type listType = new TypeToken<ArrayList<Groupe>>() {
        }.getType();
        return gson.fromJson(json.toString(), listType);
    }

    public static Groupe getGroupeFromJson(JSONObject json){
        Gson gson = new Gson();
        return gson.fromJson(json.toString(), Groupe.class);
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

    public String getLibelle() {
        return Libelle;
    }

    public void setLibelle(String libelle) {
        Libelle = libelle;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }
}
