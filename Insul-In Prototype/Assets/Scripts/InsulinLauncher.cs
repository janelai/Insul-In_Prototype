using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InsulinBallShooter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public GameObject insulinBall;
    [SerializeField] public Transform launcher_pos; 

    private Quaternion launcher_pos_rotation;

    // Update is called once per frame
    void Update()
    {
        launcher_pos_rotation = launcher_pos.rotation;
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Insulin ball shot");
        GameObject newInsulinBall = Instantiate(insulinBall, launcher_pos.position, launcher_pos_rotation);
    }

    public void OnPointerUp(PointerEventData data)
    {
    }
}
