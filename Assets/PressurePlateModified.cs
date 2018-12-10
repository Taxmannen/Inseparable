using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script made by Daniel 
   Modified by Adam */
public class PressurePlateModified : MonoBehaviour
{
    [Header("Script")]
    public List<Action> pressurePlateActions;
    
    public string[] affectedTags;

    public float startScaleY = 0.1f;
    public float endScaleY = 0.05f;

    public bool state;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        bool tempState = false;
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag)
            {
                tempState = true;
                transform.localScale = new Vector3(transform.localScale.x, endScaleY, transform.localScale.z);
            }
        }

        if (tempState ^ state)
        {
            state = tempState;
            foreach (Action la in pressurePlateActions)
                la.onStateChange(tempState);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag)
            {
                bool tempState = false;
                if (tempState ^ state)
                {
                    state = tempState;
                    foreach (Action la in pressurePlateActions)
                        la.onStateChange(tempState);
                }
                state = tempState;
                transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
            }
        }
    }
}
