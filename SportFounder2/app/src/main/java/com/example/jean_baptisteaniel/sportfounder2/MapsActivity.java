package com.example.jean_baptisteaniel.sportfounder2;

import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.util.Log;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Models.Lieu;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.List;
import java.util.Locale;

import static java.lang.Double.parseDouble;
import static java.lang.Integer.parseInt;

public class MapsActivity extends FragmentActivity {

    private GoogleMap mMap; // Might be null if Google Play services APK is not available.
    private GPS mGps;
    private double mLat;
    private double mLong;
    private Lieu mLieu;
    private JSONArray mLieuList = new JSONArray();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);
        mGps = new GPS(this.getBaseContext());
        if (mGps.canGetLocation()) {
            mLieu = new Lieu(mGps.getLatitude(), mGps.getLongitude());
        } else {
            mGps.showSettingsAlert();
        }
        RequestQueue queue = Volley.newRequestQueue(MapsActivity.this);
        String url = "http://imout.montpellier.epsi.fr:8088/api/Lieu/getalllieux";
        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {
                mLieuList = response;
                if (mLieuList.length() != 0) {
                    for (int i = 0; i < mLieuList.length(); i++) {
                        JSONObject row = null;
                        try {
                            row = mLieuList.getJSONObject(i);
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        try {
                            float [] dist = new float[1];
                            Location.distanceBetween(mLieu.getLat(), mLieu.getLon(), parseDouble(String.valueOf(row.get("Latitude"))), parseDouble(String.valueOf(row.get("Longitude"))), dist);
                            Log.d("distance", String.valueOf(dist[0]));
                            if (parseDouble(String.valueOf(dist[0]))/1000 <= 30) {
                                addMarker(parseDouble(String.valueOf(row.get("Latitude"))), parseDouble(String.valueOf(row.get("Longitude"))), "other");
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                }
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Error: ", error.getMessage());
            }
        });

// add the request object to the queue to be executed

        queue.add(req);
        List<Address> list = null;
        try {
            Geocoder geoCoder = new Geocoder(MapsActivity.this, Locale.getDefault());
            ;
            list = geoCoder.getFromLocation(mGps.getLatitude(), mGps.getLongitude(), 1);
        } catch (IOException e) {
            e.printStackTrace();
        }
        Address address = null;
        if (list != null & list.size() > 0) {
            address = list.get(0);
        }
        mLieu.setCp(address.getPostalCode());
        mLieu.setNom(address.getLocality());
        mLieu.setDescription(address.getLocale().toString());
        setUpMapIfNeeded();
    }

    @Override
    protected void onResume() {
        super.onResume();
        setUpMapIfNeeded();
    }

    /**
     * Sets up the map if it is possible to do so (i.e., the Google Play services APK is correctly
     * installed) and the map has not already been instantiated.. This will ensure that we only ever
     * call {@link #setUpMap()} once when {@link #mMap} is not null.
     * <p/>
     * If it isn't installed {@link SupportMapFragment} (and
     * {@link com.google.android.gms.maps.MapView MapView}) will show a prompt for the user to
     * install/update the Google Play services APK on their device.
     * <p/>
     * A user can return to this FragmentActivity after following the prompt and correctly
     * installing/updating/enabling the Google Play services. Since the FragmentActivity may not
     * have been completely destroyed during this process (it is likely that it would only be
     * stopped or paused), {@link #onCreate(Bundle)} may not be called again so we should call this
     * method in {@link #onResume()} to guarantee that it will be called.
     */
    private void setUpMapIfNeeded() {
        // Do a null check to confirm that we have not already instantiated the map.
        if (mMap == null) {
            // Try to obtain the map from the SupportMapFragment.
            mMap = ((SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map))
                    .getMap();
            // Check if we were successful in obtaining the map.
            if (mMap != null) {
                setUpMap();

            }
        }
    }

    private void addMarker (double la, double ln, String s) {
        mMap.addMarker(new MarkerOptions()
                .position(new LatLng(la, ln))
                .title(s));
    }

    /**
     * This is where we can add markers or lines, add listeners or move the camera. In this case, we
     * just add a marker near Africa.
     * <p/>
     * This should only be called once and when we are sure that {@link #mMap} is not null.
     */
    private void setUpMap() {
        this.addMarker(mLieu.getLat(), mLieu.getLon(), mLieu.getDescription());
        // Zoom in, animating the camera.
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(new LatLng(mLieu.getLat(), mLieu.getLon()), 1));
        mMap.animateCamera(CameraUpdateFactory.zoomIn());
// Zoom out to zoom level 10, animating with a duration of 2 seconds.
        mMap.animateCamera(CameraUpdateFactory.zoomTo(15), 2000, null);

    }
}
