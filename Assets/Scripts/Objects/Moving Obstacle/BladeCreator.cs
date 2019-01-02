using UnityEngine;

public class BladeCreator : MonoBehaviour {
    public Transform chain;
    public Sprite sprite;
    public int size;
    public float rotationSpeed;
    public Vector2 offset;

    GameObject[] gameObjects;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, chain.localScale.z * 5, 0);

        gameObjects = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            GameObject g = new GameObject();
            g.name = "Blade" + " " + i;
            g.transform.SetParent(transform);
            g.transform.localPosition = new Vector3((offset.x * i), (offset.y * i), 0);

            SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingOrder = 100;

            Blade b = g.AddComponent<Blade>();
            b.SetRotationSpeed(rotationSpeed);

            gameObjects[i] = g;
        }
        gameObject.SetActive(false);
    }
}
