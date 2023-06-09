using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueList;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject doneButton;
    

    // When dialogue box is enabled:
    private void OnEnable()
    {
        TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            DialogueManager.Instance.StartDialogue(text, dialogueList, nextButton, doneButton);
            doneButton.SetActive(false);
        }
    }

    public void ContinueDialogue()
    {
        nextButton.SetActive(false);
        DialogueManager.Instance.DisplayNextSentence();
    }
}
