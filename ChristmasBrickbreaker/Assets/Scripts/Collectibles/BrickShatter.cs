using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickShatter : PowerUp
{
    [SerializeField]
    private int _shatterCharges;

    protected override void Collect(Paddle paddle)
    {
        paddle.CollectedShatter(_shatterCharges);
    }
}
