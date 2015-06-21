package com.example.sbastien.vue_projet;

import android.app.Activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;


public class MainActivity extends Activity {

    private RecyclerView myRecycler;
    private RecyclerView.Adapter mAdapter;
    private RecyclerView.LayoutManager mLayoutManager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        myRecycler = (RecyclerView) findViewById(R.id.my_recycler_view);
        myRecycler.setHasFixedSize(true);
        mLayoutManager = new LinearLayoutManager(this);
        myRecycler.setLayoutManager(mLayoutManager);
        String[] myDataset = new String[10];
        Button next = (Button) findViewById(R.id.buttonSuite);
        next.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                goFragment(view);
            }
        });
        int nombre = 0;
        thread1 a = new thread1(nombre,myDataset);
        a.start();
        mAdapter = new MyAdapter(myDataset);
        myRecycler.setAdapter(mAdapter);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
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

    public class thread1 extends Thread {
        public thread1(int nombre, String[] Dataset) {
            while (nombre < 10) {
                Dataset[nombre] = "Ligne" + nombre;
                nombre++;
            }
        }
    }

    public void goFragment(View view) {
        Intent intent = new Intent(MainActivity.this, Reponse.class);
        startActivity(intent);
    }
}
