using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DeepState/Interactable/Choice")]
public class Choice : Interactable
{

    public Option[] options;

}

[System.Serializable]
public struct Option {
    public string text;
    public string ItemRequirement;
    public Interactable outcome;
}
