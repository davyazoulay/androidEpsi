package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
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

import org.json.JSONObject;

import java.util.HashMap;


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
    private EditText mdp;
    private EditText firstname;
    private EditText lastname;
    private EditText prenom;
    private EditText verifMdp;
    private EditText oldMdp;

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
        lastname = (EditText) mFragment.findViewById(R.id.update_firstname);
        firstname = (EditText) mFragment.findViewById(R.id.update_lastname);
        email = (EditText) mFragment.findViewById(R.id.update_email);
        mdp = (EditText) mFragment.findViewById(R.id.update_newpassword);
        oldMdp = (EditText) mFragment.findViewById(R.id.update_oldpassword);
        verifMdp = (EditText) mFragment.findViewById(R.id.update_retypepassword);
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
        HashMap<String, String> obj;
        obj = new HashMap<String, String>();
        mActi = this.getActivity();
        RequestQueue queue = Volley.newRequestQueue(this.getActivity());
        Globals g = (Globals) getActivity().getApplication();
        final int id = g.getUser_id();
        Log.d("get", email.getText().toString());
        obj.put("Id", String.valueOf(id));
        obj.put("Login", email.getText().toString());
        obj.put("Mdp", mdp.getText().toString());
        obj.put("Nom", lastname.getText().toString());
        obj.put("Prenom", firstname.getText().toString());
        obj.put("Email", email.getText().toString());
        obj.put("DateNaissance", "1993-04-26T00:00:00");
        obj.put("Pays", "test");
        obj.put("Ville", "test");
        obj.put("CP", "test");
        obj.put("Type", "1");
        JSONObject user = new JSONObject(obj);
        JsonObjectRequest request = new JsonObjectRequest(Request.Method.POST, "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/UpdateUser", user,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Log.d("response", String.valueOf(response));
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

                // Setting Dialog Message
                alertDialog.setMessage("You entered wrong values do you want to retry?");

                // Setting Icon to Dialog
                //alertDialog.setIcon(R.drawable.delete);

                // On pressing Settings button
                alertDialog.setPositiveButton("Retry", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog,int which) {
                        email.setText("");
                        mdp.setText("");
                        lastname.setText("");
                        firstname.setText("");
                        verifMdp.setText("");
                        oldMdp.setText("");
                        dialog.dismiss();
                    }
                });
                alertDialog.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        final FragmentTransaction ft = getFragmentManager().beginTransaction();
                        ft.replace(R.id.container, ProfilesFragment.newInstance(1), "backprofil"); //.newInstance(3), "profil_ami");
                        ft.addToBackStack("backprofilfromupdate");
                        ft.commit();
                    }
                });

                // Showing Alert Message
                alertDialog.show();
                // TODO Auto-generated method stub
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
