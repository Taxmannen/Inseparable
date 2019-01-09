using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class LeverController : MonoBehaviour {

    [Header("Script")]
    public List<Action> leverActions;
    
    public Transform leverHandle;
    public bool leverState;
    bool disabled = false;
    
    public int index;

    public static List<LeverController> levers = new List<LeverController>();
    
    public static void setLeverStates(bool[] states) {
        foreach(LeverController leverController in levers) {
            leverController.setState(states[leverController.index]);

        }
    }

    public void Start(){
        leverState = false;
        levers.Add(this);
    }

    public void OnDestroy(){
        levers.Remove(this);
    }
    
    void Update () {
        bool tempState;
        if (leverHandle.position.x < transform.position.x)
            tempState = true;
        else
            tempState = false;

        if ((tempState ^ leverState) && !disabled)
        {
            AudioManager.Play("Lever");
            GameSettings.gameSettings.levers[index] = tempState;
            foreach (Action la in leverActions)
                la.onStateChange(tempState);
        }

        leverState = tempState;
    }

    public void setState(bool tempState)
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

            GameSettings.gameSettings.levers[index] = tempState;
        }

        leverState = tempState;
    }

    void reEnable()
    {
        disabled = false;
    }
}
