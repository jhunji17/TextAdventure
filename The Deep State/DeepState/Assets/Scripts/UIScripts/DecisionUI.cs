using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionUI : MonoBehaviour
{
    public Text description;
    public Text dec1;
    public Text dec2;
    public Text dec3;
    public Text dec4;
    public Text dec5;
    public Text dec6;

    private void resetChoices() {
        description.text = "";
        dec1.text = "";
        dec2.text = "";
        dec3.text = "";
        dec4.text = "";
        dec5.text = "";
        dec6.text = "";
        dec1.gameObject.SetActive(false);
        dec2.gameObject.SetActive(false);
        dec3.gameObject.SetActive(false);
        dec4.gameObject.SetActive(false);
        dec5.gameObject.SetActive(false);
        dec6.gameObject.SetActive(false);
    }
    public void displayChoices(Choice c) {
        resetChoices();
        int l = c.options.Length;
        description.text = c.getDescription();
        if (l > 0) {
            dec1.text = c.options[0].text;
            dec1.gameObject.SetActive(true);
        }
        if (l > 1) {
            dec2.text = c.options[1].text;
            dec2.gameObject.SetActive(true);
        }
        if (l > 2) {
            dec3.text = c.options[2].text;
            dec3.gameObject.SetActive(true);
        }
        if (l > 3) {
            dec4.text = c.options[3].text;
            dec4.gameObject.SetActive(true);
        }
        if (l > 4) {
            dec5.text = c.options[4].text;
            dec5.gameObject.SetActive(true);
        }
        if (l > 5) {
            dec6.text = c.options[5].text;
            dec6.gameObject.SetActive(true);
        }
    }

}
