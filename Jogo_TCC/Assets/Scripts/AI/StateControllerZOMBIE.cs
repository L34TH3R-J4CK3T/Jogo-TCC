//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Player))]
//public class StateControllerZOMBIE : StateController {

//    public override void Attack1()
//    {
//        Moving(a1);

//    }

//    public override void Attack2()
//    {
//        Flip();
//    }



//    //-------------------------------------------------------------------------------------------------

//    Controller2D controller;
//    Player player;
//    Transform posicao;
//    Animator anim;
//    public Transform groundMagicCheck;
//    public LayerMask collisionMask;
//    private bool playerD = false;



//    public int a0 = 0;
//    public int a1 = 1;
//    bool movingRight = true;
    

//    // Use this for initialization
//    void Start()
//    {
//        player = GetComponent<Player>();
//        posicao = GetComponent<Transform>();
//        anim = GetComponent<Animator>();
//        anim.SetBool("Moving", false);

//    }

//    // Update is called once per frame
//    //void Update()
//    //{
//    //    RaycastHit2D ground = Physics2D.Raycast(groundEnd.position, Vector2.down, distance);

//    //    float alfa = posicao.position.x;

//    //    playerD = Physics2D.Linecast(transform.position, groundMagicCheck.position, collisionMask);




//    //    if (ground.collider == false)
//    //    {
//    //        Flip();
//    //    }

//    //    if (playerD)
//    //    {
//    //        Moving(a0);
//    //        Attacking();
//    //    }


//    //    if (Input.GetKeyDown(KeyCode.F))
//    //    {
//    //        Debug.Log("Moving");
//    //        Moving(a1);


//    //    }


//    //}



//    public void Moving(int direcao)
//    {
//        Vector2 directionalInput = new Vector2(direcao, 0);
//        player.SetDirectionalInput(directionalInput);
//        if (direcao == 1)
//        {
//            anim.SetBool("Moving", true);
//        }
//        else
//        {
//            anim.SetBool("Moving", false);
//        }
//    }


//    void Attacking()
//    {
//        anim.SetTrigger("Attack");
//    }

//    void Flip()
//    {
//        if (movingRight == true)
//        {
//            transform.eulerAngles = new Vector3(0, -180, 0);
//            movingRight = false;
//        }
//        else
//        {
//            transform.eulerAngles = new Vector3(0, 0, 0);
//            movingRight = true;
//        }
//    }
//}
