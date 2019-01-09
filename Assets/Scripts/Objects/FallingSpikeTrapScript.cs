using UnityEngine;

public class FallingSpikeTrapScript : MonoBehaviour
{
    public Transform start;
    public Transform target;
    public float travelTime;
    Vector3 startPos;
    Vector3 targetPos;
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
