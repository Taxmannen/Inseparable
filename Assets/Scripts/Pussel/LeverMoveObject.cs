using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class LeverMoveObject : Action
{
    [Header("Positions")]
    public Vector3 leverOnPosition;
    public Vector3 leverOffPosition;
    public bool leverState;
    public bool drawGizmos;
    public GameObject gameObjectToMove;

    [Header("Speed")]
    [Tooltip("0 for constant, 1 for lerping.")]
    [Range(0, 1)]
    public int constantOrLerping;
    
    [Header("Lerp Settings")]
    public float lerpSpeed;
    bool moving;

    [Header("Constant Settings")]
    [Range(0.000001f, 0.1f)]
    public float percentageOfDistancePerTick;

    public LayerMask playerLayer;
    Transform player1;
    Transform player2;

    [Header("Gizmo Settings")]
    public bool printGizmoCoordinates;
    public float GizmoX, GizmoY, GizmoWidth, GizmoHeight;

    [Header("Cutscene Settings")]
    public bool cutscene;
    public Vector2 cutsceneOffset;
    public bool freezePlayers;
    public List<ScriptController> playerScriptControllers;
    
    private void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        moving = false;
    }

    public override void onStateChange(bool state)
    {
        AudioManager.Play("MovingIsland");
        if (cutscene)
        {
            
            CameraManager.instance.ChangeFocusTo(transform, cutsceneOffset);

            if (freezePlayers)
                foreach (ScriptController sc in playerScriptControllers)
                    sc.freezePlayer();
        }
        moving = true;
        this.leverState = state;
    }

    public bool checkPlayer(Transform player)
    {
        Vector3 bottomLimit = new Vector3(transform.position.x + 0.12f, transform.position.y - 0.965f);
        Vector3 topLimit = new Vector3(transform.position.x + 6.04f, transform.position.y + 1.825f);
        //Bounds b1 = new Bounds();
        //b1.Encapsulate(new Vector3(transform.position.x + 0.12f, transform.position.y - 0.965f)); 
        //b1.Encapsulate(new Vector3(transform.position.x + 6.04f, transform.position.y + 1.825f));
        //return b1.Contains(player.position);
        return (player.position.x > bottomLimit.x && player.position.x < topLimit.x) && (player.position.y > bottomLimit.y && player.position.y < topLimit.y);
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
                movement = Vector3.Lerp(transform.position, pos, lerpSpeed) * Time.timeScale - transform.position;
            }
            else
            {
                Vector3 differenceVector;
                if (leverState) differenceVector = leverOnPosition - leverOffPosition;
                else            differenceVector = leverOffPosition - leverOnPosition;

                movement = differenceVector * percentageOfDistancePerTick;
            }

            movement *= Time.timeScale;
            if (gameObjectToMove != null)
                gameObjectToMove.transform.position += movement;
            else
                transform.position += movement;
            if (checkPlayer(player1) && checkPlayer(player2))
            {
                player1.position += movement;
                player2.position += movement;
            }

            if ((transform.position - pos).sqrMagnitude < 1)
            {
                moving = false;

                CameraManager.instance.ResetFocus();

                if (freezePlayers)
                    foreach (ScriptController sc in playerScriptControllers)
                        sc.unfreezePlayer();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(leverOnPosition + new Vector3(3, -3, 0),  new Vector2(6, 6));
            Gizmos.DrawCube(leverOffPosition + new Vector3(3, -3, 0), new Vector2(6, 6));
            //Gizmos.DrawCube(new Vector2(transform.position.x + GizmoX, transform.position.y + GizmoY), new Vector2(GizmoWidth, GizmoHeight));
        }

        if (printGizmoCoordinates)
        {
            Vector2 topleft = new Vector2(GizmoX - GizmoWidth / 2, GizmoY - GizmoHeight / 2);
            Vector2 bottomright = new Vector2(GizmoX + GizmoWidth / 2, GizmoY + GizmoHeight / 2);
            Debug.Log("new Vector3(transform.position.x + " + topleft.x + ", transform.position.y + " + topleft.y + ");");
            Debug.Log("new Vector3(transform.position.x + " + bottomright.x + ", transform.position.y + " + bottomright.y + ");");
            printGizmoCoordinates = false;
        }

    }
}
