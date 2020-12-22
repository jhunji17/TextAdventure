using System.Collections;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


//Contains methods that can be applied to input fields or buttons.
//Methods specific to a scene will be in its designated region.
public class CanvasManager : MonoBehaviour
{

    
    #region General

    //Quits the game unceremoniously.
    public void QuitGame()
    {
        Application.Quit();
    }

   


    #endregion

    #region Main Menu/Staging
    //Loads staging scene.
    //Staging scene MUST be set as 1 in build order.
    public void PlayGame()
    {
        SceneManager.LoadScene("VideoScene");
    }

    //Loads Main Menu. Can be used in an options menu or as a consequence of losing.
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Placeholder for playtest 1
   /* public void TrustFall()
    {
        if (numPlayers == playerNames.Count) {
            SceneManager.LoadScene("TrustFall");
        }
    }
   */


    #endregion


    #region Rooms

    //Called in response to player choice to load next room.
    //Parameter currently a placeholder
    public void LoadRoom()
    {
        SceneManager.LoadScene("RoomScene");
    }



    #endregion
}
