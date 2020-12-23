using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    string description;
    string identifier;
    

    public string getDescription()
    {
        return description;
    }


}
