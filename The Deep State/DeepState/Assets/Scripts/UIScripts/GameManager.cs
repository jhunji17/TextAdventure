using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    public int numPlayers;
    public string[] playerNames;
    public Player[] players;

    
    public GameObject prefabPlayer;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        } else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        players = null;
        DontDestroyOnLoad(gameObject);
        
    }

    public void setNum(InputField n)
    {
        //UnityEngine.Debug.Log(n + "hello");
        
       // numPlayers = Convert.ToInt32(n.text);
    }

    public void setPlayers(string p)
    {
        //playerNames = p.Split(' ');
    }

    public void makePlayers()
    {
        GameObject number = GameObject.Find("PlayerNumberInput");
        GameObject names = GameObject.Find("PlayerNameInput");
        InputField nums = number.GetComponent<InputField>();
        InputField namen = names.GetComponent<InputField>();
        numPlayers = int.Parse(nums.text);
        playerNames = namen.text.Split(' ');
        players = new Player[numPlayers];
        
        int count = 0;

        while (count < numPlayers)
        {
            Player temp = Instantiate(prefabPlayer).GetComponent<Player>();
            temp.name = playerNames[count];
            temp.health = 3;
            //temp.playerUI = (GameObject) UnityEngine.Object.Instantiate(Resources.Load("PlayerUI"));
            temp.isAlive = true;
            UnityEngine.Debug.Log(temp);
            players[count] = temp;
            count += 1;
        }
    
        
       
    }

}
