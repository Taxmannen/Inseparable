using UnityEngine;

public class Rope : MonoBehaviour {
    float maxDistance = 3.5f;

    Transform player1;
    Transform player2;
    LineRenderer line;
    DistanceJoint2D joint;

    void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        line = GetComponent<LineRenderer>();
        joint = GetComponent<DistanceJoint2D>();

        joint.distance = maxDistance;
    }

    void Update()
    {
        if (gameObject.name == "Player 1")
        {
            line.SetPosition(0, player1.position);
            line.SetPosition(1, player2.position);
            joint.connectedAnchor = player2.position;
        }
        else joint.connectedAnchor = player1.position;
        joint.anchor = new Vector2(0, 0);
    }
}