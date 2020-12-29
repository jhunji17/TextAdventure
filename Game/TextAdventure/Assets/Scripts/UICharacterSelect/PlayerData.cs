using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private List<string> Names = new List<string>();
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void setNames(List<string> names){
        Names = names;
    }

    public List<string> getNames(){
        return Names;
    }
}
