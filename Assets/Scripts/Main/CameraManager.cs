using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockState {
    NoLock,
    XAxis,
    YAxis,
    YAxisAndXAxis
}

/* Script made by Adam */
public class CameraManager : MonoBehaviour {
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;
    
    PlayerStats player1stats;
    PlayerStats player2stats;

    Transform focus = null;
    Vector3 focusOffset = new Vector3(0, 0, 0);
    LockState focusLock;

    List<ScrollingBackground> backgrounds;
    
    public bool limitLess;
    public float lerpValue;

    public static CameraManager instance;
    
    void Start()
    {
        focusLock = LockState.NoLock;

        backgrounds = new List<ScrollingBackground>();
        Transform bg = GameObject.Find("Scrolling Background").transform;
        foreach (Transform t in bg) backgrounds.Add(t.GetComponent<ScrollingBackground>());

        //Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public static float Damp(float source, float target, float smoothing, float dt)
    {
        return Mathf.Lerp(source, target, 1 - Mathf.Pow(smoothing, dt));
    }

    void FixedUpdate()
    {
        if (!GetPlayer.player1Ready() || !GetPlayer.player2Ready())
            GetPlayer.FindPlayers();

        if (focus == null)
            FocusOn(getPlayerPosition());
        else
            FocusOn(getFocusPosition());

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
        ChangeFocusTo(tf, offset, LockState.YAxisAndXAxis);
    }

    public void ChangeFocusTo(Transform tf, Vector3 offset, LockState axisLock)
    {
        focus = tf;
        focusOffset = offset;
        Vector3 newCameraPosition = tf.position + offset;
        newCameraPosition.z = -10;
        this.focusLock = axisLock;
    }

    public void ResetFocus()
    {
        focus = null;
        Vector3 newCameraPosition = (GetPlayer.player1.position + GetPlayer.player2.position) * 0.5f;
        newCameraPosition.z = -10;
        //transform.position = newCameraPosition;
    }

    public Vector3 getPlayerPosition() {
        if (GetPlayer.player1Ready() && GetPlayer.player2Ready())
            if (!GetPlayer.player1.GetComponent<PlayerStats>().GetDead() && 
                !GetPlayer.player2.GetComponent<PlayerStats>().GetDead())
                return (GetPlayer.player1.position + GetPlayer.player2.position) * 0.5f;
        else if (!GetPlayer.player1.GetComponent<PlayerStats>().GetDead() && GetPlayer.player1Ready())
            return GetPlayer.player1.position;
        else if (GetPlayer.player2Ready())
            return GetPlayer.player2.position;
        return new Vector3(0, 0, 0);
    }
    
    public Vector3 getFocusPosition() {
        Vector3 originalVector = focus.position + focusOffset;
        if (focusLock == LockState.XAxis)
           originalVector.y = getPlayerPosition().y;
        else if (focusLock == LockState.XAxis)
            originalVector.x = getPlayerPosition().x;
        return originalVector;
    }

    public float ClampValue(float source, float max, float min) {
        if (limitLess)
            return source;
        return Mathf.Clamp(source, max, min);
    }

    public void FocusOn(Vector3 position)
    {   
        float x = ClampValue(position.x,
            left.position.x + Camera.main.orthographicSize * Camera.main.aspect,
            right.position.x - Camera.main.orthographicSize * Camera.main.aspect);
        float y = ClampValue(position.y,
            bottom.position.y + Camera.main.orthographicSize,
            top.position.y - Camera.main.orthographicSize);

        x = Damp(transform.position.x, x, 0.07f, Time.deltaTime);
        y = Damp(transform.position.y, y, 0.07f, Time.deltaTime);

        transform.position = new Vector3(x, y, -10f);
    }
}