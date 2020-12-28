using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnReadyClick : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneChange();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName: "RoomScene");
    }

    
}
