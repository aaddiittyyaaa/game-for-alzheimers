using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject token;
    List<int> faceindexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    private void Start()
    {
        //float yPosition = 2.24f;
        int originalLength = faceindexes.Count;
        //float yPosition = 3.31f;
        float yPosition = 1.52f;
        //float xPosition = 1.2f;
        float xPosition = -2.11f;

        for(int i = 0; i < 7; i++)
        {
            shuffleNum = rnd.Next(0, (faceindexes.Count));
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            faceindexes.Remove(faceindexes[shuffleNum]);
            //xPosition = xPosition + 2.59f;
            xPosition = xPosition + 3.17f;
            
            //if (i == 0||i==2 || i ==4 )
            if(i == 2)
            {
                //yPosition = -0.24f;
                //yPosition -= 2.48f;
                yPosition-= 3.24f;
                //xPosition = -1.38f;
                xPosition = -5.28f;
            }
            
        }
        token.GetComponent<MainToken>().faceIndex = faceindexes[0];
    }

    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        return success;
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }
}
