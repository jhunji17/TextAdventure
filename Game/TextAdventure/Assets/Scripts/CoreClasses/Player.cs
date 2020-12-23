using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField]
    public string name { get; set; }
    [SerializeField]
    public List<Item> items { get; set; } = new List<Item>();
    [SerializeField]
    //public Room room { get; set}
    [SerializeField]
    public int roomsCleared { get; set; }
    public int nodesCleared {get; set;}
    [SerializeField]
    public int health { get; set; } = 3
    [SerializeField]
    public bool isAlive { get; set; }
    public Interactable currentNode;
    

    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
    

    public void damage(int x) 
    {
        health -= x;
        if (health <= 0)
        {
            isAlive = false;
        }
        
    }

}
