using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBrick : BaseBrick
{
    // Start is called before the first frame update


    public void Init(Color startColor, Color endColor, int maxHealth)
    {
        _startColor = startColor;
        _endColor = endColor;
        _maxHealthOfBrick = maxHealth;
        RefreshColor();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            OnCollision(ball);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            OnCollision(ball);
        }
    }

    protected void OnCollision(Ball ball)
    {
        health--;
        if (health <= 0)
        {
            OnDestruction();
        }
        else
        {
            RefreshColor();
        }
    }

    protected virtual void OnDestruction()
    {
        Destroy(gameObject);
    }

    protected override void RefreshColor()
    {
        {
            var newColor = Color.Lerp(_startColor, _endColor, (float)health / _maxHealthOfBrick);
            _sr.color = newColor;
        }
    }
}
