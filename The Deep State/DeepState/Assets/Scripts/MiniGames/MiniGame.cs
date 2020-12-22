using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame: MonoBehaviour 
{
  
    public virtual void playLoop(string[] p)
    {
        Debug.Log("Using the superclas");
        
    }

    public virtual bool scoreDone()
    {
        return true;
    }

    public virtual int[] getScores()
    {
        return new int[1];
    }

    public virtual void resetScores()
    {

    }
}
