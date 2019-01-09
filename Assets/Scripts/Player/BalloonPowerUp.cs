using UnityEngine;

/* Script made by Daniel */
public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;
    public float timer;

    MovementController mc;
    Light characterLight;
    Rigidbody2D rb;

    string button;
    float lightSize;
    bool inflated;
    bool empty;
    bool started;


	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        mc = GetComponent<MovementController>();
        characterLight = GetComponentInChildren<Light>();
        lightSize = characterLight.range;
        button = "Seperate" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
        started = false;
    }
	
	void Update ()
    {
        float x = Input.GetAxis("Horizontal" + " " + gameObject.name)/8; 
        float y = Input.GetAxis("Vertical"   + " " + gameObject.name)/10;

        timer -= Time.deltaTime;
        if (timer < 0 && on) on = false;

        if (on)
        {
            if (!inflated && transform.localScale.y < 2)
            {
                if (!started) AudioManager.Play("Balloon Up");
                started = true;
                if (mc.facingRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f, 1);
                    if (transform.localScale.y > 2) transform.localScale = new Vector3(2, 2, 2);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.025f, transform.localScale.y + 0.025f, 1);
                    if (transform.localScale.y > 2) transform.localScale = new Vector3(-2, 2, 2);
                }

                if (characterLight.range < lightSize * 4) characterLight.range += 0.2f;
                if (characterLight.range > lightSize * 4) characterLight.range = lightSize * 4;

                if (transform.localScale.x == 2 || transform.localScale.x == -2)
                {
                    GetComponent<JumpController>().state = JumpState.IsJumping;
                    inflated = true;
                    empty = false;
                    started = false;
                }
            }
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(force.x + x, force.y + y), ForceMode2D.Impulse);
        }
        else
        {
            if (!empty && transform.localScale.y > 1)
            {
                if (!started) AudioManager.Play("Balloon Down");
                started = true;
                if (mc.facingRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.025f, transform.localScale.y - 0.025f, 1);
                    if (transform.localScale.y < 1) transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y - 0.025f, 1);
                    if (transform.localScale.y < 1) transform.localScale = new Vector3(-1, 1, 1);
                }

                if (characterLight.range > lightSize) characterLight.range -= 0.2f;
                if (characterLight.range < lightSize) characterLight.range = lightSize;

                if (transform.localScale.x == 1 || transform.localScale.x == -1)
                {
                    empty = true;
                    inflated = false;
                    started = false;
                }
            }
            rb.gravityScale = 1;
        }
	}
}
