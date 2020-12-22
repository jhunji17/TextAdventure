using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempPlayer : MonoBehaviour
{
    public static List<string> players = new List<string>{"Player 1", "Player 2", "Player 3", "Player 4"};
    
    Text player;
    public static int currPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Text>();
        player.text = players[currPlayer];
    }

    // Update is called once per frame
    void Update()
    {
        player.text = players[currPlayer];
    }
}
