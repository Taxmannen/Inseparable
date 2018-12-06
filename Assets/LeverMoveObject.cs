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
    [Range(0.000001f, 0.1f)]
    public float percentageOfDistancePerTick;

    public LayerMask playerLayer;
    Transform player1;
    Transform player2;

    public float GizmoX, GizmoY, GizmoWidth, GizmoHeight;

    private void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        moving = false;
    }

    public override void LeverPulled(bool leverState)
    {
        moving = true;
        this.leverState = leverState;
    }

    public bool checkPlayer(Transform player)
    {
        return 
            Physics2D.OverlapBox(new Vector2(player.position.x + 0.6f, player.position.y + -0.45f), new Vector2(1.14f, 1f), 0, playerLayer) ||
            Physics2D.OverlapBox(new Vector2(player.position.x + 5.4f, player.position.y + -0.45f), new Vector2(1.08f, 1f), 0, playerLayer) ||
            Physics2D.OverlapBox(new Vector2(player.position.x + 3.05f, player.position.y + 0.55f), new Vector2(0.55f, 1f), 0, playerLayer);
    } 

    public void Update()
    {
        if(moving)
        {
            Vector3 pos;
            if (leverState) pos = leverOnPosition;
            else            pos = leverOffPosition;

            Vector3 movement;
            if (constantOrLerping == 1)
            { 
                movement = transform.position - Vector3.Lerp(transform.position, pos, lerpSpeed);
            }
            else
            {
                Vector3 differenceVector;
                if (leverState) differenceVector = leverOnPosition - leverOffPosition;
                else            differenceVector = leverOffPosition - leverOnPosition;

                movement = differenceVector * percentageOfDistancePerTick;
            }

            transform.position += movement;
            if (checkPlayer(player1))
                player1.position += movement;
            if (checkPlayer(player2))
                player1.position += movement;


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

            Gizmos.DrawCube(new Vector2(transform.position.x + 0.6f, transform.position.y + -0.45f), new Vector2(1.14f, 1f));
            Gizmos.DrawCube(new Vector2(transform.position.x + 5.4f, transform.position.y + -0.45f), new Vector2(1.08f, 1f));
            Gizmos.DrawCube(new Vector2(transform.position.x + 3.05f, transform.position.y + 0.55f), new Vector2(0.55f, 1f));
        }

    }
}
