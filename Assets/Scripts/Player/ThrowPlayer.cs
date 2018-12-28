using UnityEngine;

/* Script made by Daniel */
public class ThrowPlayer : MovementScript {
    public Vector2 power = new Vector2(20, 25);
    public bool pickup;

    MovementController movementController;
    Transform player;
    Rigidbody2D rb;

    bool buttonUpThrow;
    string throwButtonStr;
    string pickupButtonStr;
    float pickupTime;

    public GameObject leftArm;
    public GameObject rightArm;
    public float i=0;

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
    }

    void Update ()
    {
        if (Input.GetAxisRaw(throwButtonStr) == 0)
        {
            buttonUpThrow = true;
        }

        if (pickup)
        {
            if (Input.GetAxisRaw(throwButtonStr) != 0 && buttonUpThrow)
            {
                float x = Input.GetAxisRaw("Horizontal " + gameObject.name);
                float y = Input.GetAxisRaw("Vertical "  + gameObject.name);
                if(new Vector2(x, y).sqrMagnitude < 0.01f)
                {
                    rb.gravityScale = 1;
                    pickup = false;
                    buttonUpThrow = false;
                    return;
                }

                Vector2 directionVector = new Vector2(x, y);
                
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(power.x * directionVector.x, power.y * Mathf.Clamp(directionVector.y, 0f, 1f)), ForceMode2D.Impulse);
                pickup = false;
                buttonUpThrow = false;
                AudioManager.Play("Throw");
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
        if (pickup)
        {
            player.position = Vector3.MoveTowards(player.position, new Vector2(transform.position.x, transform.position.y + 1f), 0.1f);

            float max = 3;
            if (i < max)
            {
                rightArm.transform.localPosition = new Vector3(
                0.55f * (i + 1) / max,
                rightArm.transform.localPosition.y,
                rightArm.transform.localPosition.z);
                SpriteRenderer rightSr = rightArm.GetComponent<SpriteRenderer>();
                rightSr.color = new Color(rightSr.color.r, rightSr.color.g, rightSr.color.b, Mathf.Clamp(1f * (i + 1) / max, 0f, 1f));
                i++;
            }
            else
            {
                Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);
                Vector3 eulerAngle = rightArm.transform.localEulerAngles;
                Vector3 localOtherPlayer = (otherPlayer.transform.position - transform.position);
                float radiansAngle = Mathf.Asin(localOtherPlayer.y / localOtherPlayer.magnitude);
                //float radiansAngle = Mathf.Deg2Rad * Vector3.Angle(transform.forward, (otherPlayer.transform.position - transform.position));
                float a = 90f + radiansAngle * Mathf.Rad2Deg;

                Vector3 position = rightArm.transform.localPosition;
                position.y = Mathf.Sin(radiansAngle) * 0.5f;
                position.x = Mathf.Cos(radiansAngle) * 0.5f;
                rightArm.transform.localPosition = position;

                eulerAngle.z = a;
                rightArm.transform.localEulerAngles = eulerAngle;
            }
        }
        else
        {
            i = 0;
            rightArm.transform.localPosition = Vector3.zero;
            rightArm.transform.eulerAngles = Vector3.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetAxisRaw(pickupButtonStr) != 0 && Time.time - pickupTime > 0.3f)
            {
                if (!pickup && movementController.grounded)
                {
                    pickup = true;
                    rb.gravityScale = 0;
                    AudioManager.Play("Pickup");
                }
                else if (pickup)
                {
                    pickup = false;
                    rb.gravityScale = 1;
                }
                pickupTime = Time.time;
            }
        }
    }
}
