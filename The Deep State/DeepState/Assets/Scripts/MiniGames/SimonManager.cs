using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonManager : MiniGame
{
    
    public string[] playerNames;

    [SerializeField]
    GameObject simonPanel;

    [SerializeField]
    GameObject winnerText;

    public int[] scores;


    // Start is called before the first frame update
    void Start()
    {
        winnerText.SetActive(false);
        simonPanel.SetActive(false);
        scores = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void  playLoop(string[] players)
    {
        //Show Announcement
        scores = new int[players.Length];
        StartCoroutine(playRoutine(players));
        
    }

   


    public override bool scoreDone()
    {
        return scores != null & scores[playerNames.Length - 1] > 0;
    }

    public override int[] getScores()
    {
        return scores;
    }

    public override void resetScores()
    {
        scores = null;
    }


    #region Coroutines

    

    IEnumerator playRoutine(string[] players)
    {
        Debug.Log("Inside playRoutine");
        Text wt = winnerText.GetComponent<Text>();
        playerNames = players;
        
        for (int i = 0; i < players.Length; i++)
        {
            wt.text = "The Game Is Simon Says. " + players[i] + " plays.";
            winnerText.SetActive(true);
            yield return new WaitForSeconds(3);

            winnerText.SetActive(false);
            playerNames = players;

            SimonSays scripty = simonPanel.GetComponent<SimonSays>();
            simonPanel.SetActive(true);
            yield return waitForDone(scripty);
            scores[i] = scripty.getPlayerScore();
            scripty.resetPlayerScore();
            scripty.resetDone();
        }




    }
    
    IEnumerator waitForDone(SimonSays simon)
    {
        while (!simon.finished())
        {
            yield return null;
        }
        yield return null;


    }

    #endregion 
}
