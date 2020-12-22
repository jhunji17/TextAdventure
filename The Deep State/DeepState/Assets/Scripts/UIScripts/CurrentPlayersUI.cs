using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayersUI : MonoBehaviour
{
    Text currentPlayers;
    public GameController gameController;
    public RoomNavigation roomNavigation;

    Player[] players;
    void Start()
    {
        currentPlayers = GetComponent<Text>();
    }
    void Update()
    {
        
        currentPlayers.text = "Current Players:" + "\n";
        foreach (Player p in roomNavigation.players) {
            if (p.currentNode == gameController.currentNode) {
                
                currentPlayers.text += "\t" + p.name + "\n";
            }
            
        }
    }
    
}
