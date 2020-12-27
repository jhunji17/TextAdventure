using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable/Narration")]
public class Narration : Interactable
{
    public Page[] pages;
    public Interactable next;
}

[System.Serializable]
public struct Page {
    [TextArea(1, 30)]
    public string text;
}
