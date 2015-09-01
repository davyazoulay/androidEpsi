package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.app.AlertDialog;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.AddFriendAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.GroupeListAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Models.Groupe;
import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link UpdateProfileFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link UpdateProfileFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class AddGroupFragment extends android.support.v4.app.Fragment  {


    private static int save;
    private OnFragmentInteractionListener mListener;

    private EditText search;
    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private GroupeListAdapter mAdapter;
    private List<Groupe> listeGroupes;

    private Activity mActi;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment UpdateProfileFragment.
     */
    public static AddGroupFragment newInstance (int n) {
        AddGroupFragment fragment = new AddGroupFragment();
        Bundle args = new Bundle();
        save = n;
        fragment.setArguments(args);
        return fragment;
    }


    public AddGroupFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {

        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View mFragment = inflater.inflate(R.layout.fragment_add_group, container, false);
        Button mSubmitButton = (Button) mFragment.findViewById(R.id.update_submit_group);
        Button mCancelButton = (Button) mFragment.findViewById(R.id.update_cancel_group);
        mSubmitButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                submitUpdate();
            }
        });
        mCancelButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cancelUpdate();
            }
        });
        search = (EditText) mFragment.findViewById(R.id.search_group);

        final FragmentActivity c = getActivity();
        myRecycler = (RecyclerView) mFragment.findViewById(R.id.recycler_view_addGroupe);
        myRecycler.addOnItemTouchListener(
                new RecyclerItemClickListener(myRecycler.getContext(), new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
                        final Globals g = (Globals) getActivity().getApplication();
                        int userId = g.getUser().getId();
                        RequestQueue queue = Volley.newRequestQueue(getActivity());
                        String url = "http://imout.montpellier.epsi.fr:8088/api/Groupe/JoinGroupe/" + userId + "/" + listeGroupes.get(position).getId();

                        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray>() {
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
                        try {
                            Thread.sleep(100);
                            // Then do something meaningful...
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                        goListGroupes();

                    }
                }) {
                    @Override
                    public void onRequestDisallowInterceptTouchEvent(boolean disallowIntercept) {

                    }
                }
        );
        myRecycler.setHasFixedSize(true);
        mLayoutManager = new LinearLayoutManager(c);
        myRecycler.setLayoutManager(mLayoutManager);

        return mFragment;
    }

    private void cancelUpdate () {
        android.support.v4.app.FragmentManager manager = getFragmentManager();
        android.support.v4.app.FragmentTransaction transaction = manager.beginTransaction();
        manager.popBackStackImmediate("AddGroup", manager.POP_BACK_STACK_INCLUSIVE);
        GroupListFragment mFragment = GroupListFragment.newInstance(save);
        transaction.replace(R.id.container, mFragment);
        transaction.commit();
    }
    private void submitUpdate () {
        RequestQueue queue = Volley.newRequestQueue(getActivity());
        String groupe = search.getText().toString();
        final Globals g = (Globals) getActivity().getApplication();
        int userId = g.getUser().getId();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Groupe/SearchGroupe/"+userId+"/"+groupe;

        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {

                listeGroupes = Groupe.getListGroupesFromJson(response);
                mAdapter = new GroupeListAdapter(listeGroupes);
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
    }

    private void goListGroupes () {
        final FragmentManager manager = getFragmentManager();
        final FragmentTransaction ft = manager.beginTransaction();
        manager.popBackStackImmediate("AddGroup", manager.POP_BACK_STACK_INCLUSIVE);
        ft.replace(R.id.container, GroupListFragment.newInstance(3)); //.newInstance(3), "profil_ami");
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
