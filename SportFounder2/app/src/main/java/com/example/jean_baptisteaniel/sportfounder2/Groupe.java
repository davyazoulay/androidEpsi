package com.example.jean_baptisteaniel.sportfounder2;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Groupe {

    private int id;
    private String nom;
    private String libelle;
    private String description;

    public Groupe () {

    }

    public Groupe (int i,String n,String lib,String des) {

        this.id = i;
        this.nom = n;
        this.libelle = lib;
        this.description = des;

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

    public String getLibelle() {
        return libelle;
    }

    public void setLibelle(String libelle) {
        this.libelle = libelle;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

}
