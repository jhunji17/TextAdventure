using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//an interactable that links two rooms, will probably be towards the bottom of the interactable tree

[System.Serializable]
[CreateAssetMenu(menuName = "DeepState/Interactable/Exit")]
public class ExitCorridor : Interactable
{
    //uniquely identifies each corridor
    public int keyString;
    //room number of where the exit was from
    public int from;
    //room number of where the exit is to.
    public Room nextRoom;
}
