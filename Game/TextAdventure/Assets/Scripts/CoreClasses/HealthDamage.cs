using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DeepState/Interactable/HealthDamage")]
public class HealthDamage : Interactable{

    [TextArea(1, 30)]
    public string text;
    public int health;
    public bool gain;

}