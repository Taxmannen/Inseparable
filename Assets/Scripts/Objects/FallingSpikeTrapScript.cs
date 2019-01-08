using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeTrapScript : MonoBehaviour
{
    public BoxCollider2D trigger;
    Vector3 startPos;
    Vector3 targetPos;
    public Transform start;
    public Transform target;
    public float travelTime;
    float timer;
    bool down;
    bool startMoving;

    

    void Start()
    {
        startPos = transform.position;
        targetPos = target.position;
        timer = 0.0f;
    }

    void Update()
    {
        if (startMoving)
        {
            AudioManager.PlayOneShot("GateOpen");
            AudioManager.Play("GateOpen");
            timer += Time.deltaTime;
            Debug.Log("Start = " + startPos);
            Debug.Log("End = " + targetPos);
            if (!down)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, timer / travelTime);
                if (transform.position == targetPos)
                {
                    down = true;
                    timer = 0;
                }
            }

            else
            {
                transform.position = Vector3.Lerp(targetPos, startPos, timer / travelTime);
                if (transform.position == startPos)
                {
                    down = false;
                    timer = 0;
                }
            }
        }
        else
            AudioManager.Stop("GateOpen");
    }

    void Move()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2")
        {
            startMoving = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startMoving = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(startPos, 0.8f);
        Gizmos.DrawSphere(targetPos, 0.8f);
    }
}
