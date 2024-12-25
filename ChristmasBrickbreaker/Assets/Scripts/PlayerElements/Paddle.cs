using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballPrefab;

    [SerializeField]
    private Transform _ballHolder;

    [SerializeField]
    private List<Ball> _heldBalls;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_heldBalls.Count != 0)
            {
                var launchedBall = _heldBalls[0];
                _heldBalls.Remove(launchedBall);
                launchedBall.transform.parent = null;
                launchedBall.Launch();
            }
        }
    }

    public void UpdatePaddlePosition(Vector3 mousePosition)
    {
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    }

    public void SpawnNewBall()
    {
        var ballgo = Instantiate(_ballPrefab, _ballHolder.position, Quaternion.identity, _ballHolder);
        var ball = ballgo.GetComponent<Ball>();
        if (ball != null)
        {
            _heldBalls.Add(ball);
        }
        else
        {
            Debug.LogError("Wrong ball prefab in Paddle.");
        }
    }
}
