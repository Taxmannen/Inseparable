using UnityEngine;

/* Script made by Michael */
public class Smoke : MonoBehaviour
{
    public LayerMask ground;
    private ParticleSystem ps;
    public string player;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = 10f;
        if (GetPlayer.playerReady(player))
        if (GetPlayer.getPlayerGroundedByName(player, ground) && (Input.GetButton("Horizontal " + player)))
        {
            emission.enabled = true;
        }
        else emission.enabled = false;
    }
}

