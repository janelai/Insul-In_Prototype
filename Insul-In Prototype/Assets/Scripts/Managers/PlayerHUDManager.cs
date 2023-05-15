using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDManager : MonoBehaviour
{
    public void PauseGame()
    {
        InsulinGameManager.Instance.Pause();
    }
}
