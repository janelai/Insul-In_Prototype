using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    // Contains a list of dialogue to play
    [TextArea(3,6)]
    public string[] sentences;
}
