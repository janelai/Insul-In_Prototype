using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    bool ballOut = false;
    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //this.gameObject.SetActive(false);
        if(collision.gameObject.tag == "Insulin")
        {
            Debug.Log("It was the insulin!");
            Destroy(collision.gameObject);
        }
        Debug.Log("Instakill enter");
    }

}