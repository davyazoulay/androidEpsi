package com.example.jean_baptisteaniel.sportfounder2.Adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.jean_baptisteaniel.sportfounder2.Models.Sport;
import com.example.jean_baptisteaniel.sportfounder2.R;

import java.util.List;

/**
 * Created by davy.azoulay on 30/07/2015.
 */
public class SportsAdapter extends RecyclerView.Adapter<SportsAdapter.ViewHolder>{
    private List<Sport> listeSports;

    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView mTextView1, mTextView2;
        public ViewHolder(View v) {
            super(v);
            mTextView1 = (TextView) v.findViewById(R.id.cell_text_1);
            mTextView2 = (TextView) v.findViewById(R.id.cell_text_2);
        }

        public void setText(String nom, String type) {
            this.mTextView1.setText(nom);
            this.mTextView2.setText(type);
        }

        public interface OnItemClickListener {
            public void onItemClick(View view , int position);
        }


        @Override
        public void onClick(View v) {
            onItemClick(v, getPosition()); //OnItemClickListener mItemClickListener;
        }


    }

    public static void onItemClick(View view, int position){
        listener();
    }

    public static void listener() {

    }

    public SportsAdapter(List<Sport> listeS) {
        listeSports = listeS;
    }

    @Override
    public SportsAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule, parent, false);
        ViewHolder vh = new ViewHolder(v);
        return vh;
    }
    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        holder.setText(listeSports.get(position).getNom(), listeSports.get(position).getType());
    }
    @Override
    public int getItemCount() {
        return listeSports.size();
    }
}
