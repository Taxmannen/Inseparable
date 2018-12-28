using UnityEngine;

/* Script made by Daniel*/
public class PlayerAim : MonoBehaviour {
    ThrowPlayer throwPlayer;
    SpriteRenderer spriteRenderer;

    float angle;
 
    void Start()
    {
        throwPlayer = GetComponentInParent<ThrowPlayer>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (throwPlayer.pickup)
        {
            spriteRenderer.enabled = true;
            float x = Input.GetAxis("Horizontal" + " " + transform.parent.name);
            float y = Input.GetAxis("Vertical" + " " + transform.parent.name);
            if (x != 0.0f || y != 0.0f) angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else spriteRenderer.enabled = false;
    }
}
