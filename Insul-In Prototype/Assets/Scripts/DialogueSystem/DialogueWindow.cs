using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueList;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject uiButton;
    

    // When dialogue box is enabled:
    private void OnEnable()
    {
        TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
        if(text != null)
            DialogueManager.Instance.StartDialogue(text, dialogueList, uiButton);
    }

    public void ContinueDialogue()
    {
        uiButton.SetActive(false);
        DialogueManager.Instance.DisplayNextSentence();
    }
}
