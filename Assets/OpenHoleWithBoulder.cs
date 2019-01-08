using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OpenHoleWithBoulder : MonoBehaviour
{
    public Sprite StateOn;
    public Sprite StateOff;

    public List<LayerMask> affectedLayers;
    public List<Action> leverActions;

    [Header("Box")]
    public Vector2 offset;
    public Vector2 size;
    public bool pressurePlateState;
    
    public GameObject boulderPrefab;
    public Vector3 position;

    SpriteRenderer sr;

    public void Start()
    {
        pressurePlateState = false;
        sr = GetComponent<SpriteRenderer>();
    }

    public bool CheckActivation()
    {
        foreach (LayerMask layer in affectedLayers)
        {
            bool state = Physics2D.OverlapBox(transform.position + new Vector3(offset.x, offset.y), size, 0, layer);
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
            if (tempState)
            {
                foreach (Action la in leverActions)
                    la.onStateChange(tempState);

            }
            else
                sr.sprite = StateOff;
        }

        pressurePlateState = tempState;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + new Vector3(offset.x, offset.y), size);
        Gizmos.DrawCube(position, new Vector3(1f, 1f));
    }
}
