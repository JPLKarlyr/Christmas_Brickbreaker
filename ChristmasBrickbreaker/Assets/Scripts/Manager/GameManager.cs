using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Scene _scene;

    [SerializeField]
    private Paddle _paddle;



    // Start is called before the first frame update
    private void Start()
    {
        _paddle = FindObjectOfType<Paddle>();
    }

    public void SpawnNewBall()
    {
        _paddle.SpawnNewBall();
    }
}
