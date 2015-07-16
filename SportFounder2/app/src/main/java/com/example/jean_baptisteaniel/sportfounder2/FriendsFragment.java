package com.example.jean_baptisteaniel.sportfounder2;

import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.widget.CardView;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListAdapter;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import static java.lang.Integer.parseInt;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link FriendsFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link FriendsFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class FriendsFragment extends android.support.v4.app.Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_SECTION_NUMBER = "section_number";


    private OnFragmentInteractionListener mListener;

    private String mParam;
    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private MyAdapter mAdapter;
    private int id;
    private JSONArray friends;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment FriendsFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static FriendsFragment newInstance(int sectionNumber) {
        FriendsFragment fragment = new FriendsFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, sectionNumber);
        fragment.setArguments(args);
        return fragment;
    }

    public FriendsFragment() {
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
        final View v = inflater.inflate(R.layout.fragment_friends, container, false);
        final FragmentActivity c = getActivity();
        myRecycler = (RecyclerView) v.findViewById(R.id.my_recycler_view);
        myRecycler.addOnItemTouchListener(
                new RecyclerItemClickListener(myRecycler.getContext(), new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
                        goProfil(view, position);
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
        id = g.getUser_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Utilisateur/GetListAmis/"+id;
        JsonArrayRequest req = new JsonArrayRequest(url, new Response.Listener<JSONArray> () {
            @Override
            public void onResponse(JSONArray response) {
                friends = response;
                String[] myDataset = new String[response.length()];
                for (int i = 0; i < response.length(); i++) {
                    try {
                        myDataset[i] = response.get(i).toString();
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }
                mAdapter = new MyAdapter(myDataset);
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



        //mAdapter.SetOnItemClickListener(new OnItemClickListener(); // solution tuto erreur build

        /*Button profilButton = (Button) this.getActivity().findViewById(R.id.goprofil);
        profilButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                FragmentManager fragmentManager = getFragmentManager();
                fragmentManager.beginTransaction().replace(R.id.container, ProfilesFragment.newInstance(1)).commit();
            }
        });*/ // solution cr�er en reprenant l'exemple de bouton pas d'erreur mais pointer null quand on run le OnclickListener
        return v;
    }

    private void goProfil (View v, int pos) {
        String url = null;
        Globals g = (Globals) getActivity().getApplication();
        Log.e("friends", friends.toString());
        JSONObject friend = null;
        try {
            friend = (JSONObject) friends.get(pos);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        try {
            Log.e("friend", String.valueOf(friend.get("Id")));
            g.setCurrentObject((Integer) friend.get("Id"));
        } catch (JSONException e) {
            e.printStackTrace();
        }

// Add the request to the RequestQueue.

        final FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.replace(R.id.container, friendProfileFragment.newInstance(3), "goprofil"); //.newInstance(3), "profil_ami");
        ft.addToBackStack("profilefromfriend");
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
    public class thread1 extends Thread {
        public thread1(int nombre, String[] Dataset) {
            while (nombre < 10) {
                Dataset[nombre] = "Ligne" + nombre;
                nombre++;
            }
        }
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
