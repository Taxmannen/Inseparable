using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by Jocke
public class SawBladesMovement : MonoBehaviour
{
    [Header("Movement Setting X")]
    public bool movementX;
    public float PossitiveMoveRangeX;
    public float NegativeMoveRangeX;
    public float speedX;

    float timerX;
    bool PossitiveMoveX;
    bool NegativeMoveX;
    float startPositionX;

    [Header("Movement Setting Y")]
    public bool movementY;
    public float PossitiveMoveRangeY;
    public float NegativeMoveRangeY;
    public float speedY;

    float timerY;
    bool PossitiveMoveY;
    bool NegativeMoveY;
    float startPositionY;

    private void Start()
    {
        NegativeMoveX = movementX;
        NegativeMoveY = movementY;
        timerX = transform.position.x;
        timerY = transform.position.y;
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }
    private void FixedUpdate()
    {
        if (movementX) MovementX();
        if (movementY) MovementY();
    }

    void MovementX()
    {
        if (timerX > (startPositionX + PossitiveMoveRangeX))
        {
            NegativeMoveX = true;
            PossitiveMoveX = false;
        }

        if (timerX < (startPositionX + NegativeMoveRangeX))
        {
            NegativeMoveX = false;
            PossitiveMoveX = true;
        }

        if (PossitiveMoveX) timerX += Time.deltaTime * speedX;
        if (NegativeMoveX) timerX -= Time.deltaTime * speedX;

        float x = timerX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void MovementY()
    {
        if (timerY > (startPositionY + PossitiveMoveRangeY))
        {
            NegativeMoveY = true;
            PossitiveMoveY = false;
        }

        if (timerY < (startPositionY + NegativeMoveRangeY))
        {
            NegativeMoveY = false;
            PossitiveMoveY = true;
        }

        if (PossitiveMoveY) timerY += Time.deltaTime * speedY;
        if (NegativeMoveY) timerY -= Time.deltaTime * speedY;

        float y = timerY;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
