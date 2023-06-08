using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;

    public void PauseGame()
    {
        //try to deactive the component, not the parent
        InsulinGameManager.Instance.Pause();
        if (InsulinGameManager.Instance.currentState == InsulinGameManager.GAMESTATE.PAUSED)
        {
            // Activate pause menu:
            pauseMenu.SetActive(true);
        }
        else if (InsulinGameManager.Instance.currentState == InsulinGameManager.GAMESTATE.PLAYING)
        {
            // Deactivate pause menu:
            pauseMenu.SetActive(false);
        }

    }
}
