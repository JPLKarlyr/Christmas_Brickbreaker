using System;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 momentum { get { return _rb.velocity; } }

    [SerializeField]
    private Vector2 _initialvelocity;

    [SerializeField]
    private float _minimumVerticalVelocity;

    [SerializeField]
    private LayerMask _brickLayer;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;
    private Vector3 _initialPosition;
    private bool _isLaunched = false;
    private bool _isFireshot = false;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();

        /* _brickLayer.value
        _circleCollider.forceReceiveLayers */

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

        if (Input.GetButtonDown("PowerUpDebug"))
        {

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

    public void EnableFireShot()
    {
        bool hasBit = (_circleCollider.forceReceiveLayers & _brickLayer) == _brickLayer;
        if (hasBit)
        {
            _circleCollider.forceReceiveLayers = _circleCollider.forceReceiveLayers ^ _brickLayer;
        }
    }

    public void EndFireshot()
    {
        _circleCollider.forceReceiveLayers = _circleCollider.forceReceiveLayers | _brickLayer;
    }
}
