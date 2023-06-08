using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InsulinBallShooter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public GameObject insulinBall;
    [SerializeField] public Transform launcher_pos;
    [SerializeField] public int insulin_ammo_amount = 4;

    [SerializeField] public Image[] insulin_ammo_display; // 0-3, top-bottom

    // Update is called once per frame
    void Update()
    {
        int ammo = insulin_ammo_amount;

        switch(ammo)
        {
            case 4:
                foreach(Image img in insulin_ammo_display)
                {
                    img.gameObject.SetActive(true);
                }
            break;

            case 3:
                insulin_ammo_display[3].gameObject.SetActive(false);
                insulin_ammo_display[2].gameObject.SetActive(true);
                insulin_ammo_display[1].gameObject.SetActive(true);
                insulin_ammo_display[0].gameObject.SetActive(true);
            break;

            case 2:
                insulin_ammo_display[3].gameObject.SetActive(false);
                insulin_ammo_display[2].gameObject.SetActive(false);
                insulin_ammo_display[1].gameObject.SetActive(true);
                insulin_ammo_display[0].gameObject.SetActive(true);
            break;

            case 1:
                insulin_ammo_display[3].gameObject.SetActive(false);
                insulin_ammo_display[2].gameObject.SetActive(false);
                insulin_ammo_display[1].gameObject.SetActive(false);
                insulin_ammo_display[0].gameObject.SetActive(true);
            break;

            case 0:
                foreach(Image img in insulin_ammo_display)
                {
                    img.gameObject.SetActive(false);
                }
                // No insulin ball ammo
            break;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (insulin_ammo_amount > 0)
        {
            Debug.Log("Insulin ball shot");
            GameObject newInsulinBall = Instantiate(insulinBall, launcher_pos.position, launcher_pos.rotation);

            insulin_ammo_amount -= 1;
        }
        else
        {
            Debug.Log("No insulin ball ammo");
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
    }
}
