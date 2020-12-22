using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DeepState/Interactable/Chance")]
public class Chance : Interactable
{
    public Path[] paths;
}

[System.Serializable]
public struct Path {
    public int chance;
    public Interactable outcome;
}
