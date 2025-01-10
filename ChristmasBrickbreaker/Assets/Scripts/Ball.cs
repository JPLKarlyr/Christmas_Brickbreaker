using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField]
    private Collider2D _shatterCollider;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;
    private Vector3 _initialPosition;
    private bool _isLaunched = false;
    private bool _isFireshot = false;
    private bool _isShatter = false;

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
            _isShatter = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var angle = Math.Atan2(_rb.velocity.normalized.y, _rb.velocity.normalized.x);
        var degrees = 180 * angle / Math.PI;  //degrees
        _shatterCollider.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (float)degrees - 90));

        if (_isShatter)
        {
            var brick = collision.collider.GetComponent<BaseBrick>();
            if (brick != null)
            {
                ShatterBrick();
                _isShatter = false;
            }
        }
    }

    private void ShatterBrick()
    { 
        List<Collider2D> results = new List<Collider2D>();
        _shatterCollider.OverlapCollider(new ContactFilter2D(), results);

        foreach (var brick in results)
        {
            var breakBrick = brick.GetComponent<BreakableBrick>();
            if (breakBrick != null)
            {
                breakBrick.OnCollision();
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

    public void StartShatter()
    {
        _isShatter = true;
        Debug.Log("Shatter !");
    }
}
