using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsulinBallBehavior : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    private Rigidbody2D ball;

    private void Awake()
    {
        ball = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.ball.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
