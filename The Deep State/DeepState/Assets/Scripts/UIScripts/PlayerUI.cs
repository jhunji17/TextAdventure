using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject entire;
    public Text playerName;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image item1;
    public Image item2;
    public Image item3;

    

    public void LoadPlayerUI(Player p)
    {
        entire.SetActive(true);
        playerName.text = p.name;
        

        int c = 0;
        if (p.health < 1)
        {
            return; //Should replace this with something else later maybe to show that the player is dead.
        } else
        {
            Image[] hearts = new Image[]{heart1, heart2, heart3};
            while (c < p.health)
            {
                hearts[c].enabled = true;
                hearts[c].sprite = Resources.Load<Sprite>("PixelSprites/Heart");
                c += 1;
            }
        }

        
        Image[] items = new Image[]{item1, item2, item3};
        int c2 = 0;
        foreach (string i in p.items)
        {
            items[c2].enabled = true;
            items[c2].sprite = p.itemImages[c2];
            c2 += 1;
        }
    }
    public void HidePlayerUI() {
        playerName.text = "";
        // heart1.sprite = null;
        // heart2.sprite = null;
        // heart3.sprite = null;
        // item1.sprite = null;
        // item2.sprite = null;
        // item3.sprite = null;
        heart1.enabled = false;
        heart2.enabled = false;
        heart3.enabled = false;
        item1.enabled = false;
        item2.enabled = false;
        item3.enabled = false;
        entire.SetActive(false);
    }
}
