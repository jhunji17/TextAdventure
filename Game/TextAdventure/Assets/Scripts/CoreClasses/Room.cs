using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "DeepState/Room")]
public class Room : ScriptableObject {

    [SerializeField]
    public Interactable root {get;  set;}
    

    [TextArea]
    private string description;
    private int number;
    public Sprite background;
    private bool cleared = false;
}

