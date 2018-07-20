using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboList : MonoBehaviour {


    //lista dos combos e movimentos necessarios para ativalos
    // necessario aprimorar, so funciona em uma direçao
    private KeyCombo falconPunch = new KeyCombo(new string[] { "down", "right", "right" });
    private KeyCombo falconKick = new KeyCombo(new string[] { "right", "right", "up" });
    private KeyCombo batata = new KeyCombo(new string[] { "up", "down", "FireA" });
    void Update()
    {
        if (falconPunch.Check())
        {
            
            Debug.Log("ATTACK1");
            
        }
        if (falconKick.Check())
        {
            
            Debug.Log("ATTACK2");
        }
        if (batata.Check())
        {
            
            Debug.Log("ATTACK3");
        }

    }
}