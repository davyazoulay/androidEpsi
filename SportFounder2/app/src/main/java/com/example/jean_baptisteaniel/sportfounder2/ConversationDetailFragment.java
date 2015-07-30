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
import android.widget.EditText;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.example.jean_baptisteaniel.sportfounder2.Adapters.ConversationDetailAdapter;
import com.example.jean_baptisteaniel.sportfounder2.Models.Conversation;
import com.example.jean_baptisteaniel.sportfounder2.Models.MessageIntitule;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link ConversationDetailFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link ConversationDetailFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ConversationDetailFragment extends android.support.v4.app.Fragment {

    private static final String ARG_SECTION_NUMBER = "section_number";


    private OnFragmentInteractionListener mListener;

    private String mParam;
    private RecyclerView myRecycler;
    private RecyclerView.LayoutManager mLayoutManager;
    private ConversationDetailAdapter mAdapter;
    private EditText editText_msg;
    private Button button_send;
    private Conversation conversation;
    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment FriendsFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ConversationDetailFragment newInstance(int sectionNumber) {
        ConversationDetailFragment fragment = new ConversationDetailFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_SECTION_NUMBER, sectionNumber);
        fragment.setArguments(args);
        return fragment;
    }

    public ConversationDetailFragment() {
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
        final View v = inflater.inflate(R.layout.fragment_conversation_detail, container, false);
        final FragmentActivity c = getActivity();
        editText_msg = (EditText) v.findViewById(R.id.chat_input_message);
        button_send = (Button) v.findViewById(R.id.button_send_msg_chat);
        button_send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendMessage();
            }
        });
        myRecycler = (RecyclerView) v.findViewById(R.id.recycler_view_conversation_detail);
        myRecycler.addOnItemTouchListener(
                new RecyclerItemClickListener(myRecycler.getContext(), new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
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
        int idFriend = g.getFriend_id();
        int myId = g.getUser_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Conversation/GetConversationByIds/"+myId+"/"+idFriend;

        JsonObjectRequest jsObjRequest = new JsonObjectRequest
                (Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        conversation = Conversation.getConversationFromJson(response);
                        mAdapter = new ConversationDetailAdapter(conversation.getMessages());
                        myRecycler.setAdapter(mAdapter);
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO Auto-generated method stub

                    }
                });

        // add the request object to the queue to be executed
        queue.add(jsObjRequest);

        return v;
    }

    public void sendMessage()
    {
        RequestQueue queue = Volley.newRequestQueue(getActivity());
        Globals g = (Globals) getActivity().getApplication();
        int idFriend = g.getFriend_id();
        int myId = g.getUser_id();
        String url = "http://imout.montpellier.epsi.fr:8088/api/Conversation/SendMessage/"+myId+"/"+idFriend;
        JSONObject messageJson = new JSONObject();
        try{
            Gson gson = new Gson();
            messageJson = new JSONObject(gson.toJson(editText_msg.getText()));
        }
        catch (Exception e){
            Log.d("Exception", e.toString());
        }
        JsonObjectRequest jsObjRequest = new JsonObjectRequest
                (Request.Method.GET, url, messageJson, new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // TODO Auto-generated method stub
                        Log.d("volleyerror", error.toString());
                    }
                });

        // add the request object to the queue to be executed
        queue.add(jsObjRequest);
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
