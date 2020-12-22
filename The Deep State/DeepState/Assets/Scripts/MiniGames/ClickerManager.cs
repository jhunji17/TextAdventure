using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MiniGame
{
    [SerializeField]
    GameObject playerText;

    [SerializeField]
    Text countdownTimer;

    public float countdownTime;

    public int score;

    [SerializeField]
    GameObject button;

    public string[] playerNames;

    public int[] scores;

    // Start is called before the first frame update
    void Start()
    {
        
        countdownTime = 10f;
        score = 1;
        DisableButtons();
    }
    #region Inherited Methods
    public override void playLoop(string[] players)
    {
        playerNames = players;
        Debug.Log("setting scores array");
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
        score = 1;
    }
    #endregion
    #region Other Methods
    public void click()
    {
        score++;
    }

    public void EnableButtons()
    {
        button.GetComponent<Button>().interactable = true;
    }

    public void DisableButtons()
    {
        button.GetComponent<Button>().interactable = false;
    }

    #endregion
    #region Coroutines

    IEnumerator playRoutine(string[] players)
    {
        scores = new int[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            
            playerText.GetComponent<Text>().text = players[i] + " click the button as much as you can!";
            playerText.SetActive(true);
            countdownTimer.gameObject.SetActive(true) ;
            yield return GOTimer();
            StartCoroutine(CountdownTimer());
            EnableButtons();
            yield return new WaitForSeconds(10f);

            countdownTimer.text = "Score: " + score;
            yield return new WaitForSeconds(2);
            scores[i] = score;
            score = 0;
            countdownTime = 10f;


        }
    }





    IEnumerator CountdownTimer()
    {
        while(countdownTime > 0)
        {
            countdownTimer.text = countdownTime.ToString();

            yield return new WaitForSeconds(.1f);

            countdownTime -= .1f;
        }
    }

    IEnumerator GOTimer()
    {
        countdownTimer.text = "GO";
        yield return new WaitForSeconds(.75f);
        
    }


    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    #endregion
}
