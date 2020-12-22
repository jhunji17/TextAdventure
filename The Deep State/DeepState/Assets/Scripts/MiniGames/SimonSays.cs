using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    GameObject[] levelLights;

    [SerializeField]
    GameObject[] simonLights;

    [SerializeField]
    int[] lightOrder;

    [SerializeField]
    GameObject gamePanel;

    [SerializeField]
    GameObject manager;
    #endregion

    #region Other Variables
    int level = 0;
    int buttonsClicked = 0;
    int colorOrderRunCount = 0;
    bool passed = false;
    bool won = false;
    Color32 red = new Color32(255, 39, 0, 255);
    Color32 green = new Color32(4, 204, 0, 255);
    Color32 invisible = new Color32(4, 204, 0, 0);
    Color32 white = new Color32(255, 255, 255, 255);
    public float speed;

    public bool isDone;
    public int playerScore;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 1;
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnable()
    {
        level = 0;
        buttonsClicked = 0;
        colorOrderRunCount = -1;
        won = false;
        for (int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = (Random.Range(0, 8));
        }
        for (int i = 0;  i < levelLights.Length; i++)
        {
            levelLights[i].GetComponent<Image>().color = white;
        }
        level = 1;

        StartCoroutine(ColorOrder());
    }

    void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    public void ButtonClickOrder(int b)
    {
        buttonsClicked++;
        if (b == lightOrder[buttonsClicked - 1])
        {
            UnityEngine.Debug.Log("Pass");
            passed = true;
            playerScore++;
        }
        else
        {
            UnityEngine.Debug.Log("failed");
            passed = false;
            StartCoroutine(ColorBlink(red));
        }
        if (buttonsClicked == level && passed == true && buttonsClicked != 5)
        {
            level++;
            passed = false;
            StartCoroutine(ColorOrder());

        }
        if (buttonsClicked == level && passed == true && buttonsClicked == 5)
        {
            UnityEngine.Debug.Log("failed");
            won = true;
            StartCoroutine(ColorBlink(green));
        }
    }

    public void ClosePanel()
    {
        gamePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        gamePanel.SetActive(true);
    }

    public void resetPlayerScore()
    {
        playerScore = 1;
    }

    public void resetDone()
    {
        isDone = false;
    }

    public bool finished()
    {
        return isDone;
    }

    public int getPlayerScore()
    {
        return playerScore;
    }

   




    #region Coroutines

    IEnumerator ColorOrder()
    {
        buttonsClicked = 0;
        colorOrderRunCount++;
        DisableButtons();
        for (int i = 0; i <= colorOrderRunCount; i++)
        {
            if (level >= colorOrderRunCount)
            {
                simonLights[lightOrder[i]].GetComponent<Image>().color = invisible;
                yield return new WaitForSeconds(speed);

                simonLights[lightOrder[i]].GetComponent<Image>().color = green;
                yield return new WaitForSeconds(speed);

                simonLights[lightOrder[i]].GetComponent<Image>().color = invisible;
                levelLights[i].GetComponent<Image>().color = green;
            }
        }
        EnableButtons();
    }

    IEnumerator ColorBlink(Color32 color)
    {
        DisableButtons();
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = color;
            }
            yield return new WaitForSeconds(.5f);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = white;
            }
            yield return new WaitForSeconds(.5f);
        }
        if (won == true)
        {
            playerScore += level;
            isDone = true;
            //DO WINNING STUFF HERE OR LOSING STUFF
            ClosePanel();
        } else if (won == false)
        {
            isDone = true;
            ClosePanel();
            //DO LOSING STUFF HERE
        }
      
    }
    #endregion
}
