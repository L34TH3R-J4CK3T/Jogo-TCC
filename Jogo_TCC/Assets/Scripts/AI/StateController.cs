using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour 
{

    public State currentState;
    public State remainInState;
    public Transform stateColorPos;
    public float colorRadius = 1;
    private bool aiActive = true;
    //-------------------------------------
    Rigidbody2D RB2;
    Vector2 vel = new Vector2(10f, 0f);

    private void Awake()
    {
        RB2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);

    }

    void OnDrawGizmos()
    {
        if(currentState != null &&  stateColorPos != null)
        {
            Gizmos.color = currentState.stateColor;
            Gizmos.DrawSphere(stateColorPos.position, colorRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainInState)
        {
            currentState = nextState;
        }
    }


    //teste nao faz parte da IA daqui pra baixo
    public void Move()
    {
        RB2.AddForce(vel);
    }
}
