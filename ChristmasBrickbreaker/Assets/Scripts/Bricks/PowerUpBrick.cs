using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBrick : BreakableBrick
{
    [SerializeField]
    private GameObject _prefabPowerup;

    protected override void RefreshColor()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDestruction()
    {
        // TODO: Drop a powerup.
        Instantiate(_prefabPowerup, transform.position, Quaternion.identity, transform.parent);
        base.OnDestruction();
    }
}
