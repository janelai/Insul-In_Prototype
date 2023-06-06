using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLUKIBehavior : MonoBehaviour
{
    public GameObject pivot_point;
    private Vector3 cell_direction;
    public float initial_speed = 100f;
    private Rigidbody2D GLUKI;

    public float returnTimer = 2f;
    private float timer;

    private void Awake()
    {
        GLUKI = this.GetComponent<Rigidbody2D>();

        shootAtCell();

        timer = returnTimer;
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        // shoot self toward center of cell
        shootAtCell();

        timer = returnTimer;
    }*/

    // Update is called once per frame
    void Update()
    {
       if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            shootAtCell();
            timer = returnTimer;
        }
    }

    void shootAtCell()
    {
        SetSpawnAngle();
        Vector2 shoot_dir;
        shoot_dir.x = cell_direction.x;
        shoot_dir.y = cell_direction.y;
        this.GLUKI.AddForce(shoot_dir * initial_speed);
    }

    void SetSpawnAngle()
    {
        cell_direction = pivot_point.transform.position - transform.position;
        cell_direction = cell_direction.normalized;
    }
}
