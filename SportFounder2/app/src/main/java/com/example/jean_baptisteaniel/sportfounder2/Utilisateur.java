package com.example.jean_baptisteaniel.sportfounder2;

import org.json.JSONObject;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Utilisateur {

    private int id;
    private String login;
    private String mdp;
    private String nom;
    private String prenom;
    private String mail;
    private Date naissance;
    private String pays;
    private String ville;
    private String cp;

    public Utilisateur () {

    }
    public Utilisateur(int i, String l, String m, String n, String p, String ma, Date na, String pa, String v, String cp) {
        this.id = i;
        this.login = l;
        this.mdp = m;
        this.nom = n;
        this.prenom = p;
        this.mail = ma;
        this.naissance = na;
        this.pays = pa;
        this.ville = v;
        this.cp = cp;
    }


    public int getId () {
        return this.id;
    }

    public void setId (int i) {
        this.id = i;
    }

    public String getLogin () {
        return this.login;
    }

    public void setLogin (String l) {
        this.login = l;
    }

    public String getMdp () {
        return this.mdp;
    }

    public void setMdp (String m) {
        this.mdp = m;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }

    public String getMail() {
        return mail;
    }

    public void setMail(String mail) {
        this.mail = mail;
    }

    public Date getNaissance() {
        return naissance;
    }

    public void setNaissance(Date naissance) {
        this.naissance = naissance;
    }

    public String getPays() {
        return pays;
    }

    public void setPays(String pays) {
        this.pays = pays;
    }

    public String getVille() {
        return ville;
    }

    public void setVille(String ville) {
        this.ville = ville;
    }

    public String getCp() {
        return cp;
    }

    public void setCp(String cp) {
        this.cp = cp;
    }
}
