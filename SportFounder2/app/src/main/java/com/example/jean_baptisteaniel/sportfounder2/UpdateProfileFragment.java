package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.app.AlertDialog;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentTransaction;
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
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONObject;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link UpdateProfileFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link UpdateProfileFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class UpdateProfileFragment extends android.support.v4.app.Fragment  {


    private static int save;
    private OnFragmentInteractionListener mListener;

    private EditText email;
    private EditText prenom;
    private EditText nom;
    private EditText ville;
    private EditText pays;

    private Activity mActi;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment UpdateProfileFragment.
     */
    public static UpdateProfileFragment newInstance (int n) {
        UpdateProfileFragment fragment = new UpdateProfileFragment();
        Bundle args = new Bundle();
        save = n;
        fragment.setArguments(args);
        return fragment;
    }


    public UpdateProfileFragment() {
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
        View mFragment = inflater.inflate(R.layout.fragment_update_profile, container, false);
        Button mSubmitButton = (Button) mFragment.findViewById(R.id.update_submit);
        Button mCancelButton = (Button) mFragment.findViewById(R.id.update_cancel);
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

        Globals g = (Globals) getActivity().getApplication();
        Utilisateur currentUser = g.getUser();

        prenom = (EditText) mFragment.findViewById(R.id.update_firstname);
        nom = (EditText) mFragment.findViewById(R.id.update_lastname);
        email = (EditText) mFragment.findViewById(R.id.update_email);
        ville = (EditText) mFragment.findViewById(R.id.update_ville);
        pays = (EditText) mFragment.findViewById(R.id.update_pays);

        prenom.setText(currentUser.getPrenom());
        nom.setText(currentUser.getNom());
        email.setText(currentUser.getEmail());
        ville.setText(currentUser.getVille());
        pays.setText(currentUser.getPays());
        return mFragment;
    }

    private void cancelUpdate () {
        android.support.v4.app.FragmentTransaction transaction = getFragmentManager().beginTransaction();
        ProfilesFragment mFragment = ProfilesFragment.newInstance(save);
        transaction.replace(R.id.container, mFragment);
        transaction.addToBackStack("cancelUpdate");
        transaction.commit();
    }
    private void submitUpdate () {
        RequestQueue queue = Volley.newRequestQueue(this.getActivity());
        final Globals g = (Globals) getActivity().getApplication();
        Utilisateur userUpdate = g.getUser();
        userUpdate.setPrenom(prenom.getText().toString());
        userUpdate.setNom(nom.getText().toString());
        userUpdate.setEmail(email.getText().toString());
        userUpdate.setVille(ville.getText().toString());
        userUpdate.setPays(pays.getText().toString());

        final Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss").create();
        JSONObject user = new JSONObject();
        try
        {
            String usrString = gson.toJson(g.getUser());
            user = new JSONObject(usrString);
        }
        catch(Exception e){Log.d("Exception", e.toString());}

        JsonObjectRequest request = new JsonObjectRequest(Request.Method.POST, "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/UpdateUser", user,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Utilisateur user = gson.fromJson(response.toString(), Utilisateur.class);
                        g.setUser(user);
                        final FragmentTransaction ft = getFragmentManager().beginTransaction();
                        ft.replace(R.id.container, ProfilesFragment.newInstance(1), "backprofil"); //.newInstance(3), "profil_ami");
                        ft.addToBackStack("backprofilfromupdate");
                        ft.commit();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("Error", error.toString());
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(mActi);
                alertDialog.setTitle("Error while registering");
            }

        });
        queue.add(request);

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
