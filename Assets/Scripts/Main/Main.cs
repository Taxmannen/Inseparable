using UnityEngine;

public class Main : MonoBehaviour {
    public int frameRate;
    public static string[] controllers;

    void Start()
    {
        controllers = new string[2];
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < 2; x++)
        {
            if (names.Length > x && names[x].Length == 19) controllers[x] = "PS4";
            else                                           controllers[x] = "XBOX";
        }
    }

    private void Update()
    {
        //ButtonTest("Player 1");
        //ButtonTest("Player 2");
        //if (Input.GetButtonDown("Menu XBOX")) Debug.Log("Menu XBOX");
        //if (Input.GetButtonDown("Menu PS4"))  Debug.Log("Menu PS4");
    }

    void ButtonTest(string player)
    {
        if (Input.GetButtonDown("Jump"     + " " + player)) Debug.Log("Jump");
        if (Input.GetButtonDown("Attack"   + " " + player)) Debug.Log("Atack");
        if (Input.GetButtonDown("Use Item" + " " + player)) Debug.Log("Use Item");
        if (Input.GetButtonDown("Seperate" + " " + player)) Debug.Log("Seperate");


        if (Input.GetAxisRaw("Pickup" + " " + player) != 0) Debug.Log("Pickup");
        if (Input.GetAxisRaw("Throw"  + " " + player) != 0) Debug.Log("Throw");

        if (Input.GetAxisRaw("Change Item" + " " + player) < 0) Debug.Log("Change Item -");
        if (Input.GetAxisRaw("Change Item" + " " + player) > 0) Debug.Log("Change Item +");

        if (Input.GetButtonDown("Inventory" + " " + player)) Debug.Log("Inventory");

        if (Input.GetButtonDown("Menu")) Debug.Log("Menu");
    }
}