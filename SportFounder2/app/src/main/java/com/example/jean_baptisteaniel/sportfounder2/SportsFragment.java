package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
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

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.MyAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.SportsAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Models.Sport;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link SportsFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link SportsFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class SportsFragment extends android.support.v4.app.Fragment {
    private static final String ARG_SECTION_NUMBER = "section_number";


    private OnFragmentInteractionListener mListener;

    private String mParam;
    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private SportsAdapter mAdapter;
    private List<Sport> listeSports;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment FriendsFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static SportsFragment newInstance(int sectionNumber) {
        SportsFragment fragment = new SportsFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, sectionNumber);
        fragment.setArguments(args);
        return fragment;
    }

    public SportsFragment() {
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
        final View v = inflater.inflate(R.layout.fragment_sports, container, false);
        Button mAddSportButton = (Button) v.findViewById(R.id.add_sport);
        mAddSportButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                launchAddSport();
            }
        });
        final FragmentActivity c = getActivity();
        myRecycler = (RecyclerView) v.findViewById(R.id.recycler_view_sport);
        myRecycler.addOnItemTouchListener(
                new RecyclerItemClickListener(myRecycler.getContext(), new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
                        goSport(view, position);
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
        RequestQueue queue = Volley.newRequestQueue(getActivity());
        Globals g = (Globals) getActivity().getApplication();
        int id = g.getUser_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/GetMesSports/"+id;

        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {
                listeSports = Sport.getListeSportsFromJson(response);
                mAdapter = new SportsAdapter(listeSports);
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

    private void launchAddSport () {
        android.support.v4.app.FragmentTransaction transaction = getFragmentManager().beginTransaction();
        UpdateProfileFragment mFragment = UpdateProfileFragment.newInstance(0);
        transaction.replace(R.id.container, mFragment);
        transaction.addToBackStack("updateProfile");
        transaction.commit();

    }

    private void goSport (View v, int pos) {
        String url = null;
        Globals g = (Globals) getActivity().getApplication();
        try {
            g.setSport_id(listeSports.get(pos).getId());
        } catch (Exception e) {
            e.printStackTrace();
        }

// Add the request to the RequestQueue.

        final FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.replace(R.id.container, SportDetailFragment.newInstance(6), "goSport"); // Jsais pas c quoi ce param(3)...
        ft.addToBackStack("sport detail");
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
