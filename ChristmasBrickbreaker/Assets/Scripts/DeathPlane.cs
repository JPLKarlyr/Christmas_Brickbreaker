using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private GameManager _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            // TODO: Remove a life.
            // TODO: Probably just take the same ball.
            _gm.SpawnNewBall();
            Destroy(ball.gameObject);
            return;
        }

        var collectible = collision.GetComponent<Collectible>();

        Debug.Log("Collided");
    }
}
