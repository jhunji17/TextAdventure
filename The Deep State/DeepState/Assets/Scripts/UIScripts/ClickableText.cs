using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    public int decNum;
    public GameController gameController;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        gameController.decision(decNum);
    }
    
    // void Update()
    // {
    //     if (Input.GetMouseButton(0)) {
    //         gameController.decision(decNum);
    //     }
    // }
}
