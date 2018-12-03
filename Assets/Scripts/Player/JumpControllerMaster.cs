using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControllerMaster : MonoBehaviour {

    public List<JumpController> playerMovements;

    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;

    public float jumpForceReduction;

    // Update is called once per frame
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
