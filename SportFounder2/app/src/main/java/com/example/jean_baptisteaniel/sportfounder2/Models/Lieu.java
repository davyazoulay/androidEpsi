package com.example.jean_baptisteaniel.sportfounder2.Models;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Lieu {

    private int Id;
    private String Nom;
    private String Libelle;
    private String Description;
    private String Cp;
    private double Lat;
    private double Lon;

    public Lieu () {}

    public Lieu (int i, String n, String l, String d, String c, double la, double lo) {
        this.Id = i;
        this.Nom = n;
        this.Libelle = n;
        this.Description = d;
        this.Cp = c;
        this.Lat = la;
        this.Lon = lo;
    }

    public Lieu (double la, double lo) {
        this.Lat = la;
        this.Lon = lo;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        this.Id = id;
    }

    public String getNom() {
        return Nom;
    }

    public void setNom(String nom) {
        this.Nom = nom;
    }

    public String getLibelle() {
        return Libelle;
    }

    public void setLibelle(String libelle) {
        this.Libelle = libelle;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        this.Description = description;
    }

    public String getCp() {
        return Cp;
    }

    public void setCp(String cp) {
        this.Cp = cp;
    }

    public double getLat() {
        return Lat;
    }

    public void setLat(double lat) {
        this.Lat = lat;
    }

    public double getLon() {
        return Lon;
    }

    public void setLon(double lon) {
        this.Lon = lon;
    }
}
