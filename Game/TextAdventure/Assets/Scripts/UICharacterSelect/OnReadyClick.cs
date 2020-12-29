using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnReadyClick : MonoBehaviour
{
    private GameObject[] inputs;   
    public void ButtonClick()

    {
        ReadInputs();
        SceneChange();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName: "RoomScene");
    }

    public void ReadInputs()
    {
        List<string> names = new List<string>();

        inputs = GameObject.FindGameObjectsWithTag("InputField");
        foreach (GameObject playerNameInput in inputs)
        {
            Text input = playerNameInput.GetComponent(typeof(Text)) as Text;
            if(input.text != null && input.text != "")
            {
                names.Add(input.text);
            }
        }
        GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>().setNames(names);
    }

    
}
