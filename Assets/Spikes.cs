﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    float timer;
    float y;
    bool grow;
    bool shrink;

    private void Start()
    {
        grow = false;
        shrink = true;
    }

    private void FixedUpdate()
    {
        if(timer < 0)
        {
            grow = true;
            shrink = false;
        }

        if (timer > 2)
        {
            grow = false;
            shrink = true;
        }

        if (grow)
        {
            timer += Time.deltaTime;
        }

        if(shrink)
        {
            timer -= Time.deltaTime;
        }
        y = timer;
        transform.localScale = new Vector3(1, y, 1);
    }

}