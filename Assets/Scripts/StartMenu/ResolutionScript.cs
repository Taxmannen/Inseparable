using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionScript : MonoBehaviour {

    public TextMeshProUGUI resValue;
    public string currentRes;
    public int index;
    public List<string> resolutions = new List<string>() { "1920 x 1080", "1280 x 720" };


    // Use this for initialization
    void Start () {
        currentRes = resolutions[0];
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            index++;
        }

        if(index >= resolutions.Count)
        {
            index = 0;
        }

        changeRes();

        resValue.text = currentRes;
    }

    void changeRes()
    {
        for(int i = 0; i < resolutions.Count; i++)
        {
            currentRes = resolutions[index];
        }

    }
}
