using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveByTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // not using Start since we're working with input
    [SerializeField] public float paddle_speed;
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject paddle;
    [SerializeField] public GameObject pivot_point;

    [SerializeField] public bool left;
    [SerializeField] public bool right;

    private bool isPressed;

    // Update is called once per frame
    void Update()
    {
        /*
        // check for touch input
        if (Input.touchCount > 5)
        {
            Touch touch = Input.GetTouch(0); // the first touch
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log(touchPosition);
            // touch.position  in screen coordinates, measured in pixels. Have to convert from screen to world space
            touchPosition.z = 0f;
            if (touchPosition.x > camera.transform.position.x)
            {
                // right side of the screen (relative to the camera) is being touched
            }
            else if (touchPosition.x <= camera.transform.position.x)
            {
                // left side of the screen (relative to the camera) is being touched
            }
            // transform.position = touchPosition; if you want it to go where the screen is touched
            // touch.phase can be Began, Ended, Moved, Stationary, or Canceled (by the device)
        }
        */

        if (isPressed)
        {
            if (right)
            {
            // transform.position += new Vector3(paddle_speed, 0, 0);

            // for rotation instead of left and right movement
            paddle.transform.RotateAround(pivot_point.transform.position, Vector3.forward, paddle_speed * Time.deltaTime);

            camera.transform.RotateAround(pivot_point.transform.position, Vector3.forward, paddle_speed * Time.deltaTime);
            }
            else if (left)
            {
            // transform.position -= new Vector3(paddle_speed, 0, 0);

            paddle.transform.RotateAround(pivot_point.transform.position, Vector3.forward, -paddle_speed * Time.deltaTime);

            camera.transform.RotateAround(pivot_point.transform.position, Vector3.forward, -paddle_speed * Time.deltaTime);
            }
        }
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
