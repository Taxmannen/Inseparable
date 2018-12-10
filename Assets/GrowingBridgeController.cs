﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBridgeController : LeverAction {
    
    public List<Sprite> topTiles;
    public List<Sprite> midTiles;

    public Sprite botTile;
    public Sprite topLeftInvertedTile;
    public Sprite topRightInvertedTile;

    public int width;
    public int height;

    public int sortingOrderStatic;

    public float percentageOfDistancePerTick;

    public GameObject movingObjects;
    public GameObject staticObjects;

    Vector3 startPosition;
    Vector3 endPosition;

    GameObject[] staticTiles;
    List<GameObject> movingTiles;

    public bool drawGizmos;

    bool leverState;
    bool moving;

    // Use this for initialization
    void Start () {
        staticTiles = new GameObject[(width + 6) * (height + 2)];
        movingTiles = new List<GameObject>();

        startPosition = movingObjects.transform.localPosition;
        endPosition = movingObjects.transform.localPosition + new Vector3(width + 6, 0);
        leverState = false;
        moving = false;
	}

    GameObject spawnTile(float x, float y, Sprite sprite, Transform parent, int sortingOrder)
    {
        GameObject gameObject = new GameObject();
        gameObject.transform.SetParent(parent);
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        BoxCollider2D bc2d = gameObject.AddComponent<BoxCollider2D>();
        bc2d.size = new Vector2(1, 1);
        gameObject.transform.localPosition = new Vector3(x + sprite.bounds.size.x / 2, y - sprite.bounds.size.x / 2);
        gameObject.layer = transform.gameObject.layer;
        sr.sprite = sprite;
        sr.sortingOrder = sortingOrder;
        
        return gameObject;
    }

    public override void LeverPulled(bool leverState)
    {
        bool previousLeverState = this.leverState;
        this.leverState = leverState;
        moving = true;

        if (movingTiles.Count == 0)
        {
            movingTiles.Add(this.spawnTile(0, 0, topTiles[0], movingObjects.transform, sortingOrderStatic + 1));
            for(int i=0; i < height; i++)
            movingTiles.Add(this.spawnTile(0, -(1 + i), midTiles[0], movingObjects.transform, sortingOrderStatic + 1));

            if (previousLeverState)
                movingTiles.Add(this.spawnTile(0, -(1 + height), topRightInvertedTile, movingObjects.transform, sortingOrderStatic + 1));
            else
                movingTiles.Add(this.spawnTile(0, -(1 + height), topLeftInvertedTile, movingObjects.transform, sortingOrderStatic + 1));
        }

    }

    public void destroyMoving()
    {
        Debug.Log("Destroying!");
        foreach (GameObject go in new List<GameObject>(movingTiles.ToArray()))
        {
            Destroy(go);
            movingTiles.Remove(go);
        }
    }

    // Update is called once per frame
    void Update () {
        if (moving)
        {
            Vector3 differenceVector;
            if (leverState) differenceVector = endPosition - startPosition;
            else differenceVector = startPosition - endPosition;

            Vector3 movement = differenceVector * percentageOfDistancePerTick;
            movingObjects.transform.position += movement;

            for (float i=0f; i < (width + 6) * (height + 2); i++)
            {
                float y = (int)(i % (height + 2));
                float x = (int)(i / (height + 2));
                if (x <= movingObjects.transform.localPosition.x)
                {
                    if (staticTiles[(int)i] == null)
                    {
                        Debug.Log("x=" + x + ", y=" + y);
                        if (y == 0)
                            staticTiles[(int)i] = this.spawnTile(x, -y, topTiles[0], staticObjects.transform, sortingOrderStatic);
                        else if (y > (int)((i + 1) % (height + 2)))
                            if (x == endPosition.x - 1 || x == endPosition.x || x == startPosition.x + 1 || x == startPosition.x)
                                staticTiles[(int)i] = this.spawnTile(x, -y, midTiles[0], staticObjects.transform, sortingOrderStatic);
                            else if (x == startPosition.x + 2)
                                staticTiles[(int)i] = this.spawnTile(x, -y, topLeftInvertedTile, staticObjects.transform, sortingOrderStatic);
                            else if (x == endPosition.x - 2)
                                staticTiles[(int)i] = this.spawnTile(x, -y, topRightInvertedTile, staticObjects.transform, sortingOrderStatic);
                            else
                                staticTiles[(int)i] = this.spawnTile(x, -y, botTile, staticObjects.transform, sortingOrderStatic);
                        else
                            staticTiles[(int)i] = this.spawnTile(x, -y, midTiles[0], staticObjects.transform, sortingOrderStatic);
                    }
                }
                else
                {
                    if (staticTiles[(int)i] != null)
                    {
                        Destroy(staticTiles[(int)i]);
                        staticTiles[(int)i] = null;
                    }
                }
            }

            if(leverState && movingObjects.transform.localPosition.x >= endPosition.x)
            {
                moving = false;
                destroyMoving();
            }
            else if(!leverState && movingObjects.transform.localPosition.x <= startPosition.x)
            {
                moving = false;
                destroyMoving();
            }
        }
    }

    void OnDrawGizmos()
    {
        if(drawGizmos)
        {
            Gizmos.DrawCube(new Vector3(transform.position.x + 3.5f + (width / 2) + (width % 2) / 2, transform.position.y - 1.5f), new Vector3(width + 1, 3f));
        }    
    }
}
