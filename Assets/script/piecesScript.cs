using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class piecesScript : MonoBehaviour
{
    public draganddrop dg;
    
    public Text ScoreText;
   private Vector3 RightPosition;
   public bool InRightPosition;
   public bool Selected;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(  Random.Range(3f,4f), Random.Range(4f,-4));
        if(!PlayerPrefs.HasKey("JHighScore")){
            PlayerPrefs.SetInt("JHighScore",0);
        }
        ScoreText.text = "Score: 0\n High Score: "+PlayerPrefs.GetInt("JHighScore");
    }

    

    
    void Update()
    {
        
     if (Vector3.Distance(transform.position,RightPosition)< 0.5f) 
     {
         if (!Selected)
         {
             if(InRightPosition == false)
             {
                transform.position = RightPosition;
                InRightPosition = true;
                GetComponent<SortingGroup>().sortingOrder = 0;
                dg.score+=10;
                ScoreText.text="Score: "+dg.score+"\nHigh Score: "+PlayerPrefs.GetInt("JHighScore");
                
             }
         }
     } 
     if(dg.score > PlayerPrefs.GetInt("JHighScore"))
        {
                    PlayerPrefs.SetInt("JHighScore",dg.score);
        }
        ScoreText.text="Score: "+dg.score+"\nHigh Score: "+PlayerPrefs.GetInt("JHighScore");
   
    }
}
