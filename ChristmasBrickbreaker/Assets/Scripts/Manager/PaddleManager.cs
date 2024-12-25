using System.Collections;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private Paddle _paddle;

    private void Update()
    {
        _paddle.UpdatePaddlePosition(MousePositionInScene());
    }

    public Vector3 MousePositionInScene()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
