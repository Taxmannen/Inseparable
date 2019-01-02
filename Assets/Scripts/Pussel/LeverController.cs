using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class LeverController : MonoBehaviour {

    [Header("Script")]
    public List<Action> leverActions;
    
    public Transform leverHandle;
    public bool leverState;
    public bool testForce;
    bool disabled = false;

	void Start () {
        leverState = false;
	}
	
	void Update () {
        bool tempState;
        if (leverHandle.position.x < transform.position.x)
            tempState = true;
        else
            tempState = false;

        if ((tempState ^ leverState) && !disabled)
        {
            foreach (Action la in leverActions)
                la.onStateChange(tempState);
        }

        leverState = tempState;

        if (testForce)
        {
            setState(true);
            testForce = false;
        }

    }

    void setState(bool tempState)
    {
        if (tempState ^ leverState)
        {
            disabled = true;

            Transform handle = transform.Find("Handle");
            if(tempState)
                handle.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1000f, 1000f));
            else
                handle.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(1000f, 1000f));

            Invoke("reEnable", 0.5f);
            
            foreach (Action la in leverActions)
                la.onForceStateChange(tempState);
            
        }

        leverState = tempState;
    }

    void reEnable()
    {
        disabled = false;
    }
}
