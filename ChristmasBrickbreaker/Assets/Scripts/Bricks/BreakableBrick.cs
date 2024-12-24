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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                RefreshColor();
            }
        }
    }

    protected override void RefreshColor()
    {
        {
            var newColor = Color.Lerp(_startColor, _endColor, (float)health / _maxHealthOfBrick);
            _sr.color = newColor;
        }
    }
}
