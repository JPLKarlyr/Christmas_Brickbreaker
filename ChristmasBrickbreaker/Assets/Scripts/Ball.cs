using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 momentum { get { return _rb.velocity; } }

    [SerializeField]
    private Vector2 _initialvelocity;

    [SerializeField]
    private float _minimumVerticalVelocity;

    private Rigidbody2D _rb;
    private Vector3 _initialPosition;
    private bool _isLaunched = false;
    

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // _rb.velocity = _initialvelocity;
        // _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_isLaunched)
        {
            if (Math.Abs(_rb.velocity.y) < _minimumVerticalVelocity)
            {
                var sign = Math.Sign(_rb.velocity.y);
                _rb.velocity = new Vector2(_rb.velocity.x * sign, _minimumVerticalVelocity);
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = _initialPosition;
        _rb.velocity = _initialvelocity;
    }

    public void Launch()
    {
        _isLaunched = true;
        _rb.velocity = _initialvelocity;
    }
}
