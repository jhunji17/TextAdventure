 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrustFall : MonoBehaviour
{
    public void Begin() {
        //Needs to be changed to be player specific
        SceneManager.LoadScene("PlayerChoose");
    }

    public void Trust() {
        //Need to add UI element
        if (TempPlayer.currPlayer < TempPlayer.players.Count - 1) {
            TrustedUI.players.Add(TempPlayer.players[TempPlayer.currPlayer]);
            TempPlayer.currPlayer += 1;
            SceneManager.LoadScene("PlayerChoose");
        }
        else {
            TrustedUI.players.Add(TempPlayer.players[TempPlayer.currPlayer]);
            SceneManager.LoadScene("Results");
        }
    }

    public void Betray() {
        if (TempPlayer.currPlayer < TempPlayer.players.Count - 1) {
            BetrayedUI.players.Add(TempPlayer.players[TempPlayer.currPlayer]);
            TempPlayer.currPlayer += 1;
            SceneManager.LoadScene("PlayerChoose");
        }
        else {
            BetrayedUI.players.Add(TempPlayer.players[TempPlayer.currPlayer]);
            SceneManager.LoadScene("Results");
        }
    }
}
