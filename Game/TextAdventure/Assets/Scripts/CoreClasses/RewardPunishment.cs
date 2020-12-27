using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "TextAdventure/Interactable/RewardPunishment")]
public class RewardPunishment : Interactable{

    [TextArea(1, 30)]
    public string text;

}