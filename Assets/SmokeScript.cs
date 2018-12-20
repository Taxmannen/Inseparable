using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public LayerMask ground;

    Rigidbody2D rb;
    float velX, velY;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = transform.parent.gameObject.GetComponent<MovementController>().grounded;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetPlayer.playerReady(transform.parent.gameObject.name))
            
            if(GetPlayer.getPlayerGroundedByName(transform.parent.gameObject.name, ground))
            {
                Debug.Log(grounded);
                Instantiate(transform.gameObject, new Vector2(transform.parent.position.x, transform.parent.position.y), transform.parent.transform.localRotation);
            }
    }
}
