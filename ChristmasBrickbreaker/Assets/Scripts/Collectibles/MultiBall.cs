using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : PowerUp
{
    [SerializeField]
    private GameObject _ballPrefab;

    protected override void Collect()
    {
        // Instantiate ball at emplacement
        var newBall = Instantiate(_ballPrefab, transform.position, Quaternion.identity ,transform.parent);

        Destroy(gameObject);
    }
}
