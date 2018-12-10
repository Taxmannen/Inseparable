using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Script made by Michael */
public class Resolution : MonoBehaviour {
    public TextMeshProUGUI resValue;
    public string currentRes;
    public int index;
    public List<string> resolutions = new List<string>() { "1920 x 1080", "1280 x 720" };
    public MenuManager menuManagerScript;

    void Start ()
    {
        currentRes = resolutions[0];
        Debug.Log("Using" + " " + gameObject.name);
    }

    void Update()
    {
        if (menuManagerScript.toggleMenu)
        {
            if (Input.GetButtonDown("Submit"))
            {
                index++;
                Debug.Log("hi");
            }

            if (index >= resolutions.Count)
            {
                index = 0;
            }

            ChangeRes();
            resValue.text = currentRes;
        }
    }

    void ChangeRes()
    {
        for(int i = 0; i < resolutions.Count; i++)
        {
            currentRes = resolutions[index];
        }
    }
}
