using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class CameraManager : MonoBehaviour {
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;

    Transform player1;
    Transform player2;

    Transform focus = null;
    Vector3 focusOffset = new Vector3(0, 0, 0);

    List<ScrollingBackground> backgrounds;
    
    public bool limitLess;
    public float lerpValue;

    public static CameraManager instance;

    void Start()
    {
        FindPlayers();

        backgrounds = new List<ScrollingBackground>();
        Transform bg = GameObject.Find("Scrolling Background").transform;
        foreach (Transform t in bg) backgrounds.Add(t.GetComponent<ScrollingBackground>());

        //Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void FindPlayers()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
    }

    public static float Damp(float source, float target, float smoothing, float dt)
    {
        return Mathf.Lerp(source, target, 1 - Mathf.Pow(smoothing, dt));
    }

    void FixedUpdate()
    {
        if (player1 == null || player2 == null) FindPlayers();

        if (focus == null)
            FocusOn((player1.position + player2.position) * 0.5f);
        else
            FocusOn(focus.position + focusOffset);

        foreach (ScrollingBackground b in backgrounds)
        {
            if (b != null) b.UpdatePosition();
        }
    }

    public void ChangeFocusTo(Transform tf)
    {
        ChangeFocusTo(tf, new Vector3(0f, 0f));
    }

    public void ChangeFocusTo(Transform tf, Vector3 offset)
    {
        focus = tf;
        focusOffset = offset;
        Vector3 newCameraPosition = tf.position + offset;
        newCameraPosition.z = -10;
        //transform.position = newCameraPosition;
    }

    public void ResetFocus()
    {
        focus = null;
        Vector3 newCameraPosition = (player1.position + player2.position) * 0.5f;
        newCameraPosition.z = -10;
        //transform.position = newCameraPosition;
    }

    public void FocusOn(Vector3 position)
    {
        float x, y;
        if (!limitLess)
        {
            x = Mathf.Clamp(position.x,
                left.position.x + Camera.main.orthographicSize * Camera.main.aspect,
                right.position.x - Camera.main.orthographicSize * Camera.main.aspect);

            y = Mathf.Clamp(position.y,
                bottom.position.y + Camera.main.orthographicSize,
                top.position.y - Camera.main.orthographicSize);
        }
        else
        {
            x = position.x;
            y = position.y;
        }

        x = Damp(transform.position.x, x, 0.07f, Time.deltaTime);
        y = Damp(transform.position.y, y, 0.07f, Time.deltaTime);

        transform.position = new Vector3(x, y, -10f);
    }
}