package com.example.sbastien.vue_projet;

import android.widget.ImageView;

/**
 * Created by Sébastien on 09/06/2015.
 */
public class Utilisateur {
    String nom;
    String prenom;
    String age;
    ImageView photo;

    public Utilisateur(String n, String p, String a, ImageView ph){
        nom = n;
        prenom = p;
        age = a;
        photo = ph;
    }
}
