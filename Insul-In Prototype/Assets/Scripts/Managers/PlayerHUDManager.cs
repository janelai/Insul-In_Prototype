using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHUDManager : MonoBehaviour
{
    public InsulinGameManager InsulinGameManager;
    // Necessary for game loop:
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject loseImage;
    [SerializeField] private TMP_Text endMenuBloodVal;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private BloodSugarLevel bloodSugarLevel;
    [SerializeField] private float GameTimer = 5f; // Game Lasts 30 Seconds
    //[SerializeField] private bool inTutorial;

    // Fun fact or dialogue components below:
    [SerializeField] private GameObject funFactCanvas;
    [SerializeField] private GameObject tutorialCanvas;
        
    private float ElapsedTime;

    public bool CanStart;

    // just testing if this works :)
    private void Awake()
    {
        //TriggerTutorial();
        ElapsedTime = GameTimer;
        InitializeTime(ElapsedTime);
    }

    private void FixedUpdate()
    {
        if (CanStart)
        {
            if (ElapsedTime > 0f)   // if timer reaches 0
            {
                ElapsedTime -= Time.deltaTime;
                InitializeTime(ElapsedTime);
            }
            else
            {
                ElapsedTime = 0;
                if (!endMenu.activeSelf) //if not already active -> call EndGame :)
                {
                    EndGame();
                }
            }
        }
    }

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

    public void TriggerFunFact()
    {
        if (!funFactCanvas.activeSelf)      // if fun fact canvas is not active
        {
            pauseMenu.SetActive(false);
            funFactCanvas.SetActive(true);
        }
        else                                // if fun fact is active, turn it off
        {
            pauseMenu.SetActive(true);
            funFactCanvas.SetActive(false);
        }
    }

    public void TriggerTutorial()
    {
        //inTutorial = true;
        InsulinGameManager.Instance.Pause();

        tutorialCanvas.SetActive(true);

    }

    public void EndGame()
    {
        Debug.Log("EndGame Called!");
        InsulinGameManager.Instance.GameOver();
        if (InsulinGameManager.Instance.currentState == InsulinGameManager.GAMESTATE.GAMEOVER)
        {
            endMenu.SetActive(true);
            if (bloodSugarLevel.HealthyBloodLevel())
            {
                // blood sugar level is healthy!
                winImage.SetActive(true);
                loseImage.SetActive(false);
            }
            else
            {
                // blood sugar level is not healthy
                winImage.SetActive(false);
                loseImage.SetActive(true);
            }
            endMenuBloodVal.text = bloodSugarLevel.BSL.ToString();
        }
    }

    // Convert seconds into time format:
    private void InitializeTime(float timer)
    {
        if (timer >= 0)
        {
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
