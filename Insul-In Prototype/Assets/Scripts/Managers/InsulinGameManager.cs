using UnityEngine;

public class InsulinGameManager : MonoBehaviour
{
    public enum GAMESTATE
    {
        STARTMENU,
        PAUSED,
        PLAYING,
        GAMEOVER
    }

    public GAMESTATE currentState
    {
        get;
        private set;
    }

    //GameManager is a singleton and handles the state of the game
    public static InsulinGameManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Im awake");
            currentState = GAMESTATE.STARTMENU;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        currentState = GAMESTATE.PLAYING;
        GameSceneManager.Instance.StartGame();
    }

    public void ReturnToStartMenu()
    {
        currentState = GAMESTATE.STARTMENU;
        GameSceneManager.Instance.ReturnToStartMenu();
    }

    public void Pause()
    {
        if (currentState == GAMESTATE.PLAYING)  // If playing, pause game
        {
            currentState = GAMESTATE.PAUSED;
            Time.timeScale = 0;
            Debug.Log("Pause game");
        }
        else if (currentState == GAMESTATE.PAUSED) // If game is already paused, unpause game
        {
            currentState = GAMESTATE.PLAYING;
            Time.timeScale = 1;
            Debug.Log("Unpause game");
        }
    }
}
