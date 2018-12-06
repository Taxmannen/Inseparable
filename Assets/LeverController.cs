using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by Adam */
public class LeverController : MonoBehaviour {

    [Header("Script")]
    public LeverAction leverAction;
    
    public Transform leverHandle;
    public bool leverState;

	void Start () {
        leverState = false;
	}
	
	void Update () {
        bool tempLeverState;
        if (leverHandle.position.x < transform.position.x)
            tempLeverState = true;
        else
            tempLeverState = false;

        if (tempLeverState ^ leverState)
        {
            leverAction.LeverPulled(tempLeverState);
        }

        leverState = tempLeverState;
    }
}
