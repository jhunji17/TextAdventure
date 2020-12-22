using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//and interactable representing simple descision choices, or respnses to dialogue, need to flesh this class out to

[CreateAssetMenu(menuName = "DeepState/Interactable/Choice")]
public class Choice : Interactable
{

    public Options[] options;
    public int number;

}
[System.Serializable]
public struct Options {
    public string text;
    public Interactable outcome;
}
