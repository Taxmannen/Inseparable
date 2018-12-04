using UnityEngine;

public class ThrowPlayer : MonoBehaviour {
    public Vector2 power = new Vector2(25, 30);

    MovementController movementController;
    Transform player;
    Rigidbody2D rb;
    float direction;
    bool pickUp;
    bool buttonUp;

    void Start ()
    {
        string otherPlayer;
		if      (gameObject.name == "Player 1") otherPlayer = "Player 2";
		else                                    otherPlayer = "Player 1";
        player = GameObject.Find(otherPlayer).transform;
        movementController = player.GetComponent<MovementController>();
        rb = player.GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetAxisRaw("Horizontal" + " " + gameObject.name) != 0) direction = Input.GetAxisRaw("Horizontal" + " " + gameObject.name);
        if (Input.GetAxisRaw("Throw" + " " + gameObject.name) == 0) buttonUp = true;

        if (pickUp)
        {
            rb.isKinematic = true;
            player.position = Vector3.MoveTowards(player.position, new Vector2(transform.position.x, transform.position.y + 1f), 0.1f);

            if (Input.GetAxisRaw("Throw" + " " + gameObject.name) != 0 && buttonUp)
            {
                pickUp = false;
                rb.isKinematic = false;
                if      (direction < 0) rb.AddForce(new Vector2(-power.x, power.y), ForceMode2D.Impulse);
                else if (direction > 0) rb.AddForce(new Vector2(power.x, power.y),  ForceMode2D.Impulse);
                buttonUp = false;
            }
        }
        else if (!pickUp && rb.isKinematic) rb.isKinematic = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetAxisRaw("Pickup" + " " + gameObject.name) != 0) pickUp = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") pickUp = false;
    }
}
