using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public static List<GameObject> boulders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        boulders.Add(gameObject);
    }

    private void OnDestroy()
    {
        boulders.Remove(gameObject);
    }
}
