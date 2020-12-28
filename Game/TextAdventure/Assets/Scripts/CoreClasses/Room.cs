using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject {

    [SerializeField]
    public Interactable root;
    

    [TextArea]
    private string description;
    private int number;
    public Sprite background;
    private bool cleared = false;
}

