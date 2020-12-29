using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player : ScriptableObject
{
    [SerializeField]
    public static int Health = 3;

    
    private string Name {get;}
    private List<Item> items {get; set;}    
    private int roomsCleared {get; set;}
    private int nodesCleared {get; set;}
    private int health {get; set;}
    private bool isAlive {get; set;}
    
    
    public void Init(string name)
    {
       this.name = name;
       this.items = new List<Item>();
       this.roomsCleared = 0;
       this.nodesCleared = 0;
       this.health = Health;
       this.isAlive = true;

    }

    public static Player CreateInstance(string name)
    {
       var myPlayer = ScriptableObject.CreateInstance<Player>();
       myPlayer.Init(name);
       return myPlayer;
    }
    

    
    

    

}
