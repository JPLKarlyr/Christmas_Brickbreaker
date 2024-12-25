using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : PowerUp
{
    [SerializeField]
    private GameObject _ballPrefab;

    protected override void Collect(Paddle paddle)
    {
        paddle.SpawnNewBall();
        Destroy(gameObject);
    }
}
