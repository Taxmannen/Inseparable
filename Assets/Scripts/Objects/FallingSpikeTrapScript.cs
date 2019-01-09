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

   
    void Start()
    {
        startPos = transform.position;
        targetPos = target.position;
        timer = 0.0f;
    }

    void Update()
    {
        AudioManager.PlayOneShot("GateOpen");
        AudioManager.Play("GateOpen");
        timer += Time.deltaTime;
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
            
            //AudioManager.Stop("GateOpen");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(startPos, 0.8f);
        Gizmos.DrawSphere(targetPos, 0.8f);
    }
}
