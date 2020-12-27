using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable/Choice")]
public class Choice : Interactable
{

    public Option[] options;
    //introductory text, e.g "you see  a light in the distance, what do you do"
    public string text;
}

[System.Serializable]
public struct Option {
    public string text;
    public ScriptableObject ItemRequirement;
    public Interactable outcome;
}
