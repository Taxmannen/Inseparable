using UnityEngine;

public class Main : MonoBehaviour {
    public int frameRate;

    void Start()
    {
        Application.targetFrameRate = frameRate;
    }
}