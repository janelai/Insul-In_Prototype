using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InsulinBallShooter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public GameObject insulinBall;
    [SerializeField] public Vector3 shootingPosition; 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Insulin ball shot");
        GameObject newInsulinBall = Instantiate(insulinBall, shootingPosition, Quaternion.identity);
    }

    public void OnPointerUp(PointerEventData data)
    {
    }
}
