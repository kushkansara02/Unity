using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float initialXVel = 2f;
    [SerializeField] float initialYVel = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // state
    Vector2 paddleToBall;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(initialXVel, initialYVel);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 ballPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = ballPos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            myAudioSource.PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]);
        }
    }
}
