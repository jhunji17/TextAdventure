using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeManager : MiniGame

{
    [SerializeField]
    [Tooltip("Organizer containing all walls of maze")]
    GameObject maze;

    [SerializeField]
    [Tooltip("Organizer containing all coins")]
    GameObject interactables;

    [SerializeField]
    [Tooltip("Player")]
    GameObject player;

    public string name = "Maze" ;

    public string[] players;

    int[] scores;

    [SerializeField]
    Text instructionText;



    void Start()
    {
        scores = null;
    }
    public override void playLoop(string[] p)
    {
        
        //Plays the game with the specified players

        players = p;
        scores = new int[p.Length];
        StartCoroutine(playRoutine(p));


    }

    public override bool scoreDone()
    {
        Debug.Log(scores != null & scores[players.Length - 1] > 0);
        Debug.Log(scores[0]);
        return scores != null & scores[players.Length - 1] > 0;
    }

    public override int[] getScores()
    {
        int[] s = scores;
        scores = null;

        return s;

    }

    public override void resetScores()
    {
        scores = null;
    }

    #region Coroutines

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

    IEnumerator showScore()
    {
        MazeMover mazer = player.GetComponent<MazeMover>();
        instructionText.text = "Score = " + mazer.getScore().ToString();
        yield return FadeTextToFullAlpha(2f, instructionText);
        yield return FadeTextToZeroAlpha(1f, instructionText);

    }

    IEnumerator playRoutine(string[] players)
    {
        int pos = 0;
        foreach (string i in players)
        {
            Debug.Log("In The Loop");
            Debug.Log(i);
            //Flash text describing game and time.
            instructionText.text = "You have 15 seconds to collect as many coins as you can " + i;
            yield return FadeTextToFullAlpha(2f, instructionText);
            yield return FadeTextToZeroAlpha(1f, instructionText);
            float time = 0;
            MazeMover mazer = player.GetComponent<MazeMover>();


            mazer.setMove(true);
            while (time < 15)
            {
                time += Time.deltaTime;
                yield return null;
            }
            mazer.setMove(false);
            yield return StartCoroutine(showScore());
            Debug.Log(mazer.getScore());
            scores[pos] = mazer.getScore();
            mazer.reset();


            for (int j = 0; j < interactables.transform.childCount; j++)
            {
                GameObject coin = interactables.transform.GetChild(j).gameObject;
                coin.SetActive(true);
            }

            pos++;
            Debug.Log(pos);

        }
    }
    #endregion




}
