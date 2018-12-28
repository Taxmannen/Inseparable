using UnityEngine;

/* Script made by Michael */
public class Smoke : MonoBehaviour
{
    public LayerMask ground;
    private ParticleSystem ps;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = 10f;
        if (GetPlayer.playerReady(transform.parent.gameObject.name))
        if (GetPlayer.getPlayerGroundedByName(transform.parent.gameObject.name, ground) && (Input.GetButton("Horizontal " + transform.parent.gameObject.name)))
        {
            emission.enabled = true;
        }
        else emission.enabled = false;
    }
}

