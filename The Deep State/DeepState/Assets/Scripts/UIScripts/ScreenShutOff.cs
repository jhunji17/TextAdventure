using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenShutOff : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public GameObject image;
    public GameController GameController;

    void Awake()
    {
        image.SetActive(true);
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += End;
        
    }
    void End(VideoPlayer videoPlayer) {
        image.SetActive(false);
        GameController.OnIntroEnd();
    }
    
}
