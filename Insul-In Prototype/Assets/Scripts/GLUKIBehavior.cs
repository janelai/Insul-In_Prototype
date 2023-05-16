using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLUKIBehavior : MonoBehaviour
{
    public GameObject pivot_point;
    private Vector3 cell_direction;
    public float initial_speed = 3f;
    private Rigidbody2D GLUKI;

    private void Awake()
    {
        GLUKI = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // shoot self toward center of cell
        SetSpawnAngle();
        Vector2 shoot_dir;
        shoot_dir.x = cell_direction.x;
        shoot_dir.y = cell_direction.y;
        this.GLUKI.AddForce(shoot_dir*initial_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpawnAngle()
    {
        cell_direction = pivot_point.transform.position - transform.position;
        cell_direction = cell_direction.normalized;
    }
}
