using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class RopeCreatorTest : MonoBehaviour {

    public List<GameObject> ropeSegments;
    public GameObject ropeSegment;
    public int segments;

    void Start()
    {
        for (int i = 0; i < ropeSegments.Count; i++)
        {
            Destroy(ropeSegments[i]);
            ropeSegments.Remove(ropeSegments[i]);
        }

        GameObject currentSegment = Instantiate(ropeSegment, transform.position, Quaternion.identity, transform);
        SpriteRenderer sr = currentSegment.GetComponent<SpriteRenderer>();
        Vector3 itemSize = sr.bounds.size;

        for (int i = 0; i < segments; i++)
        {

            Vector3 nextPosition = currentSegment.GetComponent<Transform>().position;
            nextPosition.y -= itemSize.y;
            GameObject nextInChain = Instantiate(ropeSegment, nextPosition, Quaternion.identity, transform);
            HingeJoint2D hinge = nextInChain.GetComponent<HingeJoint2D>();
            hinge.connectedBody = currentSegment.GetComponent<Rigidbody2D>();
            currentSegment = nextInChain;
            ropeSegments.Add(currentSegment);
        }
    }
}
