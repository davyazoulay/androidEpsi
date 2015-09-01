package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.FriendsAdaptater;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.GridUsersAdaptater;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.MyAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Models.Groupe;
import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link GroupFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link GroupFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class GroupFragment extends android.support.v4.app.Fragment {
    private static final String ARG_SECTION_NUMBER = "section_number";

    // TODO: Rename and change types of parameters
    private String mParam;
    private TextView nameTV;
    private TextView descriptionTV;
    private TextView libelleTV;
    private OnFragmentInteractionListener mListener;
    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private GridUsersAdaptater mAdapter;
    private List<Utilisateur> listUsers;


    public static GroupFragment newInstance(int param1) {
        GroupFragment fragment = new GroupFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, param1);
        fragment.setArguments(args);
        return fragment;
    }

    public GroupFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam = getArguments().getString(ARG_SECTION_NUMBER);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View v = inflater.inflate(R.layout.fragment_group, container, false);
        nameTV = (TextView) v.findViewById(R.id.groupe_name);
        descriptionTV = (TextView) v.findViewById(R.id.groupe_description);
        libelleTV = (TextView) v.findViewById(R.id.groupe_libelle);
        Button quit_group_button = (Button) v.findViewById(R.id.button_quit_group);
        quit_group_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                quitGroup();
            }
        });

        final FragmentActivity c = getActivity();
        myRecycler = (RecyclerView) v.findViewById(R.id.recycler_view_grid_group);
        myRecycler.setHasFixedSize(true);
        mLayoutManager = new LinearLayoutManager(c);
        myRecycler.setLayoutManager(new GridLayoutManager(getActivity(),4));

        RequestQueue queue = Volley.newRequestQueue(getActivity());
        Globals g = (Globals) getActivity().getApplication();
        int id = g.getGroupe_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Groupe/GetGroupeById/"+id;
        JsonObjectRequest jsObjRequest = new JsonObjectRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Groupe groupe = Groupe.getGroupeFromJson(response);
                        nameTV.setText(groupe.getNom());
                        descriptionTV.setText(groupe.getDescription());
                        libelleTV.setText(groupe.getLibelle());

                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO Auto-generated method stub

                    }
                });
// Add the request to the RequestQueue.
        queue.add(jsObjRequest);

        RequestQueue queue2 = Volley.newRequestQueue(getActivity());
        String url2 = "http://imout.montpellier.epsi.fr:8088/api/Groupe/GetListUsers/"+id;

        JsonArrayRequest req = new JsonArrayRequest(url2, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {

                listUsers = Utilisateur.getListUsersFromJson(response);
                mAdapter = new GridUsersAdaptater(listUsers);
                myRecycler.setAdapter(mAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Error: ", error.getMessage());
            }
        });

        // add the request object to the queue to be executed
        queue.add(req);
        return v;
    }

    private void quitGroup()
    {
        final Globals g = (Globals) getActivity().getApplication();
        int user_id = g.getUser_id();
        int group_id = g.getGroupe_id();

        RequestQueue queue = Volley.newRequestQueue(this.getActivity());
        String url = "http://imout.montpellier.epsi.fr:8088/api/Groupe/QuitGroupe/"+user_id+"/"+group_id;
        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Error: ", error.getMessage());
            }
        });

        // add the request object to the queue to be executed
        queue.add(req);

        try{
            Thread.sleep(100);
            // Then do something meaningful...
        }catch(InterruptedException e){
            e.printStackTrace();
        }
        goListGroupes();

    }

    private void goListGroupes () {
        final FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.replace(R.id.container, GroupListFragment.newInstance(3), "golisteGroupes"); //.newInstance(3), "profil_ami");
        ft.addToBackStack("listeGroupes");
        ft.commit();
    }


    // TODO: Rename method, update argument and hook method into UI event
    public void onButtonPressed(Uri uri) {
        if (mListener != null) {
            mListener.onFragmentInteraction(uri);
        }
    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            mListener = (OnFragmentInteractionListener) activity;
            ((MainActivity) activity).onSectionAttached(
                    getArguments().getInt(ARG_SECTION_NUMBER));
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }


    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnFragmentInteractionListener {
        // TODO: Update argument type and name
        public void onFragmentInteraction(Uri uri);
    }
}
