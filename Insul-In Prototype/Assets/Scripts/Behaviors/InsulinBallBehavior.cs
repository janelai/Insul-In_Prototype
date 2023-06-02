using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinBallBehavior : MonoBehaviour
{
    [SerializeField] float speedForce = 5f;
    private Rigidbody2D ball;
    private Vector2 previousVelocity;
    private float continuousSpeed;

    private void Awake()
    {
        ball = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = ball.transform.up * speedForce;
        this.ball.AddForce(force, ForceMode2D.Impulse);
        continuousSpeed = ball.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        // If the ball's speed changed, set the speed back to its original speed
        if (ball.velocity.magnitude != continuousSpeed)
        {
            ball.velocity = ball.velocity.normalized * continuousSpeed;
        }

        previousVelocity = ball.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball.velocity = Vector2.Reflect(previousVelocity, collision.GetContact(0).normal);
    }
}
