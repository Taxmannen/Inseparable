using UnityEngine;

/* Script made by Daniel */
public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;

    Rigidbody2D rb;
    string button;

    Light characterLight;
    float lightSize;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        characterLight = GetComponentInChildren<Light>();
        lightSize = characterLight.range;
        button = "Seperate" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
    }
	
	void Update ()
    {
        float x = Input.GetAxis("Horizontal" + " " + gameObject.name)/8; 
        float y = Input.GetAxis("Vertical"   + " " + gameObject.name)/10; 

        if (Input.GetButtonDown(button)) on = !on;
        if (on)
        {
            if (transform.localScale.x < 2)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f, 1);
                if (characterLight.range < lightSize * 4) characterLight.range += 0.2f;
                if (characterLight.range > lightSize * 4) characterLight.range = lightSize * 4;
            }
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(force.x + x, force.y + y), ForceMode2D.Impulse);
        }
        else
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.04f, transform.localScale.y - 0.04f, 1);
                if (characterLight.range > lightSize) characterLight.range -= 0.3f;
                if (characterLight.range < lightSize) characterLight.range = lightSize;
            }
            rb.gravityScale = 1;
        }
	}
}
