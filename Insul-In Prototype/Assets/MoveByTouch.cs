using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    // not using Start since we're working with input

    // Update is called once per frame
    void Update()
    {
        // check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            // touch.position  in screen coordinates, measured in pixels. Have to convert from screen to world space
            touchPosition.z = 0;

            if (touchPosition.x >= 0)
            {
                // right side of the screen is being touched
                transform.position += new Vector3(0.05f, 0, 0);
            }
            else if (touchPosition.x < 0)
            {
                // left side of the screen is being touched
                transform.position -= new Vector3(0.05f, 0, 0);
            }

            // transform.position = touchPosition; if you want it to go where the screen is touched

            // touch.phase can be Began, Ended, Moved, Stationary, or Canceled (by the device)
        }
        
    }
}
