using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    private MeshRenderer theSprite;

    public int thisButtonNumber;

    private GameManager theGM;
    // Start is called before the first frame update
    void Start()
    {
        theSprite = gameObject.GetComponent<MeshRenderer>();
        theGM = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        theSprite.material.SetFloat("_Metallic", 0f);
    }
    void OnMouseUp()
    {
        theSprite.material.SetFloat("_Metallic", 1f);
        theGM.colourPressed(thisButtonNumber);
    }

}
