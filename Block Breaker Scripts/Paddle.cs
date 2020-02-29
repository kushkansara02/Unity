using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float unityWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Update is called once per frame
    void Update()
    {
        float unityMousePos = Input.mousePosition.x / Screen.width * unityWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(unityMousePos, minX, maxX);
        transform.position = paddlePos;
    }
}
