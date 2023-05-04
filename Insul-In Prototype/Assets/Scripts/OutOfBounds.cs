using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Something left the out of bounds");
        if(other.tag == "Insulin")
        {
            Debug.Log("It was the insulin!");
            Destroy(other);
        }
    }
}
