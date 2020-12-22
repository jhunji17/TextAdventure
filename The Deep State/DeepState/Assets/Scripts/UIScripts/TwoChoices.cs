using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoChoices : MonoBehaviour
{
    public GameController gameController;
    public Choice choice;
    public Text option1;
    public Button button1;
    public Text option2;
    public Button button2;


    public void input()
    {
        option1.text = choice.options[0].text;
        option2.text = choice.options[1].text;
        button1.onClick.AddListener(output1);
        button2.onClick.AddListener(output2);
    }
    public void output1() {
        gameController.roomDisplay.twoButton.gameObject.SetActive(false);
        gameController.newNode(choice.options[0].outcome);
    }
    public void output2() {
        gameController.roomDisplay.twoButton.gameObject.SetActive(false);
        gameController.newNode(choice.options[1].outcome);
    }

    


}
