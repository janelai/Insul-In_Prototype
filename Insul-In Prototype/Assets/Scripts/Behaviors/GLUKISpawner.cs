using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLUKISpawner : MonoBehaviour
{
    public GameObject GLUKI_pivot_point;
    public GameObject GLUKI;
    
    private float spawn_timer = 2f;
    public float spawn_time = 2f;
    public float spawn_rate = 0.75f;

    void Start()
    {
        GLUKI.GetComponent<GLUKIBehavior>().pivot_point = GLUKI_pivot_point;
        SpawnGLUKI();
    }

    // Update is called once per frame
    void Update()
    {
        // every spawn_time seconds there is a spawn_rate chance of spawning a GLUKI
        if (spawn_timer > 0f)
        {
            spawn_timer -= Time.deltaTime;
        }
        else
        {
            spawn_timer = spawn_time;
            if (Random.Range(0f, 1f) <= spawn_rate)
            {
                SpawnGLUKI();
            }
        }
    }

    void SpawnGLUKI()
    {

        Vector3 spawn_point = GetSpawnPoint(GetComponent<BoxCollider2D>().bounds);
        
        GameObject newGLUKI = Instantiate(GLUKI, spawn_point, Quaternion.identity);
    }

    public Vector3 GetSpawnPoint(Bounds bounds)
    {
        float minX = bounds.size.x * -0.5f;
        float minY = bounds.size.y * -0.5f;

        return (Vector3)transform.TransformPoint(
            new Vector3(
                Random.Range(minX, -minX), Random.Range(minY, -minY), 0f)
                );
    }
}
