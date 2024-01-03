using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private GameObject playerHudCanvas;
    [SerializeField] private GameObject bslLabel;
    [SerializeField] private GameObject bslNumber;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject bloodSugarLevel;

    [SerializeField] private Dialogue dialogueList;
    [SerializeField] private GameObject textObject;

    private DialogueWindow dialogueWindow;

    public int tutorialStep;

    // Start is called before the first frame update
    void Start()
    {
        dialogueWindow = textObject.GetComponent<DialogueWindow>();
        playerHudCanvas = GameObject.Find("PlayerHUDCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLines();
        Debug.Log(tutorialStep);
    }

    void CheckLines()
    {
        tutorialStep = dialogueWindow.step;
        if (tutorialStep == 4)
        {
            playerHudCanvas.GetComponent<Canvas>().sortingOrder = 1;
            bslLabel.SetActive(true);
            bslNumber.SetActive(true);
        }
        if (tutorialStep == 6)
        {
            bloodSugarLevel.SetActive(true);
        }
        if (tutorialStep == 7)
        {
            timer.SetActive(true);
        }
    }
}
