using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrick : MonoBehaviour
{
    [SerializeField]
    public int health = 1;

    [SerializeField]
    private SpriteRenderer _sr;

    // Level Info
    private Color _startColor;
    private Color _endColor;
    private int _maxHealthOfBrick;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Init(Color startColor, Color endColor, int maxHealth)
    {
        _startColor = startColor;
        _endColor = endColor;
        _maxHealthOfBrick = maxHealth;
        RefreshColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void RefreshColor()
    {
        var newColor = Color.Lerp(_startColor, _endColor, (float)health / _maxHealthOfBrick);
        _sr.color = newColor;
    }
}
