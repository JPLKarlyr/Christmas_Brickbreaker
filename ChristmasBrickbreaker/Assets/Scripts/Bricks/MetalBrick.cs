using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBrick : BaseBrick
{
    protected override void Start()
    {
        health = -1;
        base.Start();
    }

    public void Init(Color unbreakableColor)
    {
        _sr.color = unbreakableColor;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Play cling sound.
    }

    protected override void RefreshColor()
    {
        // Stay gray.
    }
}
