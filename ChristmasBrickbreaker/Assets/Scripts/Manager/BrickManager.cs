using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField]
    private Transform BricksHandler;

    [SerializeField]
    private Color _startColor;

    [SerializeField]
    private Color _endColor;

    [SerializeField]
    private Color _unbreakableColor;

    private int _maxHealth;

    private void Start()
    {
        var bricks = FindObjectsOfType<BaseBrick>();
        _maxHealth = FetchHighestHealth(bricks);
        foreach (var brick in bricks)
        {
            if (brick is MetalBrick metalBrick)
            {
                metalBrick.Init(_unbreakableColor);
            }
            else if (brick is BreakableBrick breakBrick)
            {
                breakBrick.Init(_startColor, _endColor, _maxHealth);
            }
        }
    }

    private int FetchHighestHealth(BaseBrick[] bricks)
    {
        var maxHealth = 0;
        foreach (var brick in bricks)
        {
            if (maxHealth < brick.health)
            {
                maxHealth = brick.health;
            }
        }
        return maxHealth;
    }
    
    public void LevelInitialization(int maxHealth)
    {
        _maxHealth = maxHealth;
        PlaceBricks();
    }
    
    private void PlaceBricks()
    {

    }
}
