using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class draganddrop : MonoBehaviour
{
   public GameObject selectedPiece;

   public int score;
   int OIL = 1;

    void Start()
    {
        PlayerPrefs.SetInt("LastScore",0);
        score=0;
        
    }

    

   
    void Update()
    {
     if (Input.GetMouseButtonDown(0))
     {
         RaycastHit2D hit=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
         if (hit.transform.CompareTag("puzzle"))
         {
             if (!hit.transform.GetComponent<piecesScript>().InRightPosition)
             {
             selectedPiece = hit.transform.gameObject;
             selectedPiece.GetComponent<piecesScript>().Selected = true;
             selectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
             OIL++;
             }
         }
     }   
     if (Input.GetMouseButtonUp(0))
     {

         if (selectedPiece != null)
         {
         selectedPiece.GetComponent<piecesScript>().Selected = false;
         selectedPiece = null;
         }
     }
     if (selectedPiece != null)
     {
         Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         selectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0) ;
     }
     PlayerPrefs.SetInt("LastScore",score);
    } 
}
