using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*

//General script to attach to our text objects and stuff to have them fade in/out. Should make stuff public so a game manager can access it.
[SerializeField]
[Tooltip("Text Objects to be faded in by this Script.")]
// May have to amend this variable later to include other GUI objects we want to fade in.
private UI.Text[] guiObjects;

[SerializeField]
[Tooltip("Button Objects to be faded in by this Script.")]
// May have to amend this variable later to include other GUI objects we want to fade in.
private UI.Button[] buttonObjects;



public class TextFader : MonoBehaviour
{
    public void FadeIn()
    {
        foreach (Text texty in guiObjects)
        {
            StartCoroutine(fadeText(texty));

        }

        foreach (Button butt in buttonObjects)
        {
            StartCoroutine(fadeButton(butt));
        }
    }

    #region Coroutines
    IEnumerator fadeText(UI.Text texty, bool fadeIn)
    {
        float counter = 0f;
        float a, b;
        //Allows coroutine to be used for fading text in or out.
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }
        Color textColor = texty.color;
        while (counter < 2.5)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / 2.5);
            texty.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
            yield return null;  
        }
    }

    IEnumerator fadeButton(UI.Button butty, bool fadeIn)
    {
        float counter = 0f;
        float a, b;
        //Allows coroutine to be used for fading text in or out.
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }
        Image buttonImage = butty.GetComponent<Image>();
        Text buttonText = butty.GetComponentInChildren<Text>();

        Color buttonColor = buttonImage.color;
        Color textColor = buttonText.color;
        while (counter < 2.5)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);//Fade Traget Image
            buttonText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
        }
    }

    #endregion


}

*/