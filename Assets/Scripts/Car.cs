using UnityEngine;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    public CarType carType;

    [SerializeField] float acceleration;
    [SerializeField] float velocity;

    private Rigidbody2D carBody;
    private PlayPause playPauseManager;

    private void Start()
    {
        carBody = GetComponent<Rigidbody2D>();
        playPauseManager = PlayPause.instance;
    }

    private void FixedUpdate()
    {
        if (playPauseManager.currentPlayState == PlayState.PLAY)
        {
            velocity += acceleration * Time.fixedDeltaTime;

            carBody.velocity = Vector2.up * velocity;
        }
        else
        {
            carBody.velocity = Vector2.zero;
        }
    }
}
