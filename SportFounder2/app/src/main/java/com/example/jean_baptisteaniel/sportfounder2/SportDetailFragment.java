package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Models.Sport;

import org.json.JSONObject;


public class SportDetailFragment extends android.support.v4.app.Fragment {
    private static final String ARG_SECTION_NUMBER = "section_number";

    // TODO: Rename and change types of parameters
    private String mParam;
    private TextView nameTV;
    private TextView typeTV;
    private OnFragmentInteractionListener mListener;



    public static SportDetailFragment newInstance(int param1) {
        SportDetailFragment fragment = new SportDetailFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, param1);
        fragment.setArguments(args);
        return fragment;
    }

    public SportDetailFragment() {
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
        final View v = inflater.inflate(R.layout.fragment_sport_detail, container, false);
        nameTV = (TextView) v.findViewById(R.id.sport_nom);
        typeTV = (TextView) v.findViewById(R.id.sport_type);

        RequestQueue queue = Volley.newRequestQueue(getActivity());
        Globals g = (Globals) getActivity().getApplication();
        int id = g.getSport_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Sport/GetSportById/"+id;
        JsonObjectRequest jsObjRequest = new JsonObjectRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Sport sport = Sport.getSportFromJson(response);
                        nameTV.setText(sport.getNom());
                        typeTV.setText(sport.getType());

                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO Auto-generated method stub

                    }
                });
// Add the request to the RequestQueue.
        queue.add(jsObjRequest);
        return v;
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
