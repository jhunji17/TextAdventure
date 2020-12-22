using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] minigames;

    [SerializeField]
    [Tooltip("came controller that takes in input, to be disabled at beginning")]
    GameObject controller;

    [SerializeField]
    [Tooltip("Main camera")]
    Camera mainCamera;

    [SerializeField]
    [Tooltip("Cameras for each minigame")]
    Camera[] minigameCameras;

    public string recentWinner;


    void Start()
    {
        recentWinner = null;
    }

    public void playMinigame(string[] players, int minigame)
    {

        StartCoroutine(startGame(players, minigame));
        StartCoroutine(waitForWinner(minigame));

        Debug.Log("coroutines called");
    }


    public string getWinner()
    {
        string w = recentWinner;
        recentWinner = null;
        return w;
    }

    public bool concluded()
    {
        return recentWinner != null;
    }

    public void resetWinner()
    {
        recentWinner = null;
    }


    #region Coroutines
    IEnumerator waitForWinner(int minigame)
    {
        GameObject mg = minigames[minigame];
        while (recentWinner == null)
        {
            yield return null;
        }
        //return to main scene
        Debug.Log("returning to main Scene");
        mg.SetActive(false);
        controller.SetActive(true);
        minigameCameras[minigame].gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        yield return null;
    }

    IEnumerator startGame(string[] players, int m)
    {
        controller.SetActive(false);
        GameObject mg = minigames[m];
        mg.SetActive(true);
        MiniGame mgControl = mg.transform.GetChild(0).gameObject.GetComponent<MiniGame>();
        mainCamera.gameObject.SetActive(false);
        minigameCameras[m].gameObject.SetActive(true);

        Debug.Log("Entering the PlayLoop");
        mgControl.playLoop(players);

        while (mgControl.scoreDone() == false)
        {
            yield return null;
        }

        int[] s = mgControl.getScores();

        mgControl.resetScores();

        int maxVal = -1000;
        int maxPos = 0;

        for (int i = 0; i < players.Length; i++)
        {
            if (s[i] > maxVal)
            {
                maxPos = i;
                maxVal = s[i];
            }
        }

        recentWinner = players[maxPos];
    }


    #endregion




}
