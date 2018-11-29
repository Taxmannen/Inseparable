using UnityEngine;

/* Script made by Daniel */
public class TransferBetweenScenes : MonoBehaviour {
    static TransferBetweenScenes Instance;

    private void Start()
    {
        if (Instance != null) Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
