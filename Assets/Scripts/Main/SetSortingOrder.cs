using UnityEngine;

/* Script made by Daniel */
[ExecuteInEditMode]
public class SetSortingOrder : MonoBehaviour {
    public int order;

	void Start ()
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.sortingOrder = order;
    }
}
