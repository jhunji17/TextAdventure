using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTest : MonoBehaviour
{

    [SerializeField]
    public Camera mainCam;

   

    public string[] testNames = new string[] { "test" };


    public MinigameManager splap;
    // Start is called before the first frame update
    void Start()
    {
        //mazeCamera.gameObject.SetActive(false);
        testNames =new string[] { "kevin", "sebastian", "mateo"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playtest()
    {
        Debug.Log("Beginning of Playtest");
        splap.playMinigame(testNames, 0);
    }

    public void playSimon()
    {
        Debug.Log("Beginning of Playtest");
        splap.playMinigame(testNames, 1);
    }

    public void playClicker()
    {
        Debug.Log("Beginning of Playtest");
        splap.playMinigame(testNames, 2);
    }

    public void playRunner()
    {
        Debug.Log("Beginning of Playtest");
        splap.playMinigame(testNames, 3);
    }

    
    

    IEnumerator quickTimer()
    {
        yield return new WaitForSeconds(5);
    }
}
