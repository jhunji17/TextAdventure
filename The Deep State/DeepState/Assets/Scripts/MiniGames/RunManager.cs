using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunManager : MiniGame
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text announcement;

    [SerializeField]
    Text timerText;

    public float timer;

    private bool canMove;

    public int playerScore;

    public int[] scores;

    public string[] playerNames;

    public bool reachedGoal;


    // Start is called before the first frame update
    void Start()
    {
        announcement.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        canMove = false;
        playerScore = 1;
        reachedGoal = false;
        playerNames = new string[1];
    }

    void Update()
    {
        

    }

    public bool moveCheck()
    {
        return canMove;
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

    public override void playLoop(string[] players)
    {
        playerNames = players;
        scores = new int[players.Length];

        StartCoroutine(playRoutine(players)); ;
    }

    public void setGoal()
    {
        reachedGoal = true;
    }



    #region Coroutines

    IEnumerator playRoutine(string[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            announcement.text = "Reach the coin as fast as you can " + players[i] + ".";
            announcement.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            announcement.text = "GO";
            canMove = true;
            yield return TimerCoroutine();
            scores[i] = playerScore;
            playerScore = 1;
        }
    }

    IEnumerator TimerCoroutine()
    {
        float timer = 0f;
        while (!reachedGoal)
        {
            announcement.text = timer.ToString();
            timer += Time.deltaTime;
            yield return null;
        }
        playerScore = 100 / (int) timer;
        canMove = false;
        yield return null; 
    }

    #endregion
}
