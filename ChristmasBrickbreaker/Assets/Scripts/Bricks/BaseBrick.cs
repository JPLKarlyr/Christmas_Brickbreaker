using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBrick : MonoBehaviour
{
    [SerializeField]
    public int health = 1;

    [SerializeField]
    protected SpriteRenderer _sr;

    // Level Info
    protected Color _startColor;
    protected Color _endColor;
    protected int _maxHealthOfBrick;

    protected virtual void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }


    protected abstract void RefreshColor();
}
