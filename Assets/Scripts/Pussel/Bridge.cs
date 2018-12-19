using UnityEngine;

/* Script made by Jocke*/
public class Bridge : MonoBehaviour
{
    float speed = 0.0001f;
    bool isOpen = false;
    public Quaternion open;
    Quaternion closed;
    PressurePlate pressurePlate;
    

    private void Start()
    {
        pressurePlate = transform.parent.GetComponentInChildren<PressurePlate>();
        open = new Quaternion(0, 0, -90, 90);
        closed = new Quaternion(0, 0, 0, 90);
    }

    private void Update()
    {
        isOpen = pressurePlate.on;
        if (!isOpen) transform.rotation = Quaternion.Slerp(transform.rotation, closed, speed);
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, open, speed);            
        }
    }
}
