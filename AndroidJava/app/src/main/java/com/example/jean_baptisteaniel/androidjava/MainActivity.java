package com.example.jean_baptisteaniel.androidjava;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.example.jean_baptisteaniel.androidjava.R;


public class MainActivity extends Activity {

    TextView password;
    TextView email;
    Button login;
    DrawerLayout sidebar;
    ListView sidebar_items;
    String[] titles;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_activity);
        password = (TextView) findViewById(R.id.password_input);
        email = (TextView) findViewById(R.id.email_input);
        login = (Button) findViewById(R.id.login);
        sidebar = (DrawerLayout) findViewById(R.id.drawer_layout);
        sidebar_items = (ListView) findViewById(R.id.left_drawer);

        /*sidebar_items.setAdapter(new ArrayAdapter<String>(this,
                R.layout.drawer_list_item, titles));*/
        // Set the list's click listener
        sidebar_items.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

            }
        });
    }
}
