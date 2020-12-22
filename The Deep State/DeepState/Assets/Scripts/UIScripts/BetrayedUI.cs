using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetrayedUI : MonoBehaviour
{
    public static List<string> players = new List<string>();
    Text betrayed;
    // Start is called before the first frame update
    void Start()
    {
        betrayed = GetComponent<Text>();
        betrayed.text = "Betrayed: ";
        for (int i = 0; i < players.Count; i++) {
            betrayed.text = betrayed.text + "\n" + players[i];
        }
    }
}
