using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        var paddle = collision.GetComponent<Paddle>();
        if (paddle != null)
        {
            Collect(paddle);
        }
    }

    protected abstract void Collect(Paddle paddle);
}
