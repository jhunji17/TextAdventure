using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDisplay : MonoBehaviour
{
    public Room room;
    public Interactable currentNode;

    public Image backgroundImage;
    public GameObject dialogueBox;
    public Text dialogue;
    public GameObject roomNameBox;
    public Text roomName;
    public GameObject introScreen;

    public GameObject twoButton;
    public TwoChoices twoChoices;
    public GameObject decisionbox;
    public DecisionUI decUI;
    public Text introName;
    public Text introDesc;

    public Text eventText;
    
    private bool intro;
    // Start is called before the first frame update
    

    public void newRoom(Room room) {
        roomName.text = room.name;
        if (room.background) {
            backgroundImage.sprite = room.background;
        }
        
        introName.text = room.name;
        introDesc.text = room.description;
        
        displayIntro();

    }
    public void displayIntro() {
        introScreen.gameObject.SetActive(true);
    }



    public void hideIntro() {
        introScreen.gameObject.SetActive(false);
    }

    public float delay = 0.01f;
    public string fullText;

    IEnumerator ShowText() {
        string currentText = "";
        for (int i = 0; i <= fullText.Length; i++) {
            currentText = fullText.Substring(0, i);
            dialogue.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
    public bool completeText() {
        if (dialogue.text != fullText) {
            StopAllCoroutines();
            dialogue.text = fullText;
            return false;
        }
        else {
            return true;
        }
    }
    public void changeDialogue(string dialoguetext) {
        fullText = dialoguetext;
        StartCoroutine(ShowText());
    }
    public void displayDialogue() {
        dialogueBox.gameObject.SetActive(true);
    }
    public void hideDialogue() {
        dialogue.text = "";
        eventText.text = "";
        fullText = "";
        dialogueBox.gameObject.SetActive(false);
    }
    
    public void twoC(Choice c) {
    
        twoButton.gameObject.SetActive(true);
        twoChoices.choice = c;
        twoChoices.input();
    }
    public void clearDecisions() {
        decisionbox.gameObject.SetActive(false);
    }
    public void decisions(Choice choice) {
        decisionbox.gameObject.SetActive(true);
        decUI.displayChoices(choice);

    }

    public void eventDisplay(Event e) {
        displayDialogue();
        eventText.text = e.text;
    }
    
}
