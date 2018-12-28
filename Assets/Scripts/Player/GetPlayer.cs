using UnityEngine;

/* Script made by Adam */
public class GetPlayer : MonoBehaviour {

    public static Transform player1, player2;

    static string player1String = "Player 1", player2String = "Player 2";

    public static bool player1Ready() { return player1 != null; }
    public static bool player2Ready() { return player2 != null; }

    public static bool playerReady(string name){
        if(name == player1String){
            return player1Ready();
        }
        else if(name == player2String)
        {
            return player2Ready();
        }
        return false;
    }
    public static bool otherPlayerReady(string name) { return playerReady(getOtherName(name)); }

    public static void FindPlayers() {
        if (!player1Ready()) {
            GameObject player1GameObject = GameObject.Find(player1String);
            if (!(player1GameObject == null))
                player1 = player1GameObject.transform;
        }

        if (!player2Ready()) {
            GameObject player2GameObject = GameObject.Find(player2String);
            if (!(player2GameObject == null))
                player2 = player2GameObject.transform;
        }
    }

    public static Transform getPlayerByName(string name)
    {
        return getPlayerWithName(name);
    }

    public static Transform getOtherPlayerByName(string name)
    {
        return getPlayerWithName(getOtherName(name));
    }

    public static bool getPlayerGroundedByName(string name, LayerMask groundLayer)
    {
        return getPlayerGrounded(getPlayerByName(name), groundLayer);
    }

    public static bool getOtherPlayerGroundedByName(string name, LayerMask groundLayer)
    {
        return getPlayerGrounded(getOtherPlayerByName(name), groundLayer);
    }

    public static bool getPlayerGrounded(Transform player, LayerMask groundLayer)
    {
        return Physics2D.OverlapBox(
            new Vector2(player.position.x, player.position.y - 0.5f), new Vector2(0.7f, 0.1f),
            0,
            groundLayer);
    }

    public static bool getPlayerGroundedStrictByName(string name, LayerMask groundLayer)
    {
        return getPlayerGroundedStrict(getPlayerByName(name), groundLayer);
    }

    public static bool getOtherPlayerGroundedStrictByName(string name, LayerMask groundLayer)
    {
        return getPlayerGroundedStrict(getOtherPlayerByName(name), groundLayer);
    }

    public static bool getPlayerGroundedStrict(Transform player, LayerMask groundLayer)
    {
        return Physics2D.OverlapBox(
            new Vector2(player.position.x, player.position.y - 0.5f),
            new Vector2(0.05f, 0.1f),
            0,
            groundLayer);
    }

    public static string getOtherName(string name)
    {
        if (name != player1String && name != player2String)
            return "";

        if (name == player1String)
        {
            return player2String;
        }
        else
            return player1String;
            
    }

    static Transform getPlayerWithName(string name)
    {
        if (name != player1String && name != player2String)
            return null;

        if (name == player1String)
        {
            return player1;
        }
        else if (name == player2String)
        {
            return player2;
        }

        return null;
    }
	
	void FixedUpdate() {
        FindPlayers();	
	}
}
