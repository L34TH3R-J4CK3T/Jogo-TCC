﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMagic : MonoBehaviour {

    //Area de que decide o elemento (manter nos pes do personagem)
    public Transform groundMagicCheck;
    public Transform MagicWall;


    //Tipos de magias
    private bool fire = false;
    private bool ice = false;
    // so é ativa quando todos outros sao false private bool wind = false;
    private bool earth = false;


    // Use this for initialization
    void Start () {
        Debug.Log(String.Format("Start"));
    }
	
	// Update is called once per frame
	void Update () {

        // qual elemento o ground magic check esta pegando
        fire = Physics2D.Linecast(transform.position, groundMagicCheck.position, 1 << LayerMask.NameToLayer("Fire"));
        ice = Physics2D.Linecast(transform.position, groundMagicCheck.position, 1 << LayerMask.NameToLayer("Ice"));
        earth = Physics2D.Linecast(transform.position, groundMagicCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // Ativacao magias
        if (Input.GetButtonDown("Magic"))
        {
            if (fire == true)
            {
                Debug.Log(String.Format("Fire"));
            }
            else if (ice == true)
            {
                Debug.Log(String.Format("Ice"));
            }
            else if (earth)
            {
                Debug.Log(String.Format("Earth"));
            }
            else
            {
                Debug.Log(String.Format("Wind"));
                Instantiate(MagicWall, new Vector3 (0, 0, 0), Quaternion.identity);

            }
        }

    }
}
