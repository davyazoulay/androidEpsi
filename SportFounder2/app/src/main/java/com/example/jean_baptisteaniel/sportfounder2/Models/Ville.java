package com.example.jean_baptisteaniel.sportfounder2.Models;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Ville {

    private int id;
    private String nom;

    public Ville () {

    }

    public Ville (int i,String n) {
        this.id = i;
        this.nom = n;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

}
