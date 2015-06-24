package com.example.jean_baptisteaniel.sportfounder2;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Sports {

    private int id;
    private String nom;
    private String type;

    public Sports () {}

    public Sports (int i,String n, String t) {
        this.id = i;
        this.nom = n;
        this.type = t;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
}
