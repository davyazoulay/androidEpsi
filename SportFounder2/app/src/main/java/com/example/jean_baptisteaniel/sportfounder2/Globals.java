package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Application;

import org.json.JSONObject;

/**
 * Created by jean-baptisteaniel on 25/06/15.
 */
public class Globals extends Application {
    private int user_id = 0;
    private int other_id;

    public int getUser_id() {
        return user_id;
    }

    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }

    public int getCurrentObject() {
        return other_id;
    }

    public void setCurrentObject(int id) {
        this.other_id = id;
    }
}
