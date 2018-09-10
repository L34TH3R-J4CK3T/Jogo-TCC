using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTeste : MonoBehaviour {
    Rigidbody2D RB2;
    Vector2 vel = new Vector2(10f,0f);
    

	// Use this for initialization
	void Start () {
        RB2 = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        RB2.AddForce(vel);

    }
}
