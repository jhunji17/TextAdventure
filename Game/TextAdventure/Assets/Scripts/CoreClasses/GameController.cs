using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//handles all the behaviour for the interactions withing one room, 
//is gonna unpack the tree of interactables, and will be responsible for displaying options

public class GameController : MonoBehaviour
{
    [SerializeField]
    public RoomNavigation roomNavigation;

    public Interactable currentNode;

    private bool awaitingUserInput = false;

    private bool temp = true;

    private List<Player> players { get; }



    void Awake()
    {
        Debug.Log("GameControllerAwake");
        roomNavigation = GameObject.FindGameObjectWithTag("RoomNavigator").GetComponent<RoomNavigation>();
    }

    /*should be changed to
    game start or sometinng this will 
    probably be one of the first methods to be called
    */
    public void OnCharactersCreated(List<Player> characters) 
    {
        Room MyRoom = roomNavigation.InitialRoom;
        List<Player> players = characters; 
        initialiseRoom(roomNavigation.InitialRoom);
        roomNavigation.InitiatePlayers();
    }

    public void initialiseRoom(Room room)
    {
        //roomDisplay.newRoom(room);
        roomNavigation.currentRoom = room;
        currentNode = room.root;
        //introShown = true;

        foreach (Player p in roomNavigation.PlayersInRoom())
        {
            p.currentNode = currentNode;
        }

    }

    //NEEDS REWORKING WITH JOSH MUCH CONFUSION
    //    void Update()
    //    {
    //        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) {
    //            if (introShown) {
    //                roomDisplay.hideIntro();
    //                introShown = false;
    //                newNode(currentNode);
    //            }
    //            else if (currentNode is Narration) {
    //                narrationAction((Narration) currentNode);
    //            }
    //            else if (currentNode is Event) {
    //                roomDisplay.hideDialogue();
    //                if (temp) {
    //                    foreach (Player p in roomNavigation.PlayersInRoom()) {
    //                        if (p.currentNode == currentNode) {
    //                            p.nodesCleared += 1;
    //                            p.currentNode = ((Event) currentNode).next;
    //                            break;
    //                        }
    //                    }  
    //                    bool again = false;
    //                    foreach (Player p in roomNavigation.PlayersInRoom()) {
    //                        if (p.currentNode == currentNode) {
    //                            again = true;
    //                            break;
    //                        }
    //                    }
    //                    if (again) {

    //                        eventAction((Event) currentNode);
    //                    }
    //                    else {
    //                        playerUI.HidePlayerUI();
    //                        newNode(roomNavigation.nextPlayer().currentNode);
    //                    } 
    //                } 
    //                else {
    //                    newNode(((Event) currentNode).next);
    //                }
    //            }      
    //        }
    //    }


    //    //needs to be merged with choice action
    //    public void decision(int i, Choice choice) {
    //        Choice c = (Choice) currentNode;
    //        roomDisplay.clearDecisions();
    //        if (temp) {
    //            foreach (Player p in roomNavigation.PlayersInRoom()) {
    //                if (p.currentNode == currentNode) {
    //                    p.nodesCleared += 1;
    //                    p.currentNode = c.options[i].outcome;
    //                    break;
    //                }
    //            }
    //            bool again = false;
    //            foreach (Player p in roomNavigation.PlayersInRoom()) {
    //                if (p.currentNode == currentNode) {
    //                    again = true;
    //                    break;
    //                }
    //            }
    //            if (again) {

    //                choiceAction((Choice) currentNode);
    //            }
    //            else {
    //                playerUI.HidePlayerUI();
    //                newNode(roomNavigation.nextPlayer().currentNode);
    //            }

    //        }
    //        else {
    //            newNode(c.options[i].outcome);
    //        }
    //    }
    //    private void narrationAction(Narration n) {
    //        if (roomDisplay.completeText()) {

    //            if (currentPage == n.pages.Length) {
    //                roomDisplay.hideDialogue();
    //                if (temp) {
    //                    foreach (Player p in roomNavigation.PlayersInRoom()) {
    //                        if (p.currentNode == currentNode) {
    //                            p.nodesCleared += 1;
    //                            p.currentNode = n.next;
    //                        }
    //                    }
    //                }
    //                newNode(n.next);
    //            }
    //            else {

    //                roomDisplay.changeDialogue(n.pages[currentPage].text);
    //                currentPage += 1;

    //            }
    //        }
    //    }




    //    //PRETTY SURE THIS IS ALL UI SHIT
    //    // private void choiceAction(Choice c) {
    //    //     //UI ch
    //    //     if (temp) {
    //    //         foreach (Player p in roomNavigation.PlayersInRoom()) {
    //    //             if (p.currentNode == currentNode) {
    //    //                 playerUI.LoadPlayerUI(p);
    //    //                 break;
    //    //             }
    //    //         }
    //    //     }
    //    //     roomDisplay.decisions(c);
    //    // }



    //    private void chanceAction(Chance c) {
    //        System.Random rd = new System.Random();
    //        double rand = rd.NextDouble();
    //        double cumulative = 0.0;

    //        Path result = new Path();
    //        foreach (Path p in c.paths) {
    //            cumulative += p.chance;
    //            if (rand< cumulative) {
    //                result = p;
    //                break;
    //            }
    //        }
    //        newNode(result.outcome);
    //    }


    //    //cuurent node is the exit 
    //    //finished??
    //    private void exitAction(ExitCorridor exit) {
    //        // if (temp) {
    //        foreach(Player p in roomNavigation.PlayersInRoom()) {
    //            if (p.currentNode == currentNode) {
    //                roomNavigation.playerLocations[p] = exit.nextRoom;
    //                p.roomsCleared += 1;
    //                p.nodesCleared = 0;
    //                p.room = exit.nextRoom;
    //            }
    //        }
    //        if (roomNavigation.PlayersInRoom().Count > 0) {
    //            newNode(roomNavigation.nextPlayer().currentNode);
    //        }
    //        else {
    //            Room next = roomNavigation.nextRoom();
    //            initialiseRoom(next);
    //        }
    //        // }
    //        // else {
    //        //     initialiseRoom(exit.nextRoom);
    //        // }

    //    }

    //    private void healthDamageAction(HealthDamage node){

    //    }

    //    private void itemGainLossAction(ItemGainLoss node){

    //    }

    //    private void rewardPunishmentAction(RewardPunishment node){

    //    }


    //    //finished?
    //    public void newNode(Interactable node) {
    //        currentNode = node;


    //        //choice needs a user input, 
    //        if (node is Choice) {
    //            choiceAction((Choice) node);
    //        }

    //        else if (node is HealthDamage){
    //            healthDamageAction((HealthDamage) node);
    //        }

    //        else if (node is Narration) {
    //            //UI shit
    //            narrationAction((Narration) node);
    //        }

    //        else if (node is Chance) {
    //            chanceAction((Chance) node);
    //        }

    //        else if (node is ExitCorridor) {
    //            exitAction((ExitCorridor) node);

    //        } else if (node is ItemGainLoss) {
    //            itemGainLossAction((ItemGainLoss) node);
    //        }

    //        else if (node is RewardPunishment) {
    //            rewardPunishmentAction((RewardPunishment) node);
    //        }

    //        else{
    //            Debug.Log("it should never get here!!!!!!   :( ");
    //        }

    //    }


}
