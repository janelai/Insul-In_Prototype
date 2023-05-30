using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private GameObject uiButton;
    private Queue<string> lines;

    // DialogueManager handles the dialogue by displaying
    // Inspired by: Brackeys' "How to make a Dialogue System in Unity"
    public static DialogueManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            lines = new Queue<string>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set up text box, dialogue, and button
    public void StartDialogue(TextMeshProUGUI textBox, Dialogue dialogue, GameObject button)
    {
        Debug.Log("Connected to Dialogue Manager");
        dialogueText = textBox;
        uiButton = button;
        lines.Clear();
        foreach (string line in dialogue.sentences)
        {
            lines.Enqueue(line);
        }
        // After accessing all sentences from dialogue object, display them:
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (lines != null && lines.Count == 0)
        {
            // End of Dialogue
            Debug.Log("End of Dialogue");
            return;
        }
        string displaySentence = lines.Dequeue();
        if (dialogueText != null)
        {
            dialogueText.text = displaySentence;
            uiButton.SetActive(true);
        }            
    }
}
