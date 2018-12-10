using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class JumpControllerMaster : MonoBehaviour {

    public List<JumpController> playerMovements;

    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;

    public float jumpForceReduction;

    void FixedUpdate()
    {
        foreach (JumpController jc in playerMovements)
        {
            jc.jumpForce = this.jumpForce;
            jc.jumpTime = this.jumpTime;
            jc.jumpForceReduction = this.jumpForceReduction;
        }
    }
}
