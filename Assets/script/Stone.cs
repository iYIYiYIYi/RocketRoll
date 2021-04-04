using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public bool hitOverScreen = false;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("StoneTrigger"))
        {
            hitOverScreen = true;
        }
    }
}
