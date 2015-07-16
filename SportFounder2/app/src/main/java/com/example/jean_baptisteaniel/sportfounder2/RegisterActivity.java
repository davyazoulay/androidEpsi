package com.example.jean_baptisteaniel.sportfounder2;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.provider.Settings;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;


public class RegisterActivity extends ActionBarActivity {

    private EditText email;
    private EditText mdp;
    private EditText firstname;
    private EditText lastname;
    private EditText prenom;
    private EditText verifMdp;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        Button mSubmit = (Button) findViewById(R.id.submit_register);
        Button mCancel = (Button) findViewById(R.id.cancel_register);
        mSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                register();
            }
        });
        mCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cancel();
            }
        });
        lastname = (EditText) findViewById(R.id.firstname);
        firstname = (EditText) findViewById(R.id.lastname);
        email = (EditText) findViewById(R.id.email_register);
        mdp = (EditText) findViewById(R.id.password_register);
        verifMdp = (EditText) findViewById(R.id.verify_password);
    }

    private void register() {
        HashMap<String, String> obj;
        obj = new HashMap<String, String>();
        RequestQueue queue = Volley.newRequestQueue(RegisterActivity.this);
        Log.d("get",  email.getText().toString());
        obj.put("Login", email.getText().toString());
        obj.put("Mdp", mdp.getText().toString());
        obj.put("Nom", lastname.getText().toString());
        obj.put("Prenom", firstname.getText().toString());
        obj.put("Email", email.getText().toString());
        obj.put("DateNaissance", "1993-04-26T00:00:00");
        obj.put("Pays", "test");
        obj.put("Ville", "test");
        obj.put("CP", "test");
        obj.put("Type", "1");
        JSONObject user = new JSONObject(obj);
        JsonObjectRequest request = new JsonObjectRequest(Request.Method.POST, "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/CreateUser", user,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Log.d("response", String.valueOf(response));
                        Intent i = new Intent(RegisterActivity.this, MainActivity.class);
                        startActivity(i);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Error", error.toString());
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(RegisterActivity.this);
                alertDialog.setTitle("Error while registering");

                // Setting Dialog Message
                alertDialog.setMessage("You entered wrong values do you want to retry?");

                // Setting Icon to Dialog
                //alertDialog.setIcon(R.drawable.delete);

                // On pressing Settings button
                alertDialog.setPositiveButton("Retry", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog,int which) {
                        email.setText("");
                        mdp.setText("");
                        lastname.setText("");
                        firstname.setText("");
                        verifMdp.setText("");
                        dialog.dismiss();
                    }
                });
                alertDialog.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Intent i = new Intent(RegisterActivity.this, LoginActivity.class);
                        startActivity(i);
                        dialog.cancel();
                    }
                });

                // Showing Alert Message
                alertDialog.show();
                // TODO Auto-generated method stub
            }

        });
        queue.add(request);

    }

    private void cancel() {
        Intent i = new Intent(RegisterActivity.this, LoginActivity.class);
        startActivity(i);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_register, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
