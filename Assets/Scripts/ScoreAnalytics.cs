using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text HighSCore;
    public Text Percentage;

    public Text LastGame;
    // Update is called once per frame
    void Update()
    {
        HighSCore.text = ""+PlayerPrefs.GetInt("JHighScore"); 
        Percentage.text = ""+(PlayerPrefs.GetInt("JHighScore")*100)/360+"%";
        if(PlayerPrefs.GetInt("LastScore")==0)
        {
            LastGame.text="--";
        }
        else
        {
            LastGame.text=""+PlayerPrefs.GetInt("LastScore");
        }
        

    }
}
