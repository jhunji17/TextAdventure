using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DeepState/Interactable/Event")]
public class Event : Interactable
{

    [TextArea(1, 30)]
    public string text;
    public bool itemGain;
    public string itemName;
    public Sprite itemImage;
    public bool itemCheck;
    public bool isMinigame;
    public int minigameNumber;

    public Interactable ifItem;
    public Interactable ifNoItem;

    public Interactable next;
    public void eventAction(Player p) {
        if (itemGain) {
            p.items.Add(itemName);
            p.itemImages.Add(itemImage);
        }
        else if (itemCheck) {
            if (p.items.Contains(itemName)) {
                int i = p.items.IndexOf(itemName);
                p.items.RemoveAt(i);
                p.itemImages.RemoveAt(i);
                next = ifItem;
            }
            else {
                next = ifNoItem;
            }
        } else if (isMinigame)
        {
            
            GameObject mg = GameObject.Find("MinigameManager");
            MinigameManager mgScript = mg.GetComponent<MinigameManager>();
            GameObject rm = GameObject.Find("RoomNavigation");
            RoomNavigation rmScript = rm.GetComponent<RoomNavigation>();
            //check to see if a minigame was just played +-
            if (mgScript.concluded())
            {
                rmScript.setWinner(mgScript.getWinner());
                mgScript.resetWinner();
            }
            else
            {
                //get names of players in room
                List<Player> playas = rmScript.PlayersInRoom();
                string[] playerStrings = new string[playas.Count];
                for(int i = 0; i < playas.Count; i++)
                {
                    playerStrings[i] = playas[i].name;
                }
                //play minigame
                mgScript.playMinigame(playerStrings, minigameNumber);
            }
        }
    }
}
