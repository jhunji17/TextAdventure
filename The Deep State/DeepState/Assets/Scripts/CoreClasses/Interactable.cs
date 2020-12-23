using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*the generic class for something the player can do
will have a tree structure.
all minigames, choices, challenges, dialogues etc will inherit from this class, allowing us to implement the tree structure. 
haven't fully fleshed this one out yet
*/
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
