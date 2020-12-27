using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "TextAdventure/Interactable/Exit")]
public class ExitCorridor : Interactable
{

    public Room nextRoom;
}
