using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;

    public float GameTimer = 5f; // Game Lasts 30 Seconds
    public float ElapsedTime;

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

    public void EndGame()
    {
        Debug.Log("EndGame Called!");
        InsulinGameManager.Instance.GameOver();
        if (InsulinGameManager.Instance.currentState == InsulinGameManager.GAMESTATE.GAMEOVER)
        {
            endMenu.SetActive(true);
        }
    }


    // just testing if this works :)
    private void Awake()
    {
        ElapsedTime = GameTimer;
    }

    private void Update()
    {
        if (ElapsedTime > 0f)
        {
            ElapsedTime -= Time.deltaTime;
        }
        else
        {
            if (!endMenu.activeSelf) //if not already active -> call EndGame :)
            {
                EndGame();
            }
        }
    }

}
