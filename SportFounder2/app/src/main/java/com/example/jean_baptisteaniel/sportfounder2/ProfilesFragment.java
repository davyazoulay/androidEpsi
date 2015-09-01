package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.support.v4.app.Fragment;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.example.jean_baptisteaniel.sportfounder2.Models.Utilisateur;

import static java.lang.Integer.parseInt;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link ProfilesFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link ProfilesFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ProfilesFragment extends android.support.v4.app.Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_SECTION_NUMBER = "section_number";

    // TODO: Rename and change types of parameters
    private String mParam;
    private TextView nomTV;
    private TextView loginTV;
    private TextView emailTV;
    private TextView villeTV;
    private Utilisateur user;



    private OnFragmentInteractionListener mListener;

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *


     * @return A new instance of fragment ProfilesFragment.
     */
    public static ProfilesFragment newInstance(int number) {
        ProfilesFragment fragment = new ProfilesFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, number);
        fragment.setArguments(args);
        return fragment;
    }

    public ProfilesFragment() {
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
        View mFragment = inflater.inflate(R.layout.fragment_profile, container, false);
        Button mUpdateButton = (Button) mFragment.findViewById(R.id.update_profile);
        mUpdateButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                launchUpdate();
            }
        });

        loginTV = (TextView) mFragment.findViewById(R.id.profile_login);
        nomTV = (TextView) mFragment.findViewById(R.id.profile_nom);
        emailTV = (TextView) mFragment.findViewById(R.id.profile_email);
        villeTV = (TextView) mFragment.findViewById(R.id.profile_ville);

        Globals g = (Globals) getActivity().getApplication();

        user = g.getUser();
        loginTV.setText("Pseudo: "+user.getLogin());
        nomTV.setText(user.getPrenom()+" "+user.getNom());
        emailTV.setText("Mail: "+user.getEmail());
        villeTV.setText("Ville: "+user.getVille());
// Add the request to the RequestQueue.
        return mFragment;
    }

    private void launchUpdate () {
        android.support.v4.app.FragmentManager manager = getFragmentManager();
        /*manager.popBackStack(null, manager.POP_BACK_STACK_INCLUSIVE);
        manager.popBackStackImmediate();*/
        android.support.v4.app.FragmentTransaction transaction = manager.beginTransaction();
        UpdateProfileFragment mFragment = UpdateProfileFragment.newInstance(0);
        transaction.replace(R.id.container, mFragment);
        transaction.addToBackStack("updateProfile");
        transaction.commit();

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
