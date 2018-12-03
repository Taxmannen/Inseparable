using System.Collections.Generic;
using UnityEngine;

/* Made by Daniel */
public class RopeCreator : MonoBehaviour{
    public Vector2 scale = new Vector2(0.2f, 0.2f);
    public Sprite ropeSprite;
    public Material material;
    public float mass = 0.06f;
    public int size = 50;

    [Header("Hinge Joint")]
    public float maxDistance = 0.1f;
    public bool autoConfigureAnchor = false;
    public bool autoConfigureDistance = false;
    public bool maxDistanceOnly = true;

    List<GameObject> gameObjects;
    Transform player1;
    Transform player2;
    Transform firstLink;
    Transform lastLink;

    void Start()
    {
        gameObjects = new List<GameObject>();
        Vector3 pos = transform.position;
        for (int i = 0; i < size; i++)
        {
            GameObject g = new GameObject();
            g.transform.parent = transform;
            g.layer = LayerMask.NameToLayer("Rope");
            g.transform.localScale = new Vector3(scale.x, scale.y, 1);
            g.transform.localPosition = new Vector3(0, 0 - ((scale.x * 0.33f) * i), 0);
            g.name = "" + (i + 1);
         
            Rigidbody2D rb = g.AddComponent<Rigidbody2D>();
            rb.mass = mass;

            SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
            sr.sprite = ropeSprite;
            sr.material = material;

            g.AddComponent<BoxCollider2D>();
            gameObjects.Add(g);
        }

        for (int i = size-1; i > 0; i--)
        {
            if (i != 0 && i < size-1)
            {
                DistanceJoint2D dj1 = transform.GetChild(i).gameObject.AddComponent<DistanceJoint2D>();
                dj1.connectedBody = transform.GetChild(i+1).GetComponent<Rigidbody2D>();
                dj1.autoConfigureConnectedAnchor = autoConfigureAnchor;
                dj1.autoConfigureDistance = autoConfigureDistance;
                dj1.maxDistanceOnly = maxDistanceOnly;
                dj1.distance = maxDistance;

                DistanceJoint2D dj2 = transform.GetChild(i).gameObject.AddComponent<DistanceJoint2D>();
                dj2.connectedBody = transform.GetChild(i-1).GetComponent<Rigidbody2D>();
                dj2.autoConfigureConnectedAnchor = autoConfigureAnchor;
                dj2.autoConfigureDistance = autoConfigureDistance;
                dj2.maxDistanceOnly = maxDistanceOnly;
                dj2.distance = maxDistance;

                HingeJoint2D hj1 = transform.GetChild(i).gameObject.AddComponent<HingeJoint2D>();
                hj1.connectedBody = transform.GetChild(i-1).GetComponent<Rigidbody2D>();
                hj1.autoConfigureConnectedAnchor = false;
                hj1.connectedAnchor = new Vector2(-0.2f, 0);


                HingeJoint2D hj2 = transform.GetChild(i).gameObject.AddComponent<HingeJoint2D>();
                hj2.connectedBody = transform.GetChild(i+1).GetComponent<Rigidbody2D>();
                hj2.autoConfigureConnectedAnchor = false;
                hj2.connectedAnchor = new Vector2(0.2f, 0);

                /*if (i != 1)
                {
                    JointAngleLimits2D limit = new JointAngleLimits2D { min = 0, max = 0 };
                    hj1.limits = limit;
                    hj2.limits = limit;
                }*/
            }
        }
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;

        firstLink = transform.GetChild(0);
        lastLink = transform.GetChild(size - 1);

        player1.GetComponent<HingeJoint2D>().connectedBody = firstLink.GetComponent<Rigidbody2D>();
        player2.GetComponent<HingeJoint2D>().connectedBody = lastLink.GetComponent<Rigidbody2D>();

        player1.GetComponent<DistanceJoint2D>().connectedBody = firstLink.GetComponent<Rigidbody2D>();
        player2.GetComponent<DistanceJoint2D>().connectedBody = lastLink.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        firstLink.position = player1.position;
        lastLink.position  = player2.position;
    }
}
