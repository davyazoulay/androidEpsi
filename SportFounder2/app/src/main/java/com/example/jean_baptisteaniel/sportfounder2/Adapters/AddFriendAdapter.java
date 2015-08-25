package com.example.jean_baptisteaniel.sportfounder2.Adapters;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;
import com.example.jean_baptisteaniel.sportfounder2.R;

import java.util.List;

/**
 * Created by Sébastien on 25/08/2015.
 */
public class AddFriendAdapter extends RecyclerView.Adapter<AddFriendAdapter.ViewHolder>{

    /**
     * Created by davy.azoulay on 28/07/2015.
     */
        private List<Utilisateur> listAmis;

        public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
            public TextView mTextView1, mTextView2;
            public ImageView personPhoto;
            public ViewHolder(View v) {
                super(v);
                mTextView1 = (TextView) v.findViewById(R.id.cell_text_1);
                mTextView2 = (TextView) v.findViewById(R.id.cell_text_2);
                personPhoto = (ImageView) v.findViewById(R.id.person_photo);
            }

            public void setText(String prenom, String ville) {
                this.mTextView1.setText(prenom);
                this.mTextView2.setText(ville);
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

        public AddFriendAdapter(List<Utilisateur> listUsers) {
            listAmis = listUsers;
        }

        @Override
        public AddFriendAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
            View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.cellule, parent, false);
            ViewHolder vh = new ViewHolder(v);
            return vh;
        }
        @Override
        public void onBindViewHolder(ViewHolder holder, int position) {
            holder.setText(listAmis.get(position).getPrenom(), listAmis.get(position).getNom());
        }
        @Override
        public int getItemCount() {
            return listAmis.size();
        }

}
