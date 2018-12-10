using UnityEngine;

/* Script made by Daniel */
public class ScrollingBackground : MonoBehaviour {
    public float scrollSpeed;
    public float flat;
    public bool moveWithTime;

    Renderer rend;
    Transform cam;

    float timeOffset;
    float oldX;

    void Start()
    {
        timeOffset = 0;
        rend = GetComponent<Renderer>();
        cam = GameObject.Find("Main Camera").transform;
        oldX = cam.position.x;
    }

    public void UpdatePosition()
    {
        if (rend != null)
        {
            oldX = Mathf.Lerp(oldX, cam.position.x, 5f);
            if (moveWithTime) timeOffset += Time.deltaTime * flat * this.scrollSpeed;
            rend.material.mainTextureOffset = new Vector2(oldX * scrollSpeed + timeOffset, 0);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
    }
}
