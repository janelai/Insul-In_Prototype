using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    // not using Start since we're working with input
    [SerializeField] public float paddle_speed;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject pivot_point;

    // Update is called once per frame
    void Update()
    {
        // check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //Debug.Log(touchPosition);
            // touch.position  in screen coordinates, measured in pixels. Have to convert from screen to world space
            touchPosition.z = 0;

            if (touchPosition.x > camera.transform.position.x)
            {
                // right side of the screen is being touched

                // transform.position += new Vector3(paddle_speed, 0, 0);

                // for rotation instead of left and right movement
                transform.RotateAround(pivot_point.transform.position, new Vector3(0, 0, 1), paddle_speed * Time.deltaTime);
            }
            else if (touchPosition.x <= camera.transform.position.x)
            {
                // left side of the screen is being touched
                
                // transform.position -= new Vector3(paddle_speed, 0, 0);

                transform.RotateAround(pivot_point.transform.position, new Vector3(0, 0, 1), -paddle_speed * Time.deltaTime);
            }

            // transform.position = touchPosition; if you want it to go where the screen is touched

            // touch.phase can be Began, Ended, Moved, Stationary, or Canceled (by the device)
        }
        
    }
}
