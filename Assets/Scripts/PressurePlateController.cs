using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class PressurePlateController : MonoBehaviour
{
    [Header("Script")]
    public List<Action> leverActions;
    public List<LayerMask> affectedLayers;

    public float startScaleY = 0.2f;
    public float endScaleY = 0.05f;
    public bool pressurePlateState;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
    }

    public bool CheckActivation()
    {
        foreach(LayerMask layer in affectedLayers)
        {
            bool state = Physics2D.OverlapBox(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f), new Vector3(1.6f, 0.5f), 0, layer);
            if (state)
                return state;
        }
        return false;
    }

    private void Update()
    {
        bool tempState = CheckActivation();

        if (tempState ^ pressurePlateState)
        {
            foreach (Action la in leverActions)
                la.onStateChange(tempState);
            
            if(tempState)
                transform.localScale = new Vector3(transform.localScale.x, endScaleY, transform.localScale.z);
            else
                transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
        }

        pressurePlateState = tempState;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f), new Vector3(1.6f, 0.5f));
    }
}
