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

    
    public Player[] players;
    public Player currentPlayer;
    //public string recentWinner;

    void Awake() {
        //controller = GetComponent<RoomNavigation>().GetComponent
        controller = GetComponent<GameController>();
    }

   

    // public void setWinner(string s)
    // {
    //     recentWinner = s;
    // }

    // public string getWinner()
    // {
    //     string temp = recentWinner;
    //     recentWinner = null;
    //     return temp;
    // }

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

    public void InitiatePlayers()
    {
        // GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        // players = g.players;

        //get "players" from ui player unput script
        foreach (Player player in players)
        {
            
            player.roomsCleared = 0; 
            player.nodesCleared = 0;
            playerLocations.Add(player, InitialRoom);
            playerNodes.Add(player,InitialRoom.root);
            player.currentNode = InitialRoom.root;
        }

    }

    
    public Room nextRoom() {
        int lowest = 100;
        Room r = null;
        foreach(Player p in players) {
            if(p.roomsCleared <= lowest)
            lowest = p.roomsCleared;
            r = p.room;
        }
        return r;
    }





    public Player nextPlayer() {
        int lowest = 100;
        Player player = null;
        foreach(Player p in PlayersInRoom()) {
            if(p.nodesCleared <= lowest){
                lowest = p.nodesCleared;
                player = p;
            }
        }
        return player;
    }
    

}
