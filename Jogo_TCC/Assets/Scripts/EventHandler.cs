using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.RaiseOnReset();                   // Function call to invoke an Event
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            EventManager.RaiseOnReStart();                // Function call to invoke an Event
        }

    }
}
