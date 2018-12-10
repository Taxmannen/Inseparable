using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class MoveControllerMaster : MonoBehaviour {

    public List<MovementController> playerMovements;

    [Header("Air Variables")]
    public float airForce;

    [Header("Ground Variables")]
    public float maxGroundSpeed;
    public float flatMultiplier;
    
	// Update is called once per frame
	void FixedUpdate () {
		foreach(MovementController mc in playerMovements)
        {
            mc.airForce = this.airForce;
            mc.maxGroundSpeed = this.maxGroundSpeed;
            mc.flatMultiplier = this.flatMultiplier;
        }
    }
}
