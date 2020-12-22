using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//the rooms of the game, pretty self explanatory

[CreateAssetMenu(menuName = "DeepState/Room")]
public class Room : ScriptableObject {

    [SerializeField]
    public Interactable root;
    

    [TextArea]
    public string description;
    public string name;
    public int number;
    public Sprite background;

    public void displaydescription() 
    {
        
        Debug.Log(number);
        Debug.Log(description);
    }
}

