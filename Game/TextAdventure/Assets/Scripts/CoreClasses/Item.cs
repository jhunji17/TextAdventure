using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject {

    [SerializeField]
    public string name {get; ,set; }
    public Sprite image;
    public bool used;
}