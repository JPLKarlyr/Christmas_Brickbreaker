using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            // TODO: Remove a life.
            // TODO: Reset the ball tied to the paddle.
            ball.ResetPosition();
            return;
        }

        var collectible = collision.GetComponent<Collectible>();

        Debug.Log("Collided");
    }
}
