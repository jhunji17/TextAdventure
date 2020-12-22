using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TrustedUI : MonoBehaviour
{
    public static List<string> players = new List<string>();
    Text trusted;
    // Start is called before the first frame update
    void Start()
    {
        trusted = GetComponent<Text>();
        trusted.text = "Trusted: ";
        for (int i = 0; i < players.Count; i++) {
            trusted.text = trusted.text + "\n" + players[i];
        }
    }


}
