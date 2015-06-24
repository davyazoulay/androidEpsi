package com.example.jean_baptisteaniel.sportfounder2;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Lieu {

    private int id;
    private String nom;
    private String libelle;
    private String description;
    private String cp;
    private double lat;
    private double lon;

    public Lieu () {}

    public Lieu (int i, String n, String l, String d, String c, double la, double lo) {
        this.id = i;
        this.nom = n;
        this.libelle = n;
        this.description = d;
        this.cp = c;
        this.lat = la;
        this.lon = lo;
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

    public String getCp() {
        return cp;
    }

    public void setCp(String cp) {
        this.cp = cp;
    }

    public double getLat() {
        return lat;
    }

    public void setLat(double lat) {
        this.lat = lat;
    }

    public double getLon() {
        return lon;
    }

    public void setLon(double lon) {
        this.lon = lon;
    }
}
