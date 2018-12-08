using UnityEngine;
using UnityEngine.EventSystems;

/* Script made by Michael */
public class SelectOnInput : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    void Update()
    {
        if (Input.GetAxisRaw("Vertical Player 1") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}