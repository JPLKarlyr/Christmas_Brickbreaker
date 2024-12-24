using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Update is called once per frame
    public void UpdatePaddlePosition(Vector3 mousePosition)
    {
        Debug.Log(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    }
}
