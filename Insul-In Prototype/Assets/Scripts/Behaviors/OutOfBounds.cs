using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // If insulin collides barrier, destroy!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Insulin")
        {
            Debug.Log("It was the insulin!");
            Destroy(collision.gameObject);
        }
    }
}