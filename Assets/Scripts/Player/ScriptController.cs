using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {}

public class ScriptController : MonoBehaviour {

    public GameObject player;

    Dictionary<MovementScript, bool> scriptStates = new Dictionary<MovementScript, bool>();
    
    public void freezePlayer()
    {
        MovementScript[] scripts = player.GetComponents<MovementScript>();

        foreach(MovementScript script in scripts)
        {
            scriptStates[script] = script.enabled;
            script.enabled = false;
        }

    }

    public void unfreezePlayer()
    {
        MovementScript[] scripts = player.GetComponents<MovementScript>();

        foreach (MovementScript script in scripts)
        {
            script.enabled = scriptStates[script];
        }

        scriptStates = new Dictionary<MovementScript, bool>();
    }
}
