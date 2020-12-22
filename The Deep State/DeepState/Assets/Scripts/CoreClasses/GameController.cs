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

    public RoomDisplay roomDisplay;
    public PlayerUI playerUI;

    public Interactable currentNode;
    private bool awaitingUserInput = false;
    private bool introShown = false;
    private int currentPage;

    private bool temp = true;
    
    

    void Awake() {
        
        
        
        
        
    }
    public void OnIntroEnd() {
        Room MyRoom = roomNavigation.InitialRoom;
        List<Player> players = roomNavigation.PlayersInRoom();
        initialiseRoom(MyRoom);
        if (temp) {
            roomNavigation.InitiatePlayers(currentNode);
        }
    }


    public void initialiseRoom(Room room)
    {
        roomDisplay.newRoom(room);
        roomNavigation.currentRoom = room;
        currentNode = room.root;
        introShown = true;
        if (temp) {
            foreach (Player p in roomNavigation.PlayersInRoom()) {
                
                p.currentNode = currentNode;
            }
        }
        
        
    }
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) {
            if (introShown) {
                roomDisplay.hideIntro();
                introShown = false;
                newNode(currentNode);
            }
            else if (currentNode is Narration) {
                narrationAction((Narration) currentNode);
            }
            else if (currentNode is Event) {
                roomDisplay.hideDialogue();
                if (temp) {
                    foreach (Player p in roomNavigation.PlayersInRoom()) {
                        if (p.currentNode == currentNode) {
                            p.nodesCleared += 1;
                            p.currentNode = ((Event) currentNode).next;
                            break;
                        }
                    }  
                    bool again = false;
                    foreach (Player p in roomNavigation.PlayersInRoom()) {
                        if (p.currentNode == currentNode) {
                            again = true;
                            break;
                        }
                    }
                    if (again) {
                
                        eventAction((Event) currentNode);
                    }
                    else {
                        playerUI.HidePlayerUI();
                        newNode(roomNavigation.nextPlayer().currentNode);
                    } 
                } 
                else {
                    newNode(((Event) currentNode).next);
                }
            }      
        }
    }
    public void decision(int i) {
        Choice c = (Choice) currentNode;
        roomDisplay.clearDecisions();
        if (temp) {
            foreach (Player p in roomNavigation.PlayersInRoom()) {
                if (p.currentNode == currentNode) {
                    p.nodesCleared += 1;
                    p.currentNode = c.options[i].outcome;
                    break;
                }
            }
            bool again = false;
            foreach (Player p in roomNavigation.PlayersInRoom()) {
                if (p.currentNode == currentNode) {
                    again = true;
                    break;
                }
            }
            if (again) {
                
                choiceAction((Choice) currentNode);
            }
            else {
                playerUI.HidePlayerUI();
                newNode(roomNavigation.nextPlayer().currentNode);
            }
            
        }
        else {
            newNode(c.options[i].outcome);
        }
    }
    private void narrationAction(Narration n) {
        if (roomDisplay.completeText()) {

            if (currentPage == n.pages.Length) {
                roomDisplay.hideDialogue();
                if (temp) {
                    foreach (Player p in roomNavigation.PlayersInRoom()) {
                        if (p.currentNode == currentNode) {
                            p.nodesCleared += 1;
                            p.currentNode = n.next;
                        }
                    }
                }
                newNode(n.next);
            }
            else {
                
                roomDisplay.changeDialogue(n.pages[currentPage].text);
                currentPage += 1;
                
            }
        }
    }
    private void choiceAction(Choice c) {
        roomDisplay.displayDialogue();
        if (temp) {
            foreach (Player p in roomNavigation.PlayersInRoom()) {
                if (p.currentNode == currentNode) {
                    playerUI.LoadPlayerUI(p);
                    break;
                }
            }
        }
        roomDisplay.decisions(c);

    }
    private void chanceAction(Chance c) {
        System.Random rd = new System.Random();
        int rand_num = rd.Next(0, 100);
        int total = 0;
        Path result = new Path();
        foreach (Path p in c.paths) {
            total += p.chance;
            if (rand_num < total) {
                result = p;
                break;
            }
        }
        newNode(result.outcome);
    }
    private void exitAction(ExitCorridor exit) {
        if (temp) {
            foreach(Player p in roomNavigation.PlayersInRoom()) {
                if (p.currentNode == currentNode) {
                    roomNavigation.playerLocations[p] = exit.nextRoom;
                    p.roomsCleared += 1;
                    p.nodesCleared = 0;
                }
            }
            if (roomNavigation.PlayersInRoom().Count > 0) {
                newNode(roomNavigation.nextPlayer().currentNode);
            }
            else {
                Room next = roomNavigation.nextRoom();
                initialiseRoom(next);
            }
        }
        else {
            initialiseRoom(exit.nextRoom);
        }
        
    }
    private void eventAction(Event e) {
        roomDisplay.eventDisplay(e);
        if (temp) {
            foreach (Player p in roomNavigation.PlayersInRoom()) {
                if (p.currentNode == currentNode) {
                    e.eventAction(p);
                    playerUI.LoadPlayerUI(p);
                    
                    break;
                }
            }
        }

    }
    public void newNode(Interactable node) {
        currentNode = node;
        if (node is Choice) {
            choiceAction((Choice) node);
        }
        else if (node is Narration) {
            currentPage = 0;
            roomDisplay.displayDialogue();
            narrationAction((Narration) node);
        }
        else if (node is Chance) {
            chanceAction((Chance) node);
        }
        else if (node is ExitCorridor) {
            exitAction((ExitCorridor) node);
        }
        else if (node is Event) {
            eventAction((Event) node);
        }
    }


}
