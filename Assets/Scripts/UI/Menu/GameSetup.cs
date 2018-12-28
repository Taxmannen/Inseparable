using UnityEngine;

/* Script made by Daniel */
public class GameSetup : MonoBehaviour {
    public GameObject player1UI;
    public GameObject player2UI;

	void Start ()
    {
        player1UI.SetActive(false);
        player2UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") Invoke("EnableHud", 0.25f);
    }

    public void EnableHud()
    {
        player1UI.SetActive(true);
        player2UI.SetActive(true);
        player1UI.GetComponentInChildren<Inventory>().SetAlpha(0);
        player2UI.GetComponentInChildren<Inventory>().SetAlpha(0);
    }
}