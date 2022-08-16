using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MeshRenderer[] Colours;

    private int colourSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitBetweenLights;
    private float waitBetweenCounter;

    public bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence;

    private bool gameOver;

    public Text scoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("Highscore",0);
        }
        scoreText.text = "Score: 0 \nHigh Score: "+PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;

            if (stayLitCounter < 0)
            {
                Colours[activeSequence[positionInSequence]].material.SetFloat("_Metallic", 1f); 
                shouldBeLit = false;

                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                positionInSequence++;
            }

        }
        
        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if(positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;

                gameActive = true;
                 
            }
            else
            {
                if (waitBetweenCounter < 0)
                {


                    Colours[activeSequence[positionInSequence]].material.SetFloat("_Metallic", 0f);
                    stayLitCounter = stayLit;

                    shouldBeLit = true;

                    shouldBeDark = false;
                }
            }
        }
        
        
        
    }

    public void StartGame()
    {
        activeSequence.Clear();

        positionInSequence = 0;

        inputInSequence = 0;

        colourSelect = Random.Range(0, Colours.Length);

        activeSequence.Add(colourSelect);

        Colours[activeSequence[positionInSequence]].material.SetFloat("_Metallic", 0f);
        stayLitCounter = stayLit;

        shouldBeLit = true;

        scoreText.text = "Score: 0 \nHigh Score: "+PlayerPrefs.GetInt("HighScore");


        


    }

    public void backMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void colourPressed(int wButton)
    {
        if (gameActive)
        {
            if(activeSequence[inputInSequence] == wButton)
            {
                Debug.Log("correct");
                inputInSequence++;

                if (inputInSequence >= activeSequence.Count)
                {
                    if(activeSequence.Count > PlayerPrefs.GetInt("HighScore"))
                    {
                        PlayerPrefs.SetInt("HighScore",activeSequence.Count);
                    }

                    scoreText.text="Score: "+ activeSequence.Count +"\nHighscore: "+PlayerPrefs.GetInt("HighScore");
                    positionInSequence = 0;
                    inputInSequence = 0;
                    colourSelect = Random.Range(0, Colours.Length);

                    activeSequence.Add(colourSelect);

                    Colours[activeSequence[positionInSequence]].material.SetFloat("_Metallic", 0f);
                    stayLitCounter = stayLit;

                    shouldBeLit = true;

                    gameActive = false;

                    
                }
            }
            else
            {
                Debug.Log("wrong");
                gameActive = false;
                gameOver = true;
            }

        }
    }
}
