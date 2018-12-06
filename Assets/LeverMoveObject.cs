using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by Adam */
public class LeverMoveObject : LeverAction
{
    public Vector3 leverOnPosition;
    public Vector3 leverOffPosition;
    public bool leverState;
    public float lerpSpeed;
    public bool drawGizmos;

    bool lerping;

    private void Start()
    {
        lerping = false;
    }

    public override void LeverPulled(bool leverState)
    {
        lerping = true;
        this.leverState = leverState;
    }

    public void Update()
    {
        if(lerping)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            switch(leverState)
            {
                case true:
                    pos = leverOnPosition;
                    break;

                case false:
                    pos = leverOffPosition;
                    break;
            }

            transform.position = Vector3.Lerp(transform.position, pos, lerpSpeed);

            if ((transform.position - pos).sqrMagnitude < 0.5)
                lerping = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(leverOnPosition + new Vector3(3, -3, 0),  new Vector2(6, 6));
            Gizmos.DrawCube(leverOffPosition + new Vector3(3, -3, 0), new Vector2(6, 6));
        }
    }
}
