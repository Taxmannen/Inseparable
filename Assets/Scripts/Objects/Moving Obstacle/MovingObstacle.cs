using UnityEngine;

/* Script made by Daniel */
public class MovingObstacle : MonoBehaviour {
    public int damage;
    public float damageRate;
    public float endPosX;
    public float speed;
    public bool on;
    public bool drawGizmos;
    public Vector2 offset;
    public GameObject blades;

    Vector2 endPos;
    CameraManager cameraManager;
    MeshRenderer sr;
    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool player1;
    bool player2;
    float timer;

    private void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();

        sr  = GetComponentInChildren<MeshRenderer>();
   
        sr.enabled = false;

        endPos = new Vector2(endPosX, transform.position.y);
    }

    void FixedUpdate()
    {
        if (on)
        {
            if (!sr.enabled) sr.enabled = true;

            timer -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed / 100);
            if (player1Stats.transform.position.x - (Mathf.Abs(player1Stats.transform.localScale.x/2)) < transform.position.x + 0.55f) player1 = true;
            else player1 = false;
            if (player2Stats.transform.position.x - (Mathf.Abs(player1Stats.transform.localScale.x/2)) < transform.position.x + 0.55f) player2 = true;
            else player2 = false;

            if (player1 || player2)
            {
                if (timer <= 0)
                {
                    if (player1) player1Stats.TakeHealth(damage);
                    if (player2) player2Stats.TakeHealth(damage);
                    timer = damageRate;
                }
            }
            if (Vector3.Distance(transform.position, endPos) < 0.1f) TurnOff();
        }
        else if (!on && player1Stats.transform.position.x > transform.position.x + (transform.localScale.x / 2) && player2Stats.transform.position.x > transform.position.x + (transform.localScale.x / 2))
        {
            Invoke("TurnOn", 1);
        }
	}

    void TurnOn()
    {
        on = true;
        cameraManager = Camera.main.GetComponent<CameraManager>();
        cameraManager.ChangeFocusTo(transform, offset, LockState.XAxis);
        blades.SetActive(true);
    }

    void TurnOff()
    {
        cameraManager.ResetFocus();
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawCube(new Vector2(endPosX, transform.position.y), transform.localScale);
        Transform c = transform.GetChild(0);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + 0.55f, transform.position.y), new Vector2(c.localScale.x, c.localScale.z*10));
    }
}
