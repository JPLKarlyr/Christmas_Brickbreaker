using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireshot : PowerUp
{
    [SerializeField]
    private int _fireshotCharges;

    protected override void Collect(Paddle paddle)
    {
        paddle.CollectedFireshot(_fireshotCharges);
        Destroy(gameObject);
    }
}
