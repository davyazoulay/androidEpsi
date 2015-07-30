package com.example.jean_baptisteaniel.sportfounder2.Adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.jean_baptisteaniel.sportfounder2.Models.Conversation;
import com.example.jean_baptisteaniel.sportfounder2.Models.MessageSimple;
import com.example.jean_baptisteaniel.sportfounder2.R;

import java.util.List;

/**
 * Created by davy.azoulay on 29/07/2015.
 */
public class ConversationDetailAdapter extends RecyclerView.Adapter<ConversationDetailAdapter.ViewHolder>{
    private List<MessageSimple> listeMessages;

    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        public TextView mTextView;
        public ViewHolder(View v) {
            super(v);
            mTextView = (TextView) v.findViewById(R.id.cell_message_conversation);
        }

        public void setText(String message) {
            this.mTextView.setText(message);
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

    public ConversationDetailAdapter(List<MessageSimple> listMsg) {
        listeMessages = listMsg;
    }

    @Override
    public int getItemViewType(int position) {
        if(listeMessages.get(position).isCestMoi()){
            return 1;
        }
        else{
            return 2;
        }
    }

    @Override
    public ConversationDetailAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule_conversation_detail, parent, false);
        switch (viewType) {
            case 1: v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule_conversation_detail, parent, false);break;
            case 2: v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule_conversation_detail_2, parent, false);break;
        }
        ViewHolder vh = new ViewHolder(v);
        return vh;
    }
    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        holder.setText(listeMessages.get(position).getMessage());
    }
    @Override
    public int getItemCount() {
        return listeMessages.size();
    }
}
