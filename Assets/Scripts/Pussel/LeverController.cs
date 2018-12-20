using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by Adam */
public class LeverController : MonoBehaviour {

    [Header("Script")]
    public List<Action> leverActions;
    
    public Transform leverHandle;
    public bool leverState;

	void Start () {
        leverState = false;
	}
	
	void Update () {
        bool tempState;
        if (leverHandle.position.x < transform.position.x)
            tempState = true;
        else
            tempState = false;

        if (tempState ^ leverState)
        {
            foreach (Action la in leverActions)
                la.onStateChange(tempState);
        }

        leverState = tempState;
    }
}
