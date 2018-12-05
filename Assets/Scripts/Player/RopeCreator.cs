using System.Collections.Generic;
using UnityEngine;

/* Made by Daniel */
public class RopeCreator : MonoBehaviour{
    public Vector2 scale = new Vector2(0.2f, 0.2f);
    public Vector2 placement = new Vector2(0.2f, 0.2f); 
    public Sprite ropeSprite;
    public Material material;
    public float mass = 0.06f;
    public int size = 50;

    [Header("Hinge Joint")]
    public Vector2 hingePosition;
    public bool hingeOn;
    public bool hingeAutoConfigureAnchor;

    [Header("Distance Joint")]
    public float maxDistance = 0.1f;
    public bool distanceOn = true;
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
        CreateRope();   
    }

    private void Update()
    {
        if (firstLink != null) firstLink.position = player1.position;
        if (lastLink  != null) lastLink.position  = player2.position;
    }

    public void CreateRope()
    {
        gameObjects = new List<GameObject>();
        Vector3 pos = transform.position;
        for (int i = 0; i < size; i++)
        {
            GameObject g = new GameObject();
            g.transform.parent = transform;
            g.layer = LayerMask.NameToLayer("Rope");
            g.transform.localScale = new Vector3(scale.x, scale.y, 1);
            g.transform.localPosition = new Vector3(placement.x, 0 - (placement.y * i), 0);
            g.name = "" + (i + 1);

            Rigidbody2D rb = g.AddComponent<Rigidbody2D>();
            if (i == 0 || i == size - 1) rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Tas bort?
            rb.mass = mass;

            SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
            sr.sprite = ropeSprite;
            sr.material = material;

            g.AddComponent<BoxCollider2D>();
            gameObjects.Add(g);
        }

        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        Rigidbody2D player1rb = player1.GetComponent<Rigidbody2D>();
        Rigidbody2D player2rb = player2.GetComponent<Rigidbody2D>();

        for (int i = 0; i < size; i++)
        {
            if (distanceOn)
            {
                DistanceJoint2D dj1 = transform.GetChild(i).gameObject.AddComponent<DistanceJoint2D>();
                if (i + 1 == size) dj1.connectedBody = player2rb;
                if (i + 1 < size)  dj1.connectedBody = transform.GetChild(i + 1).GetComponent<Rigidbody2D>();

                dj1.autoConfigureConnectedAnchor = autoConfigureAnchor;
                dj1.autoConfigureDistance = autoConfigureDistance;
                dj1.maxDistanceOnly = maxDistanceOnly;
                dj1.distance = maxDistance;

                DistanceJoint2D dj2 = transform.GetChild(i).gameObject.AddComponent<DistanceJoint2D>();
                if (i == 0) dj2.connectedBody = player1rb;
                if (i > 0) dj2.connectedBody = transform.GetChild(i - 1).GetComponent<Rigidbody2D>();
             
                dj2.autoConfigureConnectedAnchor = autoConfigureAnchor;
                dj2.autoConfigureDistance = autoConfigureDistance;
                dj2.maxDistanceOnly = maxDistanceOnly;
                dj2.distance = maxDistance;
            }
          
            if (hingeOn)
            {
                HingeJoint2D hj1 = transform.GetChild(i).gameObject.AddComponent<HingeJoint2D>();
                if (i == 0) hj1.connectedBody = player1rb;
                else hj1.connectedBody = transform.GetChild(i - 1).GetComponent<Rigidbody2D>();
                hj1.autoConfigureConnectedAnchor = hingeAutoConfigureAnchor;
                if (i == 0) hj1.autoConfigureConnectedAnchor = true;
                hj1.connectedAnchor = new Vector2(-hingePosition.x, hingePosition.y);


                HingeJoint2D hj2 = transform.GetChild(i).gameObject.AddComponent<HingeJoint2D>();
                if (i + 1 == size) hj2.connectedBody = player2rb;
                else hj2.connectedBody = transform.GetChild(i + 1).GetComponent<Rigidbody2D>();
                hj2.autoConfigureConnectedAnchor = hingeAutoConfigureAnchor;
                if (i == size -1) hj2.autoConfigureConnectedAnchor = true;
                hj2.connectedAnchor = new Vector2(hingePosition.x, hingePosition.y);
            }

            /*if (i != 1)
            {
                JointAngleLimits2D limit = new JointAngleLimits2D { min = 0, max = 0 };
                hj1.limits = limit;
                hj2.limits = limit;
            }*/
        }
        firstLink = transform.GetChild(0);
        lastLink = transform.GetChild(size - 1);

        player1.GetComponent<HingeJoint2D>().connectedBody = firstLink.GetComponent<Rigidbody2D>();
        player2.GetComponent<HingeJoint2D>().connectedBody = lastLink.GetComponent<Rigidbody2D>();

        player1.GetComponent<DistanceJoint2D>().connectedBody = firstLink.GetComponent<Rigidbody2D>();
        player2.GetComponent<DistanceJoint2D>().connectedBody = lastLink.GetComponent<Rigidbody2D>();

    }
}
