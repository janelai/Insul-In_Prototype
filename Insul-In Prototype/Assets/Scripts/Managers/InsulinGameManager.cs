using UnityEngine;

public class InsulinGameManager : MonoBehaviour
{
    //GameManager is a singleton
    public static InsulinGameManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame()
    {
        //Load the game scene
        GameSceneManager.Instance.LoadScene(GameSceneManager.Scenes.INSULINBALLTEST);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting!");
    }
}
