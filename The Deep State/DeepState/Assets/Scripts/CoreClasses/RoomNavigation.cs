using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

public class RoomNavigation : MonoBehaviour

//navigates on a macro scale, keeps track of which room all the players are in, and which room the game controller should be focusing on currently. 
{

    public Room currentRoom;
    public Dictionary<Player,Room> playerLocations = new Dictionary<Player, Room>();
    public Dictionary<Player,Interactable> playerNodes = new Dictionary<Player, Interactable>();
    [SerializeField]
    public GameController controller;
    [SerializeField]
    public Room InitialRoom;

    public GameObject parent;
    public Player[] players;
    public int currentPlayer = 0;
    public string recentWinner;

    void Awake() {
        //controller = GetComponent<RoomNavigation>().GetComponent
        controller = GetComponent<GameController>();
    }

   

    public void setWinner(string s)
    {
        recentWinner = s;
    }

    public string getWinner()
    {
        string temp = recentWinner;
        recentWinner = null;
        return temp;
    }
    public List<Player> PlayersInRoom()
    {
        List<Player> playersInR = new List<Player>();
        foreach (KeyValuePair<Player, Room> i in playerLocations)
        { 
            if(i.Value == currentRoom)
            {
                playersInR.Add(i.Key);
            }
        }
        return playersInR ;
    }

    public void InitiatePlayers(Interactable node)
    {
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        players = g.players;
        foreach (Player i in players)
        {
            
            i.roomsCleared = 0;
            i.nodesCleared = 0;
            playerLocations.Add(i, InitialRoom);
            playerNodes.Add(i, node);
            i.currentNode = node;
        }

    }

    
    public Room nextRoom() {
        int lowest = 100;
        foreach(Player p in players) {
            lowest = Math.Min(lowest, p.roomsCleared);
        }
        foreach(Player p in players) {
            if (p.roomsCleared == lowest) {
                currentRoom = playerLocations[p];
                return currentRoom;
            }
        }
        return null;
    }





    public Player nextPlayer() {
        int lowest = 100;
        foreach(Player p in PlayersInRoom()) {
            lowest = Math.Min(lowest, p.nodesCleared);
        }
        foreach(Player p in PlayersInRoom()) {
            if (p.nodesCleared == lowest) {
                return p;
            }
        }
        return null;
    }
    

}
