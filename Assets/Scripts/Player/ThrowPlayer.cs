using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayer : MonoBehaviour {
    public float power = 40;
    bool pickedUp;

    Transform player;
    Rigidbody2D rb;
    MovementController movementController;

    float horizontal;
	void Start ()
    {
		
	}
	
	void Update ()
    {
       if (Input.GetAxisRaw("Horizontal" + " " + gameObject.name) != 0) horizontal = Input.GetAxisRaw("Horizontal" + " " + gameObject.name);
       if (pickedUp)
       {
            rb.isKinematic = true;
            player.position = Vector3.MoveTowards(player.position, new Vector3(transform.position.x, transform.position.y + 1f, 0), 0.04f);
            if (Input.GetAxisRaw("Throw Player 1") != 0)
            {
                pickedUp = false;
                rb.isKinematic = false;
                if      (horizontal < 0) rb.AddForce(new Vector2(-power, 35), ForceMode2D.Impulse);
                else if (horizontal > 0) rb.AddForce(new Vector2(power, 35),  ForceMode2D.Impulse);
            }
       }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (movementController == null) movementController = other.GetComponent<MovementController>(); //BUGG!
            if (Input.GetAxisRaw("Pickup" + " " + gameObject.name) != 0 && movementController.grounded)
            {
                if (player == null) player = other.transform;
                if (rb == null) rb = other.GetComponent<Rigidbody2D>();
                pickedUp = true;
            }
        }
    }
}
