package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.app.AlertDialog;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentActivity;
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
import com.example.jean_baptisteaniel.sportfounder2.Adapters.FriendsAdaptater;
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
public class AddFriendFragment extends android.support.v4.app.Fragment  {


    private static int save;
    private OnFragmentInteractionListener mListener;

    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private AddFriendAdapter mAdapter;
    private EditText amis;

    private List<Utilisateur> listUsers;

    private Activity mActi;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment UpdateProfileFragment.
     */
    public static AddFriendFragment newInstance (int n) {
        AddFriendFragment fragment = new AddFriendFragment();
        Bundle args = new Bundle();
        save = n;
        fragment.setArguments(args);
        return fragment;
    }


    public AddFriendFragment() {
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
        View mFragment = inflater.inflate(R.layout.fragment_add_friend, container, false);
        Button mSubmitButton = (Button) mFragment.findViewById(R.id.update_submit_friend);
        Button mCancelButton = (Button) mFragment.findViewById(R.id.update_cancel_friend);
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

        final FragmentActivity c = getActivity();
        myRecycler = (RecyclerView) mFragment.findViewById(R.id.recycler_view_addfriend);
        myRecycler.addOnItemTouchListener(
                new RecyclerItemClickListener(myRecycler.getContext(), new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
                        final Globals g = (Globals) getActivity().getApplication();
                        int userId = g.getUser().getId();
                        RequestQueue queue = Volley.newRequestQueue(getActivity());
                        String url = "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/AddFriend/"+ userId + "/" + listUsers.get(position).getId();

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
                        goListFriend();

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

        amis = (EditText) mFragment.findViewById(R.id.profile_login_friend);

        return mFragment;
    }

    private void cancelUpdate () {
        android.support.v4.app.FragmentManager manager = getFragmentManager();
        android.support.v4.app.FragmentTransaction transaction = manager.beginTransaction();
        manager.popBackStackImmediate("AddFriend", manager.POP_BACK_STACK_INCLUSIVE);
        FriendsFragment mFragment = FriendsFragment.newInstance(save);
        transaction.replace(R.id.container, mFragment);
        //AddFriend
        transaction.commit();
    }
    private void submitUpdate () {
        RequestQueue queue = Volley.newRequestQueue(getActivity());
        String friend = amis.getText().toString();
        final Globals g = (Globals) getActivity().getApplication();
        int userId = g.getUser().getId();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/SearchUser/"+userId+"/"+friend;

        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {

                listUsers = Utilisateur.getListUsersFromJson(response);
                mAdapter = new AddFriendAdapter(listUsers);
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

    private void goListFriend () {
        android.support.v4.app.FragmentManager manager = getFragmentManager();
        manager.popBackStackImmediate("AddFriend", manager.POP_BACK_STACK_INCLUSIVE);
        final FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.replace(R.id.container, FriendsFragment.newInstance(3)); //.newInstance(3), "profil_ami");
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
