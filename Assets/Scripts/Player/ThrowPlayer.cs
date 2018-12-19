using UnityEngine;

/* Script made by Daniel */
public class ThrowPlayer : MovementScript {
    public Vector2 power = new Vector2(20, 25);
    public AudioClip pickupSound;
    public AudioClip throwSound;

    AudioSource audioSource;

    MovementController movementController;
    Transform player;
    Rigidbody2D rb;
    float direction;
    bool pickUp;
    bool buttonUpThrow;
    string throwButtonStr;
    string pickupButtonStr;
    float pickupTime;

    void Start ()
    {
        throwButtonStr = "Throw"   + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
        pickupButtonStr = "Pickup" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];

        string otherPlayer;
		if      (gameObject.name == "Player 1") otherPlayer = "Player 2";
		else                                    otherPlayer = "Player 1";

        player = GameObject.Find(otherPlayer).transform;
        movementController = GetComponent<MovementController>();
        rb = player.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (Input.GetAxisRaw("Horizontal" + " " + gameObject.name) != 0) direction = Input.GetAxisRaw("Horizontal" + " " + gameObject.name);
        if (Input.GetAxisRaw(throwButtonStr)  == 0) buttonUpThrow  = true;

        if (pickUp)
        {
            if (Input.GetAxisRaw(throwButtonStr) != 0 && buttonUpThrow)
            {
                float x = Input.GetAxisRaw("Horizontal " + gameObject.name);
                float y = Input.GetAxisRaw("Vertical " + gameObject.name);
                if(new Vector2(x, y).sqrMagnitude < 0.01f)
                {
                    rb.gravityScale = 1;
                    pickUp = false;
                    buttonUpThrow = false;
                    return;
                }

                Vector2 directionVector = new Vector2(x, y).normalized;
                
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(power.x * directionVector.x, power.y * Mathf.Clamp(directionVector.y, 0f, 1f)), ForceMode2D.Impulse);
                pickUp = false;
                buttonUpThrow = false;
                audioSource.clip = throwSound;
                audioSource.pitch = 0.9f;
                audioSource.Play();
            }
            if      (!movementController.grounded && rb.gravityScale == 0) rb.gravityScale = 1;
            else if (movementController.grounded  && rb.gravityScale == 1) rb.gravityScale = 0;
        }
        else
        {
            if (rb.gravityScale == 0) rb.gravityScale = 1;
        }
    }

    private void FixedUpdate()
    {
        if (pickUp) player.position = Vector3.MoveTowards(player.position, new Vector2(transform.position.x, transform.position.y + 1f), 0.1f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetAxisRaw(pickupButtonStr) != 0 && Time.time - pickupTime > 0.3f)
            {
                if (!pickUp && movementController.grounded)
                {
                    pickUp = true;
                    rb.gravityScale = 0;
                    audioSource.clip = pickupSound;
                    audioSource.pitch = 1.2f;
                    audioSource.Play();
                }
                else if (pickUp)
                {
                    pickUp = false;
                    rb.gravityScale = 1;
                }
                pickupTime = Time.time;
            }
        }
    }
}
