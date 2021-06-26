using UnityEngine;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float velocity;

    private Rigidbody2D carBody;

    private void Awake()
    {
        carBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        carBody.velocity = Vector2.up * velocity;
    }
}
