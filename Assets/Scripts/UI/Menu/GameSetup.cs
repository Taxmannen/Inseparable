﻿using UnityEngine;

/* Script made by Daniel */
public class GameSetup : MonoBehaviour { //DÅLIGT NAMN BYT!
    public GameObject rope;
    public GameObject player1;
    public GameObject player2;
    public GameObject player1UI;
    public GameObject player2UI;
    public GameObject player1Text;
    public GameObject player2Text;
    LineRenderer player2Line;

    bool player1Ready;
    bool player2Ready;
    string player1Button;
    string player2Button;

	void Start ()
    {
        player2Line = player2.GetComponent<LineRenderer>();
        player1Button = "Menu" + " " + "Player 1" + " " + Main.controllers[0];
        player2Button = "Menu" + " " + "Player 2" + " " + Main.controllers[1];

        rope.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player1UI.SetActive(false);
        player2UI.SetActive(false);
        player2Line.enabled = false;
    }

    private void Update()
    {
        if (!player1Ready && Input.GetButtonDown(player1Button))
        {
            player1Ready = true;
            player1Text.SetActive(false);
            player1.SetActive(true);
        }
        else if (!player2Ready && Input.GetButtonDown(player2Button))
        {
            player2Ready = true;
            player2Text.SetActive(false);
            player2.SetActive(true);
        }

        if (player1Ready && player2Ready)
        {
            rope.SetActive(true);
            player2Line.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") Invoke("EnableHud", 0.25f);
    }

    void EnableHud()
    {
        player1UI.SetActive(true);
        player2UI.SetActive(true);
        player1UI.GetComponentInChildren<Inventory>().SetAlpha(0);
        player2UI.GetComponentInChildren<Inventory>().SetAlpha(0);
    }
}