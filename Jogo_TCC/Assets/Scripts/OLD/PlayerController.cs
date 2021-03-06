﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpforce;
	private float moveInput;

	private Rigidbody2D rb;

	private bool facingRight = true;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if(facingRight == false && moveInput > 0){
			Flip();
		}else if(facingRight == true && moveInput < 0){
			Flip();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
