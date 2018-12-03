using UnityEngine;

/* Script made by Daniel */
public class DeathArea : MonoBehaviour {

    LevelManager levelManager;
    //Transform player1;
    //Transform player2;
    //Transform rope;

    private void Start()
    {
        levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();

        /*
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        rope    = GameObject.Find("Rope").transform;
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.Load("Main");
            
            /*foreach (Transform t in rope) Destroy(t.gameObject);
            player1.position = new Vector3(-2, 0.3f, 0);
            player2.position = new Vector3(2, 0.3f, 0);
            rope.GetComponent<RopeCreator>().CreateRope();
            */
        }
    }
}