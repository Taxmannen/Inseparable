using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by Adam */
public class LeverMoveObject : LeverAction
{
    [Header("Positions")]
    public Vector3 leverOnPosition;
    public Vector3 leverOffPosition;
    public bool leverState;
    public bool drawGizmos;

    [Header("Speed")]
    [Tooltip("0 for constant, 1 for lerping.")]
    [Range(0, 1)]
    public int constantOrLerping;
    
    [Header("Lerper settings")]
    public float lerpSpeed;
    bool moving;

    [Header("Constant settings")]
    [Range(0.000001f, 1f)]
    public float percentageOfDistancePerTick;
    
    private void Start()
    {
        moving = false;
    }

    public override void LeverPulled(bool leverState)
    {
        moving = true;
        this.leverState = leverState;
    }

    public void Update()
    {
        if(moving)
        {

            Vector3 pos = new Vector3(0, 0, 0);
            if (leverState) pos = leverOnPosition;
            else            pos = leverOffPosition;

            if (constantOrLerping == 1)
            { 
                transform.position = Vector3.Lerp(transform.position, pos, lerpSpeed);
            }
            else
            {
                Vector3 differenceVector;
                if (leverState) differenceVector = leverOnPosition - leverOffPosition;
                else            differenceVector = leverOffPosition - leverOnPosition;

                transform.position += differenceVector * percentageOfDistancePerTick;
            }

            if ((transform.position - pos).sqrMagnitude < 0.5)
                moving = false;
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
