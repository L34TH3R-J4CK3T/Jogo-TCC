using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class EnemyFunctionsOLD : MonoBehaviour {

	Controller2D controller;
	Player player;
	Transform posicao;
    Animator anim;
    public Transform groundMagicCheck;
    public LayerMask collisionMask;
    private bool playerD = false;



	public int a0 = 0;
 	public int a1 = 1;
	float beta = 6;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
		posicao = GetComponent<Transform> ();
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		float alfa = posicao.position.x;

        playerD = Physics2D.Linecast(transform.position, groundMagicCheck.position, collisionMask);

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Moving(a0);
        //    Attacking();
        //}

        if (playerD)
        {
            Moving(a0);
            Attacking();
        }


        if (Input.GetKeyDown(KeyCode.F)){
			Debug.Log("Moving");
			Moving(a1);
			beta = alfa+10;

		}
		if (alfa >= beta)
		{
			Debug.Log("Stoping");
			Moving(a0);
			beta++ ;
		}
		
	}

    
      
    void Moving (int direcao)
    {
        Vector2 directionalInput = new Vector2 (direcao, 0);
	    player.SetDirectionalInput (directionalInput);
    }


    void Attacking()
    {
        anim.SetTrigger("Attack"); 
    }
}
