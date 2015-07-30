package com.example.jean_baptisteaniel.sportfounder2.Adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.jean_baptisteaniel.sportfounder2.Models.MessageIntitule;
import com.example.jean_baptisteaniel.sportfounder2.R;

import java.util.List;

/**
 * Created by davy.azoulay on 27/07/2015.
 */
public class ConversationAdapter extends RecyclerView.Adapter<ConversationAdapter.ViewHolder>{
    private List<MessageIntitule> listeMessages;


    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView mTextView1, mTextView2;
        public ImageView personPhoto;
        public ViewHolder(View v) {
            super(v);
            mTextView1 = (TextView) v.findViewById(R.id.cell_text_1_conversation);
            mTextView2 = (TextView) v.findViewById(R.id.cell_text_2_conversation);
            personPhoto = (ImageView) v.findViewById(R.id.person_photo_conversation);
        }

        public void setText(String prenom, String message) {
            this.mTextView1.setText(prenom);
            mTextView2.setText(message);
            this.personPhoto.setImageResource(R.mipmap.ic_launcher);

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

    public ConversationAdapter(List<MessageIntitule> listMsg) {
        listeMessages = listMsg;
    }

    @Override
    public ConversationAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule_conversation, parent, false);
        ViewHolder vh = new ViewHolder(v);
        return vh;
    }
    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        String message ="";
        if (listeMessages.get(position).isCestMoi())
            message = "moi: ";
        holder.setText(listeMessages.get(position).getNomAmi(), message + listeMessages.get(position).getMessage());
    }
    @Override
    public int getItemCount() {
        return listeMessages.size();
    }
}
