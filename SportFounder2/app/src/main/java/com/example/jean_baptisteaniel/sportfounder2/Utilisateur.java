package com.example.jean_baptisteaniel.sportfounder2;

import android.util.Log;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONObject;

import java.util.Date;

/**
 * Created by jean-baptisteaniel on 23/06/15.
 */
public class Utilisateur {

    private int Id;
    private String Login;
    private String Mdp;
    private String Nom;
    private String Prenom;
    private String Email;
    private Date DateNaissance;
    private String Pays;
    private String Ville;
    private String CP;
    private int Type;

    public Utilisateur () {

    }
    public Utilisateur (String l, String m, String n, String p, String ma) {
        this.Login = l;
        this.Mdp = m;
        this.Nom = n;
        this.Prenom = p;
        this.Email = ma;
        this.DateNaissance = new Date();
        this.Pays = "";
        this.Ville = "";
        this.CP = "";

    }
    public Utilisateur (int i, String l, String m, String n, String p, String ma) {
        this.Id = i;
        this.Login = l;
        this.Mdp = m;
        this.Nom = n;
        this.Prenom = p;
        this.Email = ma;
        this.DateNaissance = new Date();
        this.Pays = "";
        this.Ville = "";
        this.CP = "";
    }

    public Utilisateur(String login, String mdp){
        Login = login;
        Mdp = mdp;
    }

    public Utilisateur(int id, String login, String mdp, String nom, String prenom, String email, Date dateNaissance, String pays, String ville, String cp, int type) {
        this.Id = id;
        this.Login = login;
        this.Mdp = mdp;
        this.Nom = nom;
        this.Prenom = prenom;
        this.Email = email;
        this.DateNaissance = dateNaissance;
        this.Pays = pays;
        this.Ville = ville;
        this.CP = cp;
        this.Type = type;
    }

    public static Utilisateur getUserFromJson(JSONObject json)
    {
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss").create();
        return gson.fromJson(json.toString(), Utilisateur.class);
    }

    public static JSONObject getJsonObjectFromUser(Utilisateur user){
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss").create();
        JSONObject json = new JSONObject();
        try
        {
            String usrString = gson.toJson(user);
            json = new JSONObject(usrString);
        }
        catch(Exception e){
            Log.d("Exception", e.toString());}
        return json;
    }


    public int getId () {
        return this.Id;
    }

    public void setId (int i) {
        this.Id = i;
    }

    public String getLogin () {
        return this.Login;
    }

    public void setLogin (String l) {
        this.Login = l;
    }

    public String getMdp () {
        return this.Mdp;
    }

    public void setMdp (String m) {
        this.Mdp = m;
    }

    public String getNom() {
        return Nom;
    }

    public void setNom(String nom) {
        this.Nom = nom;
    }

    public String getPrenom() {
        return Prenom;
    }

    public void setPrenom(String Prenom) {
        this.Prenom = Prenom;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String Email) {
        this.Email = Email;
    }

    public Date getDateNaissance() {
        return DateNaissance;
    }

    public void setDateNaissance(String DateNaissance) {
        this.DateNaissance = null;
    }

    public String getPays() {
        return Pays;
    }

    public void setPays(String Pays) {
        this.Pays = Pays;
    }

    public String getVille() {
        return Ville;
    }

    public void setVille(String Ville) {
        this.Ville = Ville;
    }

    public String getCP() {
        return CP;
    }

    public void setCP(String CP) {
        this.CP = CP;
    }

    public int getType() {
        return Type;
    }

    public void setType(int type) {
        Type = type;
    }
}
